using Pizzaria.Domain.Features.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Pedidos
{
    public partial class PedidoFiltroDialog : Form
    {
        private string _telefone;

        public string Valor {
            get
            {
                return _telefone;
            }
        }

        public PedidoFiltroDialog()
        {
            InitializeComponent();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            _telefone = txtTelefone.Text;

            if (string.IsNullOrEmpty(Valor))
                throw new PedidoTelefoneProcuraNuloOuVazioExcecao();
        }

    }
}
