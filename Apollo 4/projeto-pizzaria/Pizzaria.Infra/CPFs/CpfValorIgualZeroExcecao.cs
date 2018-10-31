using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfValorIgualZeroExcecao : CpfExcecao
    {
        public CpfValorIgualZeroExcecao() : base("O CPF não pode ter o valor igual a 0!")
        {

        }
    }
}
