using Banco.WindowsApp.Features.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco.WindowsApp
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();
        public abstract void Excluir();
        public abstract UserControl CarregarListagem();
        public abstract string ObtemTipoCadastro();

        public abstract EstadoBotoes ObtemTipoBotoes();
        public abstract TextoBotoes ObtemTextoBotoes();

    }
}
