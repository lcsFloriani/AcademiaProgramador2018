using GerenciadorProvas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.Dominio.Exceptions;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Infra.Dados.IoC;

namespace GerenciadorProvas.Aplicacao.Features.DisciplinaServico
{
    public class DisciplinaServico : Servico<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaServico() : base(IoCRepository.RepositorioDisciplina)
        { }


        public new void Excluir(Disciplina entidade)
        {
            try
            {
                if (RegistroComDependecia(entidade))
                    throw new ValidacoesExcepection("Foi encontrada inconsistencia na Disciplina, registro com dependência!");

                base.Excluir(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool RegistroComDependecia(Disciplina entidade)
        {
            var repositorio = _repositorio as IDisciplinaRepository;
            return repositorio.RegistroComDependecia(entidade);
        }

        public bool RegistroRepetido(Disciplina entidade)
        {
            var repositorio = _repositorio as IDisciplinaRepository;
            return repositorio.RegistroRepetido(entidade); ;
        }
    }
}
