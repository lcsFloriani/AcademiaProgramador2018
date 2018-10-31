using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.CNPJ
{
    public class CnpjValueEqualToZeroException : CnpjException
    {
        public CnpjValueEqualToZeroException() : base("O CNPJ não pode ter o valor igual a 0!")
        {

        }
    }
}
