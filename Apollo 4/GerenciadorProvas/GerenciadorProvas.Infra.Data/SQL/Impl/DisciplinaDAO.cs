using GerenciadorProvas.Domain;
using GerenciadorProvas.Domain.Exception;
using GerenciadorProvas.Domain.Modal;
using GerenciadorProvas.Infra.Data.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Infra.Data.DAO
{
    public class DisciplinaDAO : DAOImpl<Disciplina>
    {
        #region Scripts SQL

        private const string _insercao =
                            @"INSERT INTO TBDisciplina
                               (Nome)
                            VALUES (
                                {0}Nome)";

        private const string _listagem = @"SELECT * FROM TBDisciplina ORDER BY Nome";

        private const string _procuraPorId =
                            @"SELECT 
                            *
                           FROM TBDisciplina
                           WHERE Id = {0}Id";

        private readonly string _atualizar =
                           @"UPDATE TBDisciplina
                           SET Nome = {0}Nome
                            WHERE Id = {0}Id";

        private const string _deletar = @"DELETE FROM TBDisciplina WHERE Id = {0}Id";

        private const string _entidadeExiste = @"SELECT CAST(
                                                 CASE WHEN EXISTS(
                                                  SELECT * FROM TBDisciplina 
                                                   WHERE Nome LIKE {0}Nome AND Id <> {0}Id) 
                                                    THEN 1 
                                                     ELSE 0 
                                                   END 
                                                   AS BIT) AS Exist";

        #endregion Scripts SQL 

        public DisciplinaDAO(DatabaseType tipo) : base(tipo)
        {}

        public override Disciplina Adicionar(Disciplina entidade)
        {
            entidade.Id = base.ExecutaOuAtualiza(_insercao, EntidadeParaLinha(entidade, false));

            return entidade;
        }

        public override Disciplina Atualizar(Disciplina entidade)
        {
            base.ExecutaOuAtualiza(_atualizar, EntidadeParaLinha(entidade, true), false);

            return entidade;
        }

        public override int Excluir(Disciplina entidade)
        {
            return base.Deletar(_deletar, entidade.Id);
        }

        public bool ExisteRegistroRepetido(Disciplina entidade)
        {
            Dictionary<string, object> parametos = new Dictionary<string, object>()
            {
                {"Nome", entidade.Nome},
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeExiste, parametos) == 0;
        }

        public override IList<Disciplina> Listagem()
        {
            return base.ExecutaPesquisaDeListagem(_listagem, LinhaParaEntidade);
        }

        public override Disciplina ProcuraPorId(int id)
        {
            Dictionary<string, object> parametos = new Dictionary<string, object>()
            {
                {"Id", id},
            };

            return base.ExecutaPesquisa(_procuraPorId, LinhaParaEntidade, parametos);
        }

        private Dictionary<string, object> EntidadeParaLinha(Disciplina entidade, bool hasId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Nome", entidade.Nome);

            if (hasId)
                parameters.Add("Id", entidade.Id);

            return parameters;
        }

        private static Func<IDataReader, Disciplina> LinhaParaEntidade = reader =>
          new Disciplina
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["Nome"])
          };

    }
}
