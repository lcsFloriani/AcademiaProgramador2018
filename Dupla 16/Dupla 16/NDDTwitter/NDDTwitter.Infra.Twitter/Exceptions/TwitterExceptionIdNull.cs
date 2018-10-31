using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Twitter.Exceptions
{
    public class TwitterExceptionIdNull : TwitterException
    {
        public TwitterExceptionIdNull() : base("Id inválido")
        {
        }
    }
}
