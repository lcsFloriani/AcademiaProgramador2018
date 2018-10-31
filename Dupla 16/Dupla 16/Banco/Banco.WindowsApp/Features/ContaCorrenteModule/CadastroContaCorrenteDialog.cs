using Banco.Dominio;
using Banco.Infra.Data;
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
    public partial class CadastroContaCorrenteDialog : Form
    {
        List<Cliente> _repositoryClientes;
        public CadastroContaCorrenteDialog(ClienteMem _repositorioClientes)
        {
            InitializeComponent();

            _repositoryClientes = _repositorioClientes.TrazerClientes();
            CarregarCMBTitular();
        }
        void CarregarCMBTitular() {
            cmbTitular.Items.Clear();
            foreach (var c in _repositoryClientes)
            {
                cmbTitular.Items.Add(c);
            }

        }
        public ContaCorrente NovaConta
        {
            get
            {
                var conta = new ContaCorrente();
                conta.Titular = (Cliente)cmbTitular.SelectedItem;
                conta.Numero = int.Parse(txtNumero.Text);
                conta.Saldo = double.Parse(txtSaldo.Text);
                conta.Limite = double.Parse(txtLimite.Text);
                conta.Especial = chkEspecial.Checked;
                return conta;
            }
        }
        public const string exNumero = @"^\d+(\,\d{1,2})?$";
        public const string exDoub = @"^-?(?:0|[1-9][0-9]*)\.?[0-9]+([e|E][+-]?[0-9]+)?$";
        private void txtNumero_Leave(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            
            var valido = System.Text.RegularExpressions.Regex.IsMatch(txt.Text.Trim(), exNumero);

            if (!valido)
            {
                MessageBox.Show("Número inválido!");
                txt.Focus();
            }
        }

        private void txtSaldo_Leave(object sender, EventArgs e)
        {
            var txt = sender as TextBox;

            var valido = System.Text.RegularExpressions.Regex.IsMatch(txt.Text.Trim(), exDoub);

            if (!valido)
            {
                MessageBox.Show("Saldo Invalido!");
                txt.Focus();
            }
        }

        private void txtLimite_Leave(object sender, EventArgs e)
        {
            var txt = sender as TextBox;

            var valido = System.Text.RegularExpressions.Regex.IsMatch(txt.Text.Trim(), exDoub);

            if (!valido)
            {
                MessageBox.Show("Limite Invalido!");
                txt.Focus();
            }
        }
    }
}
