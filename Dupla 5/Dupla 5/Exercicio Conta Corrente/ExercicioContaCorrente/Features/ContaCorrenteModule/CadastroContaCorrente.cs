using ExercicioContaCorrente.Domain;
using ExercicioContaCorrente.Infra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    public partial class CadastroContaCorrente : Form
    {
        private Conta conta;
        Cliente cliente = new Cliente();
        List<Cliente> ListaClientes;

        public CadastroContaCorrente(List<Cliente> clientes)
        {
            InitializeComponent();
            ListaClientes = clientes;

            cmbTitular.Items.Clear();

            foreach (var item in ListaClientes)
            {
                cmbTitular.Items.Add(item);
            }
        }
        public Conta NovaConta
        {
            get
            {
                return conta;
            }
            set
            {
                conta = value;

                txtId.Text = conta.id.ToString();
                txtNumero.Text = conta.numero.ToString();
                txtSaldo.Text = conta.saldo.ToString();
                txtLimite.Text = conta.limite.ToString();
                chkEspecial.Checked = conta.especial ? true : false;
                if(conta.cliente != null)
                    cmbTitular.Text = conta.cliente.ToString();
                if (conta.numero != 0)
                    txtNumero.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cliente = cmbTitular.SelectedItem as Cliente;
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            try
            {
                conta.numero = int.Parse(txtNumero.Text);
                conta.saldo = double.Parse(txtSaldo.Text);
                conta.especial = chkEspecial.Checked;
                conta.cliente = cmbTitular.SelectedItem as Cliente;

                conta.Valida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                DialogResult = DialogResult.None;
            }
        }
    }
}

