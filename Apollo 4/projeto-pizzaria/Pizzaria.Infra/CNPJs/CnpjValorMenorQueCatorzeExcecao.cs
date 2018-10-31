using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CNPJs
{
    public class CnpjValorMenorQueCatorzeExcecao : CnpjExcecao
    {
        public CnpjValorMenorQueCatorzeExcecao() : base("O CNPJ não pode ter menos de 14 digitos!")
        {
        }
    }
}
