using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FlorianiProva.WinApp.Funcionalidades
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();

        public abstract UserControl CarregarListagem();

        public abstract string ObtemTipoCadastro();

        public abstract void Excluir();

        public abstract void Editar();

        public abstract void AtualizarLista();
    }
}
