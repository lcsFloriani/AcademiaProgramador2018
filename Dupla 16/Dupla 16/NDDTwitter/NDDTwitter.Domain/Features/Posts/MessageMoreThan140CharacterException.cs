using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Domain.Exceptions
{
    public class MessageMoreThan140CharacterException : BusinessException
    {
        public MessageMoreThan140CharacterException() : base("A mensagem não ser maior que 140 caracteres")
        {
        }
    }
}
