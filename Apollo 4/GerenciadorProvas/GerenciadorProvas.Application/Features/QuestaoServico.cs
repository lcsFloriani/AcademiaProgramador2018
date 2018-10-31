using GerenciadorProvas.Dominio.Exceptions;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.Infra.Dados.SQL.QuestaoRepositorySQL;
using GerenciadorProvas.Infra.Dados.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Aplicacao.Features.QuestaoServico
{
    public class QuestaoServico : Servico<Questao>, IQuestaoRepository
    {
        public QuestaoServico() : base(IoCRepository.RepositorioQuestao)
        {}

        public new void Excluir(Questao entidade)
        {
            try
            {
                if (RegistroComDependecia(entidade))
                    throw new ValidacoesExcepection("Foi encontrada inconsistencia na Questão, registro com dependência!");

                base.Excluir(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeletarResposta(Resposta entidade)
        {
            var repositorio = _repositorio as IQuestaoRepository;
            repositorio.DeletarResposta(entidade);
        }

        public IList<Questao> ListagemPorMateria(Materia entidade)
        {
            var repositorio = _repositorio as IQuestaoRepository;
            return repositorio.ListagemPorMateria(entidade);
        }

        public bool RegistroComDependecia(Questao entidade)
        {
            var repositorio = _repositorio as IQuestaoRepository;
            return repositorio.RegistroComDependecia(entidade);
        }

        public bool RegistroRepetido(Questao entidade)
        {
            var repositorio = _repositorio as IQuestaoRepository;
            return repositorio.RegistroRepetido(entidade);
        }
    }
}
