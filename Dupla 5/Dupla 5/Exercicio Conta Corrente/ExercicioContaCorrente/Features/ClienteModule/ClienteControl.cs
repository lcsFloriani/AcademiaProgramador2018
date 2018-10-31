using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExercicioContaCorrente.Domain;

namespace ExercicioContaCorrente.Features.ClienteModule
{
    public partial class ClienteControl : UserControl
    {
        public ClienteControl()
        {
            InitializeComponent();
        }

        public void PopularListagemClientes(List<Cliente> clientes)
        {
            listClientes.Items.Clear();

            foreach (Cliente c in clientes)
            {
                listClientes.Items.Add(c);
            }
        }

        public Cliente GetCliente()
        {
            return listClientes.SelectedItem as Cliente;
        }
    }
}
