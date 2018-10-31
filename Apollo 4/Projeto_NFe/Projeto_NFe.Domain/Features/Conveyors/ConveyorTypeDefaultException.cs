using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Conveyors
{
    public class ConveyorTypeDefaultException : BusinessException
    {
        public ConveyorTypeDefaultException() : base("O tipo é um campo obrigatório!")
        {
        }
    }
}
