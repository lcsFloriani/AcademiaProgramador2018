using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Receivers
{
    public class ReceiverNameNullOrEmptyException : BusinessException
    {
        public ReceiverNameNullOrEmptyException() : base("O nome não pode ser nulo!")
        {
        }
    }
}
