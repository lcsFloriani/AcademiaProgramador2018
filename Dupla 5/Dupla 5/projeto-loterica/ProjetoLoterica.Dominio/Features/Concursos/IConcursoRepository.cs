using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Dominio.Features.Concursos
{
    public interface IConcursoRepository
    {
        Concurso Add(Concurso concurso);
        Concurso Update(Concurso concurso);
        Concurso Get(long id);
        IList<Concurso> GetAll();
        IList<Concurso> GetAllConcursosFechados();
        void Delete(Concurso concurso);
        Concurso UpdateSituacao(Concurso concurso);
    }
}
