using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Conveyors
{
    public class ConveyorFreightResponsibilityDefaultException : BusinessException
    {
        public ConveyorFreightResponsibilityDefaultException() : base("A responsabilidade do frete é um campo obrigatório!")
        {
        }
    }
}
