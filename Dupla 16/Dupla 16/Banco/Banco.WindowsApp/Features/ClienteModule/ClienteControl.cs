using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banco.Dominio;

namespace Banco.WindowsApp.Features.ClienteModule
{
    public partial class ClienteControl : UserControl
    {
        public ClienteControl()
        {
            InitializeComponent();
        }
        public void PopularListagemClientes(List<Cliente> contas)
        {
            listClientes.Items.Clear();

            foreach (Cliente c in contas)
            {
                listClientes.Items.Add(c);
            }
        }
        public Cliente TrazerCliente() {
            return (Cliente)listClientes.SelectedItem;
        }
    }
}
