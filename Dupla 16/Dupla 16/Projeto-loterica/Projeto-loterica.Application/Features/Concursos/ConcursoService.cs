using Projeto_loterica.Application.Interfaces;
using Projeto_loterica.Domain.Features.Concursos;
using Projeto_loterica.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Application.Features.Concursos
{
    public class ConcursoService : IConcursoService
    {
        IConcursoRepository _concursoRepository;
        public ConcursoService(IConcursoRepository concursoRepository)
        {
            _concursoRepository = concursoRepository;
        }
        public Concurso Add(Concurso objeto)
        {
            objeto.Validar();
            return _concursoRepository.Add(objeto);
        }

        public void Delete(Concurso objeto)
        {
            Validador.ValidateId(objeto.Id);
            _concursoRepository.Delete(objeto);
        }

        public Concurso GerarResultado(Concurso objeto)
        {
            objeto.GerarResultado(new Random());
            _concursoRepository.Update(objeto);
            return objeto;
        }

        public IEnumerable<Concurso> GetAll()
        {
            var list = _concursoRepository.GetAll();
            foreach (var item in list)
            {
                Validador.ValidateId(item.Id);
            }
            return list;
        }

        public Concurso GetById(long Id)
        {
            Validador.ValidateId(Id);
            var item = _concursoRepository.GetById(Id);
            Validador.ValidateId(item.Id);
            return item;
        }

        public Concurso Update(Concurso objeto)
        {
            objeto.Validar();
            Validador.ValidateId(objeto.Id);
            var item = _concursoRepository.Update(objeto);
            Validador.ValidateId(item.Id);
            return item;
        }
    }
}
