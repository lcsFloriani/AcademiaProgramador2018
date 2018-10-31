using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Twitter.Exceptions
{
    public class TwitterException : Exception
    {
        public TwitterException(string message) : base(message)
        {

        }
    }
}
    