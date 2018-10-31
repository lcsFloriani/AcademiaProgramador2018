using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Features.Exceptions
{
    public class ApostaInvalidaException : DomainException
    {
        public ApostaInvalidaException() : base("Aposta deve ter 6 numeros")
        {
        }
    }
}
