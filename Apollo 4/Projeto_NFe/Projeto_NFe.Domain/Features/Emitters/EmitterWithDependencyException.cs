using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Emitters
{
    public class EmitterWithDependencyException : BusinessException
    {
        public EmitterWithDependencyException() : base("O emitente nao pode ser deletado, pois tem uma dependência!")
        {
        }
    }
}
