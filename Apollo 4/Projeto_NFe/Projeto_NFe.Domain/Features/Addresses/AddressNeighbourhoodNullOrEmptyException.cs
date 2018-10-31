using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Addresses
{
    public class AddressNeighbourhoodNullOrEmptyException : BusinessException
    {
        public AddressNeighbourhoodNullOrEmptyException() : base("O bairro não pode ser nulo!")
        {
        }
    }
}
