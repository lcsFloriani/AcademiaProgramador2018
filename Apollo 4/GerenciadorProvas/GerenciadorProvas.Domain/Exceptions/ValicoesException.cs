using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Exceptions
{
    public class ValidacoesExcepection : ApplicationException
    {
        public ValidacoesExcepection(string message) : base(message)
        {

        }
    }
}
