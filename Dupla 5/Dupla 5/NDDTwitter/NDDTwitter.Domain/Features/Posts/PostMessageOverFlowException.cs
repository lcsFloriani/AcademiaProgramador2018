using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Domain.Exceptions
{
    public class PostMessageOverFlowException : BusinessException
    {
        public PostMessageOverFlowException() : base("A mensagem não pode conter mais que 140 caracteres!")
        {
        }
    }
}
