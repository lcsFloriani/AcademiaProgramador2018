using GerenciadorProvas.Aplicacao.Features.DisciplinaServico;
using GerenciadorProvas.Dominio.Exceptions;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.WinApp.Features.Core.Common;
using System;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.DisciplinaModulo
{
    public partial class DisciplinaDialog : Form, ICadastroDialog<Disciplina>
    {
        private DisciplinaServico _service;
        private Disciplina _disciplina;
        public Disciplina Valor
        {
            get
            {
                if (_disciplina == null)
                    _disciplina = new Disciplina();

                _disciplina.Nome = txtNomeDisciplina.Text;
                return _disciplina;
            }
            set
            {
                _disciplina = value;
                txtNomeDisciplina.Text = _disciplina.Nome;
            }
        }

        public DisciplinaDialog(DisciplinaServico service, string titulo)
        {
            InitializeComponent();
            _service = service;
            Text = titulo;
        }


        public void Limpar()
        {
            _disciplina = null;
        }

        public  void Validacoes()
        {
            if (_service.RegistroRepetido(Valor))
            {
                throw new ValidacoesExcepection("Essa disciplina já existe!");
            }
        }

        public void SalvarOuAtualizar()
        {
            try
            {
          
                Valor.Validacoes();
                Validacoes();

            }
            catch (ValidacoesExcepection ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCadastrarDisciplina_Click(object sender, EventArgs e)
        {
            SalvarOuAtualizar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }

        private void txtNomeDisciplina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGravar.PerformClick();
            }
        }

  
    }
}
