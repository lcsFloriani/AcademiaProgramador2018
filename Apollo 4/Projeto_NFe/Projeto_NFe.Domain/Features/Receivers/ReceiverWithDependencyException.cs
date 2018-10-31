using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Receivers
{
    public class ReceiverWithDependencyException : BusinessException
    {
        public ReceiverWithDependencyException() : base("O destinatário não pode ser deletado, pois tem uma dependência!")
        {
        }
    }
}
