using Banco.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco.WindowsApp.Features.ContaCorrenteModule
{
    public partial class ContaCorrenteTransferenciaDialog : Form
    {
        ContaCorrente _contaSelecionada;
        List<ContaCorrente> _repositoryContas;
        public ContaCorrenteTransferenciaDialog(List<ContaCorrente> contas, ContaCorrente conta)
        {
            InitializeComponent();
            _contaSelecionada = conta;
            _repositoryContas = contas;
            lbltext.Text = "Conta Nº " + _contaSelecionada.Numero + "\nSaldo: R$" + _contaSelecionada.Saldo + "";
            carregarComboBox();


        }
        public void carregarComboBox() {
            cmbContasTransferencias.Items.Clear();
            foreach (ContaCorrente c in _repositoryContas)
            {
                if(c != _contaSelecionada)
                    cmbContasTransferencias.Items.Add(c);
            }
        }
        public ContaCorrente contaTransferencia
        {
            get
            {
                var conta = (ContaCorrente)cmbContasTransferencias.SelectedItem;
                return conta;
            }
        }
        public double valor {
            get
            {
                double val = Convert.ToDouble(txtValor.Text);
                return val;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ContaCorrenteTransferencia_Load(object sender, EventArgs e)
        {
            
        }
    }
}
