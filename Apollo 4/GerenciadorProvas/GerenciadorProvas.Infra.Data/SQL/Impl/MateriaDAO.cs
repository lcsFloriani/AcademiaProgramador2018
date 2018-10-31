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
    public class MateriaDAO : DAOImpl<Materia>
    {
        #region Scripts SQL

        private const string _insercao =
                            @"INSERT INTO TBMateria
                               (Nome, 
                                IdSerie,
                                IdDisciplina,
                                Bimestre)
                            VALUES (
                                {0}Nome,
                                {0}IdSerie,
                                {0}IdDisciplina,
                                {0}Bimestre)";


        private const string _listagem = @"SELECT  
                                            M.ID, 
                                            M.Nome, 
                                            M.Bimestre,
                                            S.ID AS SerieId, 
                                            S.Grau AS SerieGrau, 
                                            D.ID AS DisciplinaId,
                                            D.Nome AS DisciplinaNome
                                                FROM TBMateria AS M
                                                INNER JOIN TBSerie AS S
                                                ON M.IdSerie = S.ID
                                                INNER JOIN TBDisciplina AS D
                                                ON M.IdDisciplina = D.Id order by M.Nome";

        private const string _procuraPorId =
                            @"SELECT  M.ID, 
                                      M.Nome,
                                      M.Bimestre,
                                      S.ID AS SerieId, 
                                      S.Grau AS SerieGrau, 
                                      D.ID AS DisciplinaId, 
                                      D.Nome AS DisciplinaNome
                                            FROM TBMateria AS M
                                            INNER JOIN TBSerie AS S
                                            ON M.IdSerie = S.ID
                                            INNER JOIN TBDisciplina AS D
                                            ON M.IdDisciplina = D.Id
                                            WHERE M.Id = {0}Id";

        private readonly string _atualizar =
                           @"UPDATE TBMateria
                           SET Nome = {0}Nome,
                               IdSerie = {0}IdSerie,
                               IdDisciplina = {0}IdDisciplina,
                               Bimestre = {0}Bimestre
                            WHERE Id = {0}Id";

        private const string _deletar = @"DELETE FROM TBMateria WHERE Id = {0}Id";

        private const string _entidadeExiste = @"SELECT CAST(
                                                 CASE WHEN EXISTS(
                                                  SELECT * FROM TBMateria 
                                                   WHERE Nome LIKE {0}Nome AND Id <> {0}Id) 
                                                    THEN 1 
                                                     ELSE 0 
                                                   END 
                                                   AS BIT) AS Exist";

        #endregion Scripts SQL 

        public MateriaDAO(DatabaseType tipo) : base(tipo)
        {

        }

        public override Materia Adicionar(Materia entidade)
        {
            entidade.Id = base.ExecutaOuAtualiza(_insercao, EntidadeParaLinha(entidade, false));
            return entidade;
        }

        public override Materia Atualizar(Materia entidade)
        {
            entidade.Id = base.ExecutaOuAtualiza(_atualizar, EntidadeParaLinha(entidade, true), false);
            return entidade;
        }

        public override int Excluir(Materia entidade)
        {
            return base.Deletar(_deletar, entidade.Id);
        }
  
        public override IList<Materia> Listagem()
        {
            return base.ExecutaPesquisaDeListagem(_listagem, LinhaParaEntidade);
        }

        public override Materia ProcuraPorId(int id)
        {

            Dictionary<string, object> parametos = new Dictionary<string, object>()
            {
                {"Id", id},
            };

            return base.ExecutaPesquisa(_procuraPorId, LinhaParaEntidade, parametos);
        }

        public bool ExisteRegistroRepetido(Materia entidade)
        {
            Dictionary<string, object> parametos = new Dictionary<string, object>()
            {
                {"Nome", entidade.Nome},
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeExiste, parametos) == 0;
        }


        private Dictionary<string, object> EntidadeParaLinha(Materia entidade, bool hasId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Nome", entidade.Nome);
            parameters.Add("IdSerie", entidade.Serie.Id);
            parameters.Add("IdDisciplina", entidade.Cadeira.Id);
            parameters.Add("Bimestre", entidade.Bimestre);

            if (hasId)
                parameters.Add("Id", entidade.Id);

            return parameters;
        }

        private static Func<IDataReader, Materia> LinhaParaEntidade = reader =>
          new Materia
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["Nome"]),
              Bimestre = Convert.ToString(reader["Bimestre"]),

              Cadeira = new Disciplina{
                  Id = Convert.ToInt32(reader["DisciplinaId"]),
                  Nome = Convert.ToString(reader["DisciplinaNome"])
              },

              Serie = new Serie
              {
                  Id = Convert.ToInt32(reader["SerieId"]),
                  Grau = Convert.ToInt32(reader["SerieGrau"])
              }
          };
    }
}
