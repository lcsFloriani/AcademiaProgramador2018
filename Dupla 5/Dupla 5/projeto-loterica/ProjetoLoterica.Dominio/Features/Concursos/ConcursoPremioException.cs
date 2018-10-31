using ProjetoLoterica.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Dominio.Features.Concursos
{
    public class ConcursoPremioException : BusinessException
    {
        public ConcursoPremioException() : base("Premio não pode ser menor que zero!")
        {
        }
    }
}
