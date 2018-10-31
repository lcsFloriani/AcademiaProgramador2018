using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfValorMenorQueOnzeExcecao : CpfExcecao
    {
        public CpfValorMenorQueOnzeExcecao() : base("O CPF não pode ter menos de 11 digitos!")
        {
        }
    }
}
