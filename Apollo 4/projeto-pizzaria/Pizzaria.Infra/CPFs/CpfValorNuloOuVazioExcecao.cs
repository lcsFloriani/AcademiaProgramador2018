using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfValorNuloOuVazioExcecao : CpfExcecao
    {
        public CpfValorNuloOuVazioExcecao() : base("CPF não pode ser nulo!")
        {
        }
    }
}
