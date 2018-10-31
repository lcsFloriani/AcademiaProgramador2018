using GerenciadorProvas.Domain.Modal;
using GerenciadorProvas.Infra.Data.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Infra.Data.DAO.Impl
{
    public class SerieDAO : DAOImpl<Serie>
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

        #endregion Scripts SQL 


        public SerieDAO(DatabaseType tipo) : base(tipo)
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

        public override int Excluir(Serie entidade)
        {
            return base.Deletar(_deletar, entidade.Id);
        }

        public override IList<Serie> Listagem()
        {
            return base.ExecutaPesquisaDeListagem(_listagem, LinhaParaEntidade);
        }

        public bool ExisteRegistroRepetido(Serie entidade)
        {
            Dictionary<string, object> parametos = new Dictionary<string, object>()
            {
                {"Grau", entidade.Grau},
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeExiste, parametos) == 0;

        }

        public override Serie ProcuraPorId(int id)
        {
            Dictionary<string, object> parametos = new Dictionary<string, object>()
            {
                {"Id", id},
            };

            return base.ExecutaPesquisa(_procuraPorId, LinhaParaEntidade, parametos);
        }

        private Dictionary<string, object> EntidadeParaLinha(Serie entidade, bool hasId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Grau", entidade.Grau);

            if (hasId)
                parameters.Add("Id", entidade.Id);

            return parameters;
        }

        private static Func<IDataReader, Serie> LinhaParaEntidade = reader =>
          new Serie
          {
              Id = Convert.ToInt32(reader["Id"]),
              Grau = Convert.ToInt32(reader["Grau"])
          };
    }
}
