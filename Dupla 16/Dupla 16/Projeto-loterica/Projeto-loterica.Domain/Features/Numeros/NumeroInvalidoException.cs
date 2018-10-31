using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Features.Exceptions
{
    public class NumeroInvalidoException : DomainException
    {
        public NumeroInvalidoException() : base("Numero deve estar entre 1 e 60")
        {
        }
    }
}
