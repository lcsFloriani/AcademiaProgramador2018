using ProjetoLoterica.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Dominio.Features.Concursos
{
    public class ConcursoDataException : BusinessException
    {
        public ConcursoDataException() : base("Data não pode ser antes de hoje!")
        {
        }
    }
}
