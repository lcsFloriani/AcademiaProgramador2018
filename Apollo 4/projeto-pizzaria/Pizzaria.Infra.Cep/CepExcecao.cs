using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Cep
{
    public class CepExcecao : Exception
    {
        public CepExcecao(string message) : base(message)
        {
        }
    }
}
