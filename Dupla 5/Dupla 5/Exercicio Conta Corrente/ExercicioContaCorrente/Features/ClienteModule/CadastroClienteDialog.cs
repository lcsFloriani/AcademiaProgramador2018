using ExercicioContaCorrente.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioContaCorrente.Features.ClienteModule
{
    public partial class CadastroClienteDialog : Form
    {
        private Cliente cliente;

        public CadastroClienteDialog()
        {
            InitializeComponent();
        }

        public Cliente NovoCliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;

                txtId.Text = cliente.id.ToString();
                txtCpf.Text = cliente.cpf;
                txtNome.Text = cliente.nome;
                txtTelefone.Text = cliente.telefone;
                txtEmail.Text = cliente.email;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente.cpf = txtCpf.Text;
                cliente.nome = txtNome.Text;
                cliente.telefone = txtTelefone.Text;
                cliente.email = txtEmail.Text;

                cliente.Valida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                DialogResult = DialogResult.None;
            }
        }
    }
}
