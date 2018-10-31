using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.CPF
{
    public class CpfValueOverFlowException : CpfException
    {
        public CpfValueOverFlowException() : base("O CPF não pode ser maior que 11 digitos!")
        {
        }
    }
}
