using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Addresses
{
    public class AddressCityNullOrEmptyException : BusinessException
    {
        public AddressCityNullOrEmptyException() : base("A cidade não pode ser nulo!")
        {
        }
    }
}
