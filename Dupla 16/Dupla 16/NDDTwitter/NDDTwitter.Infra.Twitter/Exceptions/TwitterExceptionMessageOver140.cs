using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Twitter.Exceptions
{
    public class TwitterExceptionMessageOver140 : TwitterException
    {
        public TwitterExceptionMessageOver140() : base("Tweet não pode ter mais de 140 caracteres")
        {
        }
    }
}
