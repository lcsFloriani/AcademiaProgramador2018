using GerenciadorProvas.Dominio.Enums;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.infra;
using GerenciadorProvas.Infra.Dados.IoC;
using GerenciadorProvas.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Infra.Dados.SQL.TesteRepositorySQL
{
    public class TesteRepositorySQL : SQLRepository<Teste>, ITesteQuestaoSQL
    {
        #region Scripts SQL

        private const string _insercao =
                            @"INSERT INTO TBTeste
                               (Titulo,
                                NumeroQuestoes,
                                DataGeracao,
                                IdMateria)
                            VALUES (
                                {0}Titulo,
                                {0}NumeroQuestoes,
                                {0}DataGeracao,
                                {0}IdMateria)";

        private const string _listagem = @"SELECT 
                                                T.Id, 
                                                T.Titulo, 
                                                T.NumeroQuestoes, 
                                                T.DataGeracao, 
                                                M.Id AS MateriaId, 
                                                M.Nome AS MateriaNome,
                                                D.Id AS DisciplinaId,    
                                                D.Nome AS DisciplinaNome,
                                                S.Id AS SerieId,    
                                                S.Grau AS SerieGrau
                                           FROM TBTeste AS T 
                                           INNER JOIN TBMateria AS M ON T.IdMateria = M.Id
                                           INNER JOIN TBDisciplina AS D ON M.IdDisciplina = D.Id
                                           INNER JOIN TBSerie AS S ON M.IdSerie = S.Id
                                           ORDER BY Id";

        private const string _procuraPorId =
                                            @"SELECT 
                                                T.Id, 
                                                T.Titulo, 
                                                T.NumeroQuestoes, 
                                                T.DataGeracao, 
                                                M.Id AS MateriaId, 
                                                M.Nome AS MateriaNome
                                                D.Id AS DisciplinaId,    
                                                D.Nome AS DisciplinaNome
                                           FROM TBTeste AS T 
                                           INNER JOIN TBMateria AS M ON T.IdMateria = M.Id
                                           INNER JOIN TBDisciplina AS D ON M.IdDisciplina = D.Id
                                           WHERE T.Id = {0}Id
                                           ORDER BY Id";

        private readonly string _atualizar =
                           @"UPDATE TBTeste
                           SET 
                               Titulo = {0}Titulo,
                               NumeroQuestoes = {1}NumeroQuestoes,
                               Cadeira = {2}Cadeira,
                               {0}IdMateria
                           WHERE Id = {0}Id";

        private const string _deletar = @"DELETE FROM TBTeste WHERE Id = {0}Id";



        #endregion Scripts SQL  

        #region Scripts SQLTabela Intermediaria

        private const string _insercaoNaTabelaIntermediaria =
                            @"INSERT INTO TBQuestaoTeste
                               (IdTeste,
                                IdQuestao)
                            VALUES (
                                {0}IdTeste,
                                {0}IdQuestao
                                )";

        #endregion Script SQLTabela Intermediaria

        private readonly IQuestaoTesteSQL _repositorioQuestao = IoCRepository.RepositorioQuestao as IQuestaoTesteSQL;

        public TesteRepositorySQL(TipoBancoDados tipo) :
            base(tipo)
        {
        }

        public override Teste Adicionar(Teste entidade)
        {
            entidade.Id = ExecutaOuAtualiza(_insercao, EntidadeParaLinha(entidade, false));

            foreach (Questao q in entidade.GerarQuestoesAleatorias())
                AdicionarNaTabelaIntermediaria(entidade, q);

            return entidade;
        }

        public override Teste Atualizar(Teste entidade)
        {
            throw new NotImplementedException();
        }

        public override void Excluir(Teste entidade)
        {
            base.Excluir(_deletar, entidade.Id);
        }

        public override IList<Teste> Listagem()
        {
            IList<Teste> lista = base.ExecutaPesquisaDeListagem(_listagem, LinhaParaEntidade);

            for (int i = 0; i < lista.Count; i++)
            {
                Teste t = lista[i];
                lista[i].Questoes = (List<Questao>)_repositorioQuestao.ListagemPorTeste(t);
            }

            return lista;
        }

        public override Teste ProcuraPorId(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"Id", id},
            };

            Teste t = base.ExecutaPesquisa(_procuraPorId, LinhaParaEntidade, parametros);
            t.Questoes = (List<Questao>)_repositorioQuestao.ListagemPorTeste(t);

            return t;
        }

        private Dictionary<string, object> EntidadeParaLinha(Teste entidade, bool hasId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Titulo", entidade.Titulo);
            parametros.Add("NumeroQuestoes", entidade.NumeroQuestoes);
            parametros.Add("DataGeracao", entidade.DataGeracao);
            parametros.Add("IdMateria", entidade.Cadeira.Id);


            if (hasId)
                parametros.Add("Id", entidade.Id);

            return parametros;
        }

        private Dictionary<string, object> EntidadeParaLinhaTableIntermediaria(Teste teste, Questao questao)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("IdTeste", teste.Id);
            parametros.Add("IdQuestao", questao.Id);

            return parametros;
        }

        public void AdicionarNaTabelaIntermediaria(Teste teste, Questao questao)
        {
            ExecutaOuAtualiza(_insercaoNaTabelaIntermediaria, EntidadeParaLinhaTableIntermediaria(teste, questao));
        }

        private static Func<IDataReader, Teste> LinhaParaEntidade = reader =>
          new Teste
          {
              Id = Convert.ToInt32(reader["Id"]),
              Titulo = Convert.ToString(reader["Titulo"]),
              NumeroQuestoes = Convert.ToInt32(reader["NumeroQuestoes"]),
              DataGeracao = Convert.ToDateTime(reader["DataGeracao"]),

              Cadeira = new Materia
              {
                  Id = Convert.ToInt32(reader["MateriaId"]),
                  Nome = Convert.ToString(reader["MateriaNome"]),
                  Cadeira = new Disciplina
                  {
                      Id = Convert.ToInt32(reader["DisciplinaId"]),
                      Nome = Convert.ToString(reader["DisciplinaNome"]),
                  },

                  Serie = new Serie
                  {
                      Id = Convert.ToInt32(reader["SerieId"]),
                      Grau = Convert.ToInt32(reader["SerieGrau"])
                  }
              }
          };
    }
}
