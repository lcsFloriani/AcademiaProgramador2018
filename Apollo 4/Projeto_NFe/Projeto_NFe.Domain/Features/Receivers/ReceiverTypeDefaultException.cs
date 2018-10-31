using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Receivers
{
    public class ReceiverTypeDefaultException : BusinessException
    {
        public ReceiverTypeDefaultException() : base("O tipo é um campo obrigatório!")
        {

        }
    }
}
