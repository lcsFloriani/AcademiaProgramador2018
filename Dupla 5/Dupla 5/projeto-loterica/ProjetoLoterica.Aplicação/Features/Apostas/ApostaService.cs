using System.Collections.Generic;
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Concursos;

namespace ProjetoLoterica.Aplicação.Features.Apostas
{
    public class ApostaService : IApostaService
    {
        private IApostaRepository _apostaRepository;

        public ApostaService(IApostaRepository apostaRepository) => _apostaRepository = apostaRepository;
        
        public Aposta Add(Aposta aposta)
        {
            if (aposta.Id <= 0)
                throw new IdentifierUndefinedException();

            aposta.Validar();

            return _apostaRepository.Add(aposta);
        }

        public void Delete(Aposta aposta)
        {
            if (aposta.Id <= 0)
                throw new IdentifierUndefinedException();

            _apostaRepository.Delete(aposta);
        }

        public Aposta Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _apostaRepository.Get(id);
        }

        public IList<Aposta> GetAll() => _apostaRepository.GetAll();

        public IList<Aposta> GetApostasComBolao(long id) => _apostaRepository.GetApostasComBolao(id);
        

        public Concurso GetConcurso(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _apostaRepository.GetConcurso(id);
        }

        public Aposta Update(Aposta aposta)
        {
            if (aposta.Id <= 0)
                throw new IdentifierUndefinedException();

            aposta.Validar();

            return _apostaRepository.Update(aposta);
        }
    }
}