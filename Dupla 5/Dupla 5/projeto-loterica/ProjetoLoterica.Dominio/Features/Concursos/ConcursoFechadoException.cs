using ProjetoLoterica.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Dominio.Features.Concursos
{
    public class ConcursoFechadoException : BusinessException
    {
        public ConcursoFechadoException() : base("Você não pode apostar em um concurso fechado!")
        {
        }
    }
}
