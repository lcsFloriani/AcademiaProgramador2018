using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Twitter.Exceptions
{
    public class TwitterExceptionMessageNull : TwitterException
    {
        public TwitterExceptionMessageNull() : base("Tweet não pode ser vazio")
        {
        }
    }
}
