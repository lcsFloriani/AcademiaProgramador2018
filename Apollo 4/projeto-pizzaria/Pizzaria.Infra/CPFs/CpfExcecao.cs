using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfExcecao : Exception
    {
        public CpfExcecao(String message) : base(message)
        {
        
        }
    }
}
