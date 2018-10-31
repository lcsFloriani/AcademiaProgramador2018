using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features.Core.Common
{
    public interface IGerenciadorFormulario
    {

        void Gravar();

        void Editar();

        void Excluir();

        void CarregarListagem();

        UserControl PegarControle();

        EstadoBotoes ObtemEstadoBotoes();

        TituloBotoes ObtemTituloBotoes(string selecionado);

        void ItemSelecionado();

        void LimparItemSelecionado();
    }
}
