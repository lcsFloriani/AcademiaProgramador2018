using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Domain.Exceptions
{
    public class MessageNulaOuVaziaException : BusinessException
    {
        public MessageNulaOuVaziaException() : base("A mensagem não pode estar vazia")
        {
        }
    }
}
