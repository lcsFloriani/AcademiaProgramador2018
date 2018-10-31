using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Exceptions
{
    public class TurmaInvalidaException : BusinessException
    {
        public TurmaInvalidaException() : base("Turma nula ou inválida")
        {
        }
    }
}
