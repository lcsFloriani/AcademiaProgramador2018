using GerenciadorProvas.Domain;
using GerenciadorProvas.Domain.Modal;
using GerenciadorProvas.Infra.Data.Core;
using GerenciadorProvas.Infra.Data.DAO;
using GerenciadorProvas.Infra.Data.DAO.DisciplinaImpl;
using GerenciadorProvas.Infra.Data.DAO.FuncionarioImpl;
using GerenciadorProvas.Infra.Data.DAO.MateriaImpl;
using GerenciadorProvas.Infra.Data.DAO.QuestaoImpl;
using GerenciadorProvas.Infra.Data.DAO.RepostaImpl;
using GerenciadorProvas.Infra.Data.DAO.SerieImpl;
using GerenciadorProvas.Infra.Data.DAO.TesteImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Infra.IoC
{
    public class IoCRepository
    {

        public static DisciplinaDAO RepositorioDisciplina { get;  internal set; }
        public static SerieDAO RepositorioSerie { get; internal set; }
        public static MateriaDAO RepositorioMateria { get; internal set; }
        public static QuestaoDAO RepositorioQuestao { get; internal set; }
        public static RespostaDAO RepositorioResposta { get; internal set; }

        public static TesteDAO RepositorioTeste { get; internal set; }
        public static FuncionarioDAO  RepositorioFuncionario { get; internal set; }

        static IoCRepository()
        {
            var type =  DatabaseType.SQL_SERVER;

            RepositorioDisciplina = new DisciplinaDAO(type);
            RepositorioSerie = new SerieDAO(type);
            RepositorioMateria = new MateriaDAO(type);
            RepositorioQuestao = new QuestaoDAO(type);
            RepositorioResposta = new RespostaDAO(type);
            RepositorioTeste = new TesteDAO(type);
            RepositorioFuncionario = new FuncionarioDAO(type);
        }
    }
}
