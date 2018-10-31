using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class CpfInvalidValueException : CpfExcecao
    {
        public CpfInvalidValueException() : base("CPF inválido!")
        {
        }
    }
}
