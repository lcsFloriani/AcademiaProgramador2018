using ProjetoLoterica.Dominio.Features.Concursos;
using System.Collections.Generic;

namespace ProjetoLoterica.Aplicação.Features.Concursos
{
    public interface IConcursoService
    {
        Concurso Add(Concurso concurso);
        Concurso Update(Concurso concurso);
        Concurso Get(long id);
        IList<Concurso> GetAll();
        IList<Concurso> GetAllConcursosFechados();
        void Delete(Concurso concurso);
        void GerarCsv(IList<Concurso> concursos, string caminho);
        Concurso UpdateSituacao(Concurso concurso);
    }
}
