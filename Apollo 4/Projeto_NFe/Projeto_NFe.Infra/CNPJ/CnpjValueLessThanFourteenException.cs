using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.CNPJ
{
    public class CnpjValueLessThanFourteenException : CnpjException
    {
        public CnpjValueLessThanFourteenException() : base("O CNPJ não pode ter menos de 14 digitos!")
        {
        }
    }
}
