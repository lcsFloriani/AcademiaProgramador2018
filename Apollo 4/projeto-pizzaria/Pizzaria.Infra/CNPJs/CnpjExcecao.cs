using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CNPJs
{
    public class CnpjExcecao : Exception
    {
        public CnpjExcecao(string message) : base(message)
        {

        } 
    }
}
