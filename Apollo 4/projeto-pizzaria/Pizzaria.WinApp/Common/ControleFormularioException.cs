using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.WinApp.Common
{
    public class ControleFormularioException : Exception
    {
        public ControleFormularioException(string message) : base(message)
        {
        }
    }
}
