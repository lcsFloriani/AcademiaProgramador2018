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

namespace Banco.WindowsApp.Features.ContaCorrenteModule
{
    public partial class ContaCorrenteControl : UserControl
    {
        public ContaCorrenteControl()
        {
            InitializeComponent();
        }
        public void PopularListagemContasCorrentes(List<ContaCorrente> contas)
        {
            ListContasCorrente.Items.Clear();

            foreach (ContaCorrente c in contas)
            {
                ListContasCorrente.Items.Add(c);
            }
        }

        public ContaCorrente ContaCorrenteSelecionada() {
            return (ContaCorrente) ListContasCorrente.SelectedItem;
        }

        private void ListContasCorrente_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
