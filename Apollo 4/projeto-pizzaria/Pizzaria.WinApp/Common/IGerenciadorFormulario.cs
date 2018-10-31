using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Common
{
    public interface IGerenciadorFormulario
    {
        void Gravar();
        void Editar();
        void Excluir();
        void Filtrar();
        void CarregarListagem();
        UserControl PegarControle();
        EstadoBotoes ObtemEstadoBotoes();
        TituloBotoes ObtemTituloBotoes(string selecionado);
        void ItemSelecionado();
        void LimparItemSelecionado();
    }
}
