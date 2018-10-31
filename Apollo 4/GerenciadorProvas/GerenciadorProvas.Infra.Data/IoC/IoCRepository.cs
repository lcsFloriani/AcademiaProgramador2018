using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.infra;
using GerenciadorProvas.Infra.Dados.SQL.QuestaoRepositorySQL;
using GerenciadorProvas.Infra.Dados.SQL.DisciplinaRepositorySQL;
using GerenciadorProvas.Infra.Dados.SQL.MateriaRepositorySQL;
using GerenciadorProvas.Infra.Dados.SQL.RespostaRepositorySQL;
using GerenciadorProvas.Infra.Dados.SQL.SerieRepositorySQL;
using GerenciadorProvas.Infra.Dados.SQL.TesteRepositorySQL;

namespace GerenciadorProvas.Infra.Dados.IoC
{
    public class IoCRepository
    {

        public static IDisciplinaRepository RepositorioDisciplina { get;  internal set; }
        public static ISerieRepository RepositorioSerie { get; internal set; }
        public static IMateriaRepository RepositorioMateria { get; internal set; }
        public static IQuestaoRepository RepositorioQuestao { get; internal set; }
        public static IRespostaRepository RepositorioResposta { get; internal set; }
        public static IRepository<Teste> RepositorioTeste { get; internal set; }

        static IoCRepository()
        {
            RepositorioDisciplina = new DisciplinaRepositorySQL(SingletonTipoBanco.Instancia);
            RepositorioSerie = new SerieRepositorySQL(SingletonTipoBanco.Instancia);
            RepositorioMateria = new MateriaRepositorySQL(SingletonTipoBanco.Instancia);
            RepositorioResposta = new RespostaRepositorySQL(SingletonTipoBanco.Instancia);
            RepositorioQuestao = new QuestaoRepositorySQL(SingletonTipoBanco.Instancia);
            RepositorioTeste = new TesteRepositorySQL(SingletonTipoBanco.Instancia);
        }
    }
}
