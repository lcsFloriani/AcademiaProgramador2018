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

namespace GerenciadorProvas.Infra.Dados.SQL.MateriaRepositorySQL
{
    public class MateriaRepositorySQL : SQLRepository<Materia>, IMateriaRepository
    {
        #region Scripts SQL

        private const string _insercao =
                            @"INSERT INTO TBMateria
                               (Nome, 
                                IdSerie,
                                IdDisciplina)
                            VALUES (
                                {0}Nome,
                                {0}IdSerie,
                                {0}IdDisciplina)";


        private const string _listagem = @"SELECT  
                                            M.ID, 
                                            M.Nome, 
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
                               IdDisciplina = {0}IdDisciplina
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

        private const string _procurarMateriaPorDisciplinaSerie = @"SELECT 
                                      M.ID, 
                                      M.Nome,
                                      S.ID AS SerieId, 
                                      S.Grau AS SerieGrau, 
                                      D.ID AS DisciplinaId, 
                                      D.Nome AS DisciplinaNome
                                        FROM TBMateria AS M 
                                        INNER JOIN TBDisciplina AS D ON M.IdDisciplina = D.Id
                                        INNER JOIN TBSerie AS S ON M.IdSerie = S.Id
                                        WHERE D.Id = {0}IdDisciplina AND S.Id = {0}IdSerie";

        private const string _procurarMateriaPorDisciplina = @"SELECT 
                                      M.ID, 
                                      M.Nome,
                                      S.ID AS SerieId, 
                                      S.Grau AS SerieGrau, 
                                      D.ID AS DisciplinaId, 
                                      D.Nome AS DisciplinaNome
                                        FROM TBMateria AS M 
                                        INNER JOIN TBDisciplina AS D ON M.IdDisciplina = D.Id
                                        INNER JOIN TBSerie AS S ON M.IdSerie = S.Id
                                        WHERE D.Id = {0}IdDisciplina";

        private const string _entidadeComDepenciaComQuestao = @"SELECT CAST(
                                                        CASE WHEN EXISTS(
                                                            SELECT Q.IdMateria FROM TBQuestao AS Q 
                                                                WHERE Q.IdMateria = {0}Id) 
                                                                 THEN 1 
                                                                ELSE 0 
                                                              END 
                                                        AS BIT) AS Exist";

        private const string _entidadeComDepenciaComTeste = @"SELECT CAST(
                                                        CASE WHEN EXISTS(
                                                            SELECT T.IdMateria FROM TBTeste AS T 
                                                                WHERE T.IdMateria = {0}Id) 
                                                                 THEN 1 
                                                                ELSE 0 
                                                              END 
                                                        AS BIT) AS Exist";

        #endregion Scripts SQL 

        public MateriaRepositorySQL(TipoBancoDados tipo) : base(tipo)
        { }

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

        public override void Excluir(Materia entidade)
        {
            base.Excluir(_deletar, entidade.Id);
        }

        public override IList<Materia> Listagem()
        {
            return base.ExecutaPesquisaDeListagem(_listagem, LinhaParaEntidade);
        }

        public override Materia ProcuraPorId(int id)
        {

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", id},
            };

            return base.ExecutaPesquisa(_procuraPorId, LinhaParaEntidade, parametros);
        }

        private Dictionary<string, object> EntidadeParaLinha(Materia entidade, bool hasId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Nome", entidade.Nome);
            parametros.Add("IdSerie", entidade.Serie.Id);
            parametros.Add("IdDisciplina", entidade.Cadeira.Id);

            if (hasId)
                parametros.Add("Id", entidade.Id);

            return parametros;
        }

        public bool RegistroRepetido(Materia entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Nome", entidade.Nome},
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeExiste, parametros) == 1;
        }

        public bool RegistroComDependeciaComQuestao(Materia entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeComDepenciaComQuestao, parametros) == 1;
        }

        public IList<Materia> ProcurarMateriaPorDisciplinaSerie(Disciplina disciplina, Serie serie)
        {

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"IdDisciplina", disciplina.Id},
                {"IdSerie", serie.Id},
            };

            return base.ExecutaPesquisaDeListagem(_procurarMateriaPorDisciplinaSerie, LinhaParaEntidade, parametros);
        }

        public bool RegistroComDependeciaComTeste(Materia entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeComDepenciaComTeste, parametros) == 1;
        }

        public IList<Materia> ProcurarMateriaPorDisciplina(Disciplina disciplina)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"IdDisciplina", disciplina.Id},
            };

            return base.ExecutaPesquisaDeListagem(_procurarMateriaPorDisciplina, LinhaParaEntidade, parametros);
        }

        private static Func<IDataReader, Materia> LinhaParaEntidade = reader =>
          new Materia
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["Nome"]),

              Cadeira = new Disciplina
              {
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
