using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CNPJs
{
    public class CnpjValorIgualZeroExcecao : CnpjExcecao
    {
        public CnpjValorIgualZeroExcecao() : base("O CNPJ não pode ter o valor igual a 0!")
        {

        }
    }
}
