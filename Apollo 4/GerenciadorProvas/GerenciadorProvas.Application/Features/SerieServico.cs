using GerenciadorProvas.Dominio.Exceptions;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.Infra.Dados.IoC;
using GerenciadorProvas.Infra.Dados.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Aplicacao.Features.SerieServico
{
    public class SerieServico : Servico<Serie>, ISerieRepository
    {
        public SerieServico() : base(IoCRepository.RepositorioSerie)
        { }

        public new void Excluir(Serie entidade)
        {
            try
            {
                if (RegistroComDependecia(entidade))
                    throw new ValidacoesExcepection("Foi encontrada inconsistencia na Série, registro com dependência!");

                base.Excluir(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool RegistroComDependecia(Serie entidade)
        {
            var repositorio = _repositorio as ISerieRepository;
            return repositorio.RegistroComDependecia(entidade);
        }

        public bool RegistroRepetido(Serie entidade)
        {
            var repositorio = _repositorio as ISerieRepository;
            return repositorio.RegistroRepetido(entidade);
        }
    }
}
