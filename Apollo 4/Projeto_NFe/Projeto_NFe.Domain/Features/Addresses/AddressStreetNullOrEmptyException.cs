using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Addresses
{
    public class AddressStreetNullOrEmptyException : BusinessException
    {
        public AddressStreetNullOrEmptyException() : base("O logradouro não pode ser nulo!")
        {
        }
    }
}
