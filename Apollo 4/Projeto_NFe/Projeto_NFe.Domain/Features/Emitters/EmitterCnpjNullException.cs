using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Emitters
{
    public class EmitterCnpjNullException : BusinessException
    {
        public EmitterCnpjNullException() : base("O CNPJ não pode ser nulo!")
        {
        }
    }
}
