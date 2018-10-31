using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Conveyors
{
    public class ConveyorAddressNullException : BusinessException
    {
        public ConveyorAddressNullException() : base("O endereço é um campo obrigatório!")
        {
        }
    }
}
