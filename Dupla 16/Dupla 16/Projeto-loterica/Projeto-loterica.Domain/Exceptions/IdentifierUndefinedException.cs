using Projeto_loterica.Domain.Features.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Exceptions
{
    public class IdentifierUndefinedException : DomainException
    {
        public IdentifierUndefinedException() : base("Tem que existir um ID valido")
        {
        }
    }
}
