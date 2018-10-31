using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CNPJs
{
    public class CnpjValorOverFlowExcecao : CnpjExcecao
    {
        public CnpjValorOverFlowExcecao() : base("O CNPJ não pode ser maior que 14 digitos!")
        {
        }
    }
}
