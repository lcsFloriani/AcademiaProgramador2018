using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.CNPJ
{
    public class CnpjException : Exception
    {
        public CnpjException(string message) : base(message)
        {

        } 
    }
}
