using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.AccessKeys
{
    public class AccessKeyException : Exception
    {
        public AccessKeyException(string message) : base(message)
        {

        }
    }
}
