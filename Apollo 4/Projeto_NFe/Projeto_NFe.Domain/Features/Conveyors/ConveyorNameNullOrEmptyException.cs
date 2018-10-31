using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Conveyors
{
    public class ConveyorNameNullOrEmptyException : BusinessException
    {
        public ConveyorNameNullOrEmptyException() : base("O nome é um campo obrigatório!")
        {
        }
    }
}
