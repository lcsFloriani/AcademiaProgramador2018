using GerenciadorProvas.Dominio.Enums;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Infra.Dados.SQL.SerieRepositorySQL
{
    public class SerieRepositorySQL : SQLRepository<Serie>, ISerieRepository
    {
        #region Scripts SQL

        private const string _insercao =
                            @"INSERT INTO TBSerie
                               (Grau)
                            VALUES (
                                {0}Grau)";

        private const string _listagem = @"SELECT * FROM TBSerie order by Grau";

        private const string _procuraPorId =
                            @"SELECT 
                            *
                           FROM TBSerie
                           WHERE Id = {0}Id";

        private readonly string _atualizar =
                           @"UPDATE TBSerie
                           SET Grau = {0}Grau
                            WHERE Id = {0}Id";

        private const string _deletar = @"DELETE FROM TBSerie WHERE Id = {0}Id";

        private const string _entidadeExiste = @"SELECT CAST(
                                                 CASE WHEN EXISTS(
                                                  SELECT * FROM TBSerie 
                                                   WHERE Grau = {0}Grau AND Id <> {0}Id) 
                                                    THEN 1 
                                                     ELSE 0 
                                                   END 
                                                   AS BIT) AS Exist";

        private const string _entidadeComDepencia = @"SELECT CAST(
                                                        CASE WHEN EXISTS(
                                                            SELECT M.IdSerie FROM TBMateria AS M 
                                                                WHERE M.IdSerie = {0}Id) 
                                                                 THEN 1 
                                                                ELSE 0 
                                                              END 
                                                        AS BIT) AS Exist";

        #endregion Scripts SQL 


        public SerieRepositorySQL(TipoBancoDados tipo) : base(tipo)
        { }

        public override Serie Adicionar(Serie entidade)
        {
            entidade.Id = ExecutaOuAtualiza(_insercao, EntidadeParaLinha(entidade, false));
            return entidade;
        }

        public override Serie Atualizar(Serie entidade)
        {
            base.ExecutaOuAtualiza(_atualizar, EntidadeParaLinha(entidade, true), false);

            return entidade; 
        }

        public override void Excluir(Serie entidade)
        {
             base.Excluir(_deletar, entidade.Id);
        }

        public override IList<Serie> Listagem()
        {
            return base.ExecutaPesquisaDeListagem(_listagem, LinhaParaEntidade);
        }

        public override Serie ProcuraPorId(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", id},
            };

            return base.ExecutaPesquisa(_procuraPorId, LinhaParaEntidade, parametros);
        }

        private Dictionary<string, object> EntidadeParaLinha(Serie entidade, bool hasId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Grau", entidade.Grau);

            if (hasId)
                parametros.Add("Id", entidade.Id);

            return parametros;
        }

        public bool RegistroRepetido(Serie entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Grau", entidade.Grau},
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeExiste, parametros) == 1;
        }

        public bool RegistroComDependecia(Serie entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeComDepencia, parametros) == 1;
        }

        private static Func<IDataReader, Serie> LinhaParaEntidade = reader =>
          new Serie
          {
              Id = Convert.ToInt32(reader["Id"]),
              Grau = Convert.ToInt32(reader["Grau"])
          };
    }
}
