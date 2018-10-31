using GerenciadorProvas.Dominio.Enums;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.infra;
using GerenciadorProvas.Infra.Dados.IoC;
using GerenciadorProvas.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;


namespace GerenciadorProvas.Infra.Dados.SQL.QuestaoRepositorySQL
{
    public class QuestaoRepositorySQL : SQLRepository<Questao>, IQuestaoRepository, IQuestaoTesteSQL
    {

        #region Scripts SQL
        private const string _insercao =
                    @"INSERT INTO TBQuestao
                               (Enunciado, 
                                Bimestre,
                                IdMateria)
                            VALUES (
                                {0}Enunciado,
                                {0}Bimestre,
                                {0}IdMateria)";


        private const string _listagem = @"SELECT  
                                              Q.Id, 
                                              Q.Enunciado,
	                                          Q.Bimestre, 
                                              M.ID AS MateriaId, 
                                              M.Nome AS MateriaNome
                                              FROM TBQuestao AS Q
		                                      INNER JOIN TBMateria AS M
		                                      ON Q.IdMateria = M.ID
		                                      ORDER BY Q.Id";

        private const string _procuraPorId = @"SELECT  *  FROM TBQuestao WHERE Id = {0}Id";

        private const string _atualizar =
                           @"UPDATE TBQuestao
                           SET Enunciado = {0}Enunciado,
                               Bimestre = {0}Bimestre,
                               IdMateria = {0}IdMateria
                            WHERE Id = {0}Id";

        private const string _deletar = @"DELETE FROM TBQuestao WHERE Id = {0}Id";

        private const string _listagemPorMateria = @"SELECT  
                                              Q.Id, 
                                              Q.Enunciado,
	                                          Q.Bimestre, 
                                              M.ID AS MateriaId, 
                                              M.Nome AS MateriaNome
                                              FROM TBQuestao AS Q
		                                      INNER JOIN TBMateria AS M
		                                      ON Q.IdMateria = M.Id
                                              WHERE Q.IdMateria = {0}Id
		                                      ORDER BY Q.Id";

        private const string _entidadeExiste = @"SELECT CAST(
                                                 CASE WHEN EXISTS(
                                                  SELECT * FROM TBQuestao 
                                                   WHERE Enunciado LIKE {0}Enunciado AND Id <> {0}Id) 
                                                    THEN 1 
                                                     ELSE 0 
                                                   END
                                                   AS BIT) AS Exist";

        private const string _entidadeComDepencia = @"SELECT CAST(
                                                        CASE WHEN EXISTS(
                                                            SELECT QT.IdQuestao FROM TBQuestaoTeste AS QT 
                                                                WHERE QT.IdQuestao = {0}Id) 
                                                                 THEN 1 
                                                                ELSE 0 
                                                              END 
                                                        AS BIT) AS Exist";

        #endregion Scripts SQL 

        #region Scripts SQLTabela Intermediaria

        private const string _listagemPorTeste = @"SELECT  
                                                    Q.Id, 
                                                    Q.Enunciado,
	                                                Q.Bimestre, 
                                                    M.ID AS MateriaId, 
                                                    M.Nome AS MateriaNome
                                                    FROM TBQuestao AS Q
		                                             INNER JOIN TBMateria AS M
		                                                ON Q.IdMateria = M.ID
		                                             INNER JOIN TBQuestaoTeste AS QT
		                                                ON Q.Id = QT.IdQuestao
                                                    WHERE QT.IdTeste = {0}Id";

        #endregion Scripts SQL 

        private IRespostaRepository _repositorioResposta = IoCRepository.RepositorioResposta;

        public QuestaoRepositorySQL(TipoBancoDados tipo) : 
            base(tipo){
        }

        public override Questao Adicionar(Questao entidade)
        {
            entidade.Id = base.ExecutaOuAtualiza(_insercao, EntidadeParaLinha(entidade, false));

            foreach (Resposta resposta in entidade.Respostas)
            {
                resposta.Questao = entidade;
                _repositorioResposta.Adicionar(resposta);
            }

            return entidade;
        }

        public override Questao Atualizar(Questao entidade)
        {
            entidade.Id = base.ExecutaOuAtualiza(_atualizar, EntidadeParaLinha(entidade, true), false);

            foreach (Resposta resposta in entidade.Respostas)
            {
                if (resposta.Id > 0)
                    _repositorioResposta.Atualizar(resposta);
                else {
                    resposta.Questao = entidade;
                    _repositorioResposta.Adicionar(resposta);
                }
            }

            return entidade;
        }

        public override void Excluir(Questao entidade)
        {
            base.Excluir(_deletar, entidade.Id);
        }

        public override IList<Questao> Listagem()
        {

            IList<Questao> questoes = base.ExecutaPesquisaDeListagem(_listagem, LinhaParaEntidade);

            for(int i = 0; i < questoes.Count; i++)
            {
                Questao q = questoes[i];
                q.Respostas = (List<Resposta>)_repositorioResposta.ListagemPorQuestao(q);
                questoes[i] = q;
            }

            return questoes; 
        }

        public override Questao ProcuraPorId(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", id},
            };

            Questao questao = base.ExecutaPesquisa(_procuraPorId, LinhaParaEntidade, parametros);
            questao.Respostas = (List<Resposta>)_repositorioResposta.ListagemPorQuestao(questao);

            return questao;
        }

        public bool RegistroRepetido(Questao entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Enunciado", entidade.Enunciado},
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeExiste, parametros) == 1;
        }


        private Dictionary<string, object> EntidadeParaLinha(Questao entidade, bool hasId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Enunciado", entidade.Enunciado);
            parametros.Add("Bimestre", entidade.Bimestre);
            parametros.Add("IdMateria", entidade.Materia.Id);

            if (hasId)
                parametros.Add("Id", entidade.Id);

            return parametros;
        }

        public bool RegistroComDependecia(Questao entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", entidade.Id}
            };

            return base.Existe(_entidadeComDepencia, parametros) == 1;
        }

        public void DeletarResposta(Resposta entidade)
        {
            _repositorioResposta.Excluir(entidade);
        }

        public IList<Questao> ListagemPorMateria(Materia entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", entidade.Id},
            };

            IList<Questao> questoes = base.ExecutaPesquisaDeListagem(_listagemPorMateria, LinhaParaEntidade, parametros);

            for (int i = 0; i < questoes.Count; i++)
            {
                Questao q = questoes[i];
                q.Respostas = (List<Resposta>)_repositorioResposta.ListagemPorQuestao(q);
                questoes[i] = q;
            }

            return questoes;
        }

        public IList<Questao> ListagemPorTeste(Teste entidade)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", entidade.Id},
            };

            IList<Questao> questoes = base.ExecutaPesquisaDeListagem(_listagemPorTeste, LinhaParaEntidade, parametros);

            for (int i = 0; i < questoes.Count; i++)
            {
                Questao q = questoes[i];
                q.Respostas = (List<Resposta>)_repositorioResposta.ListagemPorQuestao(q);
                questoes[i] = q;
            }

            return questoes;
        }

        private static Func<IDataReader, Questao> LinhaParaEntidade = reader =>
         new Questao
         {
             Id = Convert.ToInt32(reader["Id"]),
             Enunciado = Convert.ToString(reader["Enunciado"]),
             Bimestre = Convert.ToString(reader["Bimestre"]),

             Materia = new Materia
             {
                 Id = Convert.ToInt32(reader["MateriaId"]),
                 Nome = Convert.ToString(reader["MateriaNome"])
             }
         };
    }
}
