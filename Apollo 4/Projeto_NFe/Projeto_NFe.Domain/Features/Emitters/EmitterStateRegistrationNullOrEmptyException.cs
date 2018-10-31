using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Emitters
{
    public class EmitterStateRegistrationNullOrEmptyException : BusinessException
    {
        public EmitterStateRegistrationNullOrEmptyException() : base("O Registro de Estado não pode ser nulo ou vazio!")
        {
        }
    }
}
