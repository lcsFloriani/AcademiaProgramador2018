using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Domain.Exceptions
{
    public class PostMessageIsNullOrEmptyException : BusinessException
    {
        public PostMessageIsNullOrEmptyException() : base("A mensagem não pode ser vazia!")
        {
        }
    }
}
