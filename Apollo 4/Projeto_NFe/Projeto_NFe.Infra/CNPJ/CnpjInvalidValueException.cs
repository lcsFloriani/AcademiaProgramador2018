using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.CNPJ
{
    public class CnpjInvalidValueException : CnpjException
    {
        public CnpjInvalidValueException() : base("CNPJ inválido!")
        {
        }
    }
}
