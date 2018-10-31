using GerenciadorProvas.Dominio;
using GerenciadorProvas.Dominio.Enums;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Infra.SQL
{
    public abstract class SQLRepository<T> : IRepository<T> where T : Entidade
    {
        protected IDbConnection Conexao { get; }
        protected IDbCommand Comando { get; }
        protected IDataReader Leitor { get; set; }
        protected TipoBancoDados Tipo { get; set; }

        public SQLRepository(TipoBancoDados tipo)
        {
            this.Tipo = tipo;
            Conexao = FabricaConexoes.CriarConexao(tipo);
            Comando = Conexao.CreateCommand();
        }

        public abstract T Adicionar(T entidade);
        public abstract T Atualizar(T entidade);
        public abstract void Excluir(T entidade);
        public abstract IList<T> Listagem();
        public abstract T ProcuraPorId(int id);

        protected int ExecutaOuAtualiza(string pesquisa, Dictionary<string, object> parametros = null, bool carregarId = true)
        {
            int id = 0;
            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = FabricaConexoes.PegarStringDaConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = pesquisa.FormataPesquisa(Tipo, carregarId);

                    Conexao.Open();

                    Comando.AdicionaParametros(parametros);

                    if (carregarId)
                    {
                        id = Convert.ToInt32(Comando.ExecuteScalar());
                    }
                    else
                    {
                        Comando.ExecuteNonQuery();
                    }
                }
            }

            return id;
        }

        public IList<T> ExecutaPesquisaDeListagem(string pesquisa, Func<IDataReader, T> LinhaParaEntidade, Dictionary<string, object> parametro = null)
        {
            var list = new List<T>();

            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = FabricaConexoes.PegarStringDaConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = pesquisa.FormataPesquisa(Tipo);

                    Conexao.Open();

                    Comando.AdicionaParametros(parametro);

                    Leitor = Comando.ExecuteReader();

                    while (Leitor.Read())
                    {
                        list.Add(LinhaParaEntidade(Leitor));
                    }
                }
            }

            return list;
        }
        public T ExecutaPesquisa(string pesquisa, Func<IDataReader, T> LinhaParaEntidade, Dictionary<string, object> parametro = null)
        {
            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = FabricaConexoes.PegarStringDaConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = pesquisa.FormataPesquisa(Tipo);

                    Conexao.Open();

                    Comando.AdicionaParametros(parametro);

                    Leitor = Comando.ExecuteReader();

                    if (Leitor.Read())
                    {
                        return LinhaParaEntidade(Leitor);
                    }
                }
            }

            return null;
        }

        public void Excluir(string pesquisa, int id)
        {
            using (Conexao)
            {
                try
                {
                    Conexao.ConnectionString = FabricaConexoes.PegarStringDaConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = pesquisa.FormataPesquisa(Tipo);

                    Conexao.Open();

                    var parametro = Comando.CreateParameter();
                    parametro.Value = id;
                    parametro.ParameterName = "Id";
                    Comando.Parameters.Add(parametro);

                    Comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }


        public int Existe(string pesquisa, Dictionary<string, object> parametros = null)
        {
            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = FabricaConexoes.PegarStringDaConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = pesquisa.FormataPesquisa(Tipo);

                    Conexao.Open();

                    Comando.AdicionaParametros(parametros);

                    Leitor = Comando.ExecuteReader();

                    if (Leitor.Read())
                    {
                        return Convert.ToInt32(Leitor["Exist"]);
                    }
                }
            }

            return -1;
        }
    }

    static class MetodosExtensao
    {

        public static void AdicionaParametros(this IDbCommand comando, Dictionary<string, object> parametros)
        {
            if (parametros == null)
                return;

            foreach (KeyValuePair<string, object> entry in parametros)
            {
                var parametro = comando.CreateParameter();
                parametro.ParameterName = entry.Key;
                parametro.Value = entry.Value;

                comando.Parameters.Add(parametro);
            }
        }

        public static string FormataPesquisa(this string pesquisa, TipoBancoDados tipo, bool carregarId = false)
        {
            pesquisa = pesquisa.FormataAlias(tipo);
            pesquisa = (carregarId ? pesquisa.AcrescentarSelecaoDoId(tipo) : pesquisa);

            return pesquisa;
        }

        private static string FormataAlias(this string pesquisa, TipoBancoDados tipo)
        {
            return string.Format(pesquisa, SQLUtil.PegarAlias(tipo));
        }

        private static string AcrescentarSelecaoDoId(this string pesquisa, TipoBancoDados tipo)
        {
            switch (tipo)
            {
                case TipoBancoDados.MY_SQL:
                    return pesquisa + ";SELECT @@IDENTITY";
                case TipoBancoDados.SQL_SERVER:
                    return pesquisa + ";SELECT SCOPE_IDENTITY()";
            }

            return pesquisa;
        }

    }
}
