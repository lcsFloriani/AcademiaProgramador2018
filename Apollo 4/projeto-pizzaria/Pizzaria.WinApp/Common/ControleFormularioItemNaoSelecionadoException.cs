using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.WinApp.Common
{
    public class ControleFormularioItemNaoSelecionadoException : ControleFormularioException
    {
        public ControleFormularioItemNaoSelecionadoException() : base("Selecione um registro para realizar essa operação!")
        {
        }
    }
}
