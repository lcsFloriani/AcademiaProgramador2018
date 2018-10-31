using System.Collections.Generic;
using ProjetoLoterica.Dominio.Features.Concursos;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Infra.CSV.Features.Concursos;
using System;

namespace ProjetoLoterica.Aplicação.Features.Concursos
{
    public class ConcursoService : IConcursoService
    {
        private IConcursoRepository _concursoRepository;

        public ConcursoService(IConcursoRepository concursoRepository) => 
            _concursoRepository = concursoRepository;


        public Concurso Add(Concurso concurso)
        {
            concurso.Validar();
            return _concursoRepository.Add(concurso);
        }

        public void Delete(Concurso concurso) => _concursoRepository.Delete(concurso);

        public Concurso Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _concursoRepository.Get(id);
        }

        public IList<Concurso> GetAll() => _concursoRepository.GetAll();

        public Concurso Update(Concurso concurso)
        {
            concurso.Validar();
            return _concursoRepository.Update(concurso);
        }

        public void GerarCsv(IList<Concurso> concursos, string caminho)
        {
            if (concursos.Count == 0)
                throw new ListaConcursosVaziaException();
            
            ConcursoCsvRepository.SerializeCSV<Concurso>(concursos, caminho);
        }

        public IList<Concurso> GetAllConcursosFechados() => _concursoRepository.GetAllConcursosFechados();
        
        public Concurso UpdateSituacao(Concurso concurso) => _concursoRepository.UpdateSituacao(concurso);
    }
}
