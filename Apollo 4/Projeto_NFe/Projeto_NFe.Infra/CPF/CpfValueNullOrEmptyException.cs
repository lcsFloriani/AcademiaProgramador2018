using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.CPF
{
    public class CpfValueNullOrEmptyException : CpfException
    {
        public CpfValueNullOrEmptyException() : base("CPF não pode ser nulo!")
        {
        }
    }
}
