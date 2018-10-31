using System;
using System.Collections.Generic;
using System.Data;
using GerenciadorProvas.Dominio.Enums;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.Infra.SQL;



namespace GerenciadorProvas.Infra.Dados.SQL.DisciplinaRepositorySQL
{
    public class DisciplinaRepositorySQL: SQLRepository<Disciplina>, IDisciplinaRepository
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

        private const string _entidadeComDepencia = @"SELECT CAST(
                                                        CASE WHEN EXISTS(
                                                            SELECT M.IdDisciplina FROM TBMateria AS M 
                                                                WHERE M.IdDisciplina = {0}Id) 
                                                                 THEN 1 
                                                                ELSE 0 
                                                              END 
                                                        AS BIT) AS Exist";

        #endregion Scripts SQL 

        public DisciplinaRepositorySQL(TipoBancoDados tipo) : base(tipo)
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

        public override void Excluir(Disciplina entidade)
        {
             base.Excluir(_deletar, entidade.Id);
        }

        public override IList<Disciplina> Listagem()
        {
            return base.ExecutaPesquisaDeListagem(_listagem, LinhaParaEntidade);
        }

        public override Disciplina ProcuraPorId(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", id},
            };

            return base.ExecutaPesquisa(_procuraPorId, LinhaParaEntidade, parametros);
        }

        private Dictionary<string, object> EntidadeParaLinha(Disciplina entidade, bool hasId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Nome", entidade.Nome);

            if (hasId)
                parametros.Add("Id", entidade.Id);

            return parametros;
        }

        public bool RegistroRepetido(Disciplina entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Nome", entidade.Nome},
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeExiste, parametros) == 1;
        }

        public bool RegistroComDependecia(Disciplina entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeComDepencia, parametros) == 1;
        }

        private static Func<IDataReader, Disciplina> LinhaParaEntidade = reader =>
          new Disciplina
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["Nome"])
          };

    }
}
