using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfValorOverFlowExcecao : CpfExcecao
    {
        public CpfValorOverFlowExcecao() : base("O CPF não pode ser maior que 11 digitos!")
        {
        }
    }
}
