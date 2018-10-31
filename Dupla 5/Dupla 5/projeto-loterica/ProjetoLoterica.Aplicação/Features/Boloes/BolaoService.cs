using System.Collections.Generic;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Boloes;
using ProjetoLoterica.Dominio.Features.Concursos;

namespace ProjetoLoterica.Aplicação.Features.Boloes
{
    public class BolaoService : IBolaoService
    {
        private IBolaoRepository _bolaoRepository;
        private IApostaRepository _apostaRepository;
        
        public BolaoService(IBolaoRepository bolaoRepository, IApostaRepository apostaRepository)
        {
            _bolaoRepository = bolaoRepository;
            _apostaRepository = apostaRepository;
        }

        public Bolao Add(Bolao bolao)
        {
            bolao.Validar();

            return _bolaoRepository.Add(bolao);
        }

        public void Delete(Bolao bolao)
        {
            if (bolao.Id <= 0)
                throw new IdentifierUndefinedException();

            IList<Aposta> apostas = _apostaRepository.GetApostasComBolao(bolao.Id);

            if (apostas.Count == 0)
                _bolaoRepository.Delete(bolao);
            else
                throw new BolaoComApostasException();
        }

        public Bolao Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _bolaoRepository.Get(1);
        }

        public IList<Bolao> GetAll() => _bolaoRepository.GetAll();

        public Bolao Update(Bolao bolao) => throw new BolaoUpdateException();

        public void GerarBolao(Bolao bolao, Concurso concurso, int numeroApostas)
        {
            var apostas = bolao.GerarApostas(concurso, numeroApostas);
            foreach (var item in apostas)
            {
                _apostaRepository.Add(item);
            }
        }
    }
}
