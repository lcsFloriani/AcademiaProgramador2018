using Projeto_loterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Application.Interfaces
{
    public interface IConcursoService : IService<Concurso>
    {
        Concurso GerarResultado(Concurso objeto);
    }
}
