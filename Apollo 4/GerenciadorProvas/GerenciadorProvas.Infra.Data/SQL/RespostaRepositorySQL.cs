using GerenciadorProvas.Dominio.Enums;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;


namespace GerenciadorProvas.Infra.Dados.SQL.RespostaRepositorySQL
{
    public class RespostaRepositorySQL: SQLRepository<Resposta>, IRespostaRepository
    {
        #region Scripts SQL

        private const string _insercao =
                            @"INSERT INTO TBResposta
                               (Descricao,
                                Certa,
                                Letra,
                                IdQuestao)
                            VALUES (
                                {0}Descricao,
                                {0}Certa,
                                {0}Letra,
                                {0}IdQuestao)";

        private const string _listagem = @"SELECT * FROM TBResposta ORDER BY Id";

        private const string _listagemPorQuestao = @"SELECT * FROM TBResposta 
                                                     WHERE IdQuestao = {0}Id ORDER BY Id";

        private const string _procuraPorId =
                            @"SELECT 
                            *
                           FROM TBResposta
                           WHERE Id = {0}Id";

        private readonly string _atualizar =
                           @"UPDATE TBResposta
                             SET 
                                Descricao = {0}Descricao,
                                Certa = {0}Certa,
                                Letra = {0}Letra,
                                IdQuestao = {0}IdQuestao
                            WHERE Id = {0}Id";

        private const string _deletar = @"DELETE FROM TBResposta WHERE Id = {0}Id";

        #endregion Scripts SQL 

        public RespostaRepositorySQL(TipoBancoDados tipo) : base(tipo)
        { }

        public override Resposta Adicionar(Resposta entidade)
        {
            entidade.Id = base.ExecutaOuAtualiza(_insercao, EntidadeParaLinha(entidade, false));

            return entidade;
        }

        public override Resposta Atualizar(Resposta entidade)
        {
            base.ExecutaOuAtualiza(_atualizar, EntidadeParaLinha(entidade, true), false);

            return entidade;
        }

        public override void Excluir(Resposta entidade)
        {
            base.Excluir(_deletar, entidade.Id);
        }

        public override IList<Resposta> Listagem()
        {
            return base.ExecutaPesquisaDeListagem(_listagem, LinhaParaEntidade);
        }

        public override Resposta ProcuraPorId(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", id},
            };

            return base.ExecutaPesquisa(_procuraPorId, LinhaParaEntidade, parametros);
        }

        private Dictionary<string, object> EntidadeParaLinha(Resposta entidade, bool hasId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Descricao", entidade.Descricao);
            parametros.Add("Certa", entidade.Certa);
            parametros.Add("Letra", entidade.Letra);
            parametros.Add("IdQuestao", entidade.Questao.Id);

            if (hasId)
                parametros.Add("Id", entidade.Id);

            return parametros;
        }

        public IList<Resposta> ListagemPorQuestao(Questao entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", entidade.Id},
            };

            return base.ExecutaPesquisaDeListagem(_listagemPorQuestao, LinhaParaEntidade, parametros);
        }

        private static Func<IDataReader, Resposta> LinhaParaEntidade = reader =>
         new Resposta
         {
             Id = Convert.ToInt32(reader["Id"]),
             Descricao = Convert.ToString(reader["Descricao"]),
             Certa = Convert.ToBoolean(reader["Certa"]),
             Letra = Convert.ToChar(reader["Letra"]),

             Questao = new Questao
             {
                 Id = Convert.ToInt32(reader["IdQuestao"])
             }
         };
    }
}
