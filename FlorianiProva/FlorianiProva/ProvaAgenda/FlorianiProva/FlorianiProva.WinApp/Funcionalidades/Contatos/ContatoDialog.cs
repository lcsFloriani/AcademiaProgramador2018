using FlorianiProva.Aplicacao;
using FlorianiProva.Dominio.Funcionalidades.Contatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorianiProva.WinApp.Funcionalidades.Contatos
{
    public partial class ContatoDialog : Form
    {
        private Contato _contato;
        private ContatoService _contatoService;

        public Contato NovoContato
        {
            get { return _contato; }
            set
            {
                _contato = value;               
            }
        }
        private void popularEditar()
        {
            txtNome.Text = _contato.Nome;
            txtEmail.Text = _contato.Email;
            txtDepartamento.Text = _contato.Departamento;
            txtEndereco.Text = _contato.Endereco;
            txtTelefone.Text = _contato.Telefone;
        }
        public ContatoDialog(ContatoService contatoService, string titulo, string btnName, Contato contatoSelecionado = null)
        {
            InitializeComponent();

            NovoContato = contatoSelecionado;
            _contatoService = contatoService;
            this.Text = titulo;
            btnCadastrar.Text = btnName;
            if (NovoContato != null)
                popularEditar();
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NovoContato != null)
                {
                    NovoContato.Nome = txtNome.Text.Trim();
                    NovoContato.Email = txtEmail.Text.Trim();
                    NovoContato.Departamento = txtDepartamento.Text.Trim();
                    NovoContato.Endereco = txtEndereco.Text.Trim();
                    NovoContato.Telefone = txtTelefone.Text.Trim();
                    try
                    {
                        _contatoService.Editar(NovoContato);
                        DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        DialogResult = DialogResult.None;
                        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    NovoContato = new Contato();
                    NovoContato.Nome = txtNome.Text.Trim();
                    NovoContato.Email = txtEmail.Text.Trim();
                    NovoContato.Departamento = txtDepartamento.Text.Trim();
                    NovoContato.Endereco = txtEndereco.Text.Trim();
                    NovoContato.Telefone = txtTelefone.Text.Trim();

                    _contatoService.Adicionar(NovoContato);

                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Contato Adicionado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                NovoContato = null;
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
