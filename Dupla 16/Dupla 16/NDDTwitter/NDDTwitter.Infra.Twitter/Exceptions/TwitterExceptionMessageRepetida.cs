using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Twitter.Exceptions
{
    public class TwitterExceptionMessageRepetida : TwitterException
    {
        public TwitterExceptionMessageRepetida() : base("Tweet não pode ser repetido")
        {
        }
    }
}
