using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Aplicacao.Features;
using GerenciadorProvas.Aplicacao.Features.SerieServico;
using GerenciadorProvas.Dominio.Exceptions;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.WinApp.Features.Core.Common;
using System;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features.SerieModulo
{
    public partial class SerieDialog : Form, ICadastroDialog<Serie>
    {
        private SerieServico _service;
        private Serie _serie;

        public Serie Valor
        {
            get
            {
                if (_serie == null)
                    _serie = new Serie();

                _serie.Grau = Convert.ToInt32(Math.Round(numericUpDownGrau.Value, 0));
                return _serie;
            }
            set
            {
                _serie = value;
                numericUpDownGrau.Value = _serie.Grau;
            }
        }


        public SerieDialog(SerieServico service, string titulo)
        {
            InitializeComponent();
            _service = service;
            Text = titulo;
        }


        public void Limpar()
        {
            _serie = null;
        }

        public void Validacoes()
        {
           if( _service.RegistroRepetido(Valor))
                throw new ValidacoesExcepection("Essa série já existe!");
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            SalvarOuAtualizar();
        }

        private void numericUpDownGrau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGravar.PerformClick();
            }
        }
    }
}
