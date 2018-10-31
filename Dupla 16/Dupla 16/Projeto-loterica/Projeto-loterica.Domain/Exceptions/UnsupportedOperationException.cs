using Projeto_loterica.Domain.Features.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Exceptions
{
    public class UnsupportedOperationException : DomainException
    {
        public UnsupportedOperationException() : base("Operação não suportada")
        {
        }
    }
}
