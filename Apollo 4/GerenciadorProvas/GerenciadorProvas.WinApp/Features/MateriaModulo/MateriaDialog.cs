using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Aplicacao.Features.MateriaServico;
using GerenciadorProvas.Dominio.Exceptions;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.WinApp.Features.Core.Common;
using System;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features.MateriaModulo
{
    public partial class MateriaDialog : Form, ICadastroDialog<Materia>
    {

        private MateriaServico _service;
        private Materia _materia;

        public Materia Valor
        {
            get
            {
                if (_materia == null)
                    _materia = new Materia();

                _materia.Nome = txtNomeMateria.Text;
                _materia.Cadeira = cbxDisciplina.SelectedItem as Disciplina;
                _materia.Serie = cbxSerie.SelectedItem as Serie;

                return _materia;
            }
            set
            {
                _materia = value;
                txtNomeMateria.Text = _materia.Nome;
                cbxDisciplina.SelectedItem = _materia.Cadeira;
                cbxSerie.SelectedItem = _materia.Serie;
            }
        }

        public MateriaDialog(MateriaServico serviceMateria, Servico<Disciplina> serviceDisciplina, Servico<Serie> serviceSerie, string titulo)
        {
            InitializeComponent();

            _service = serviceMateria;

            Text = titulo;

            Init(serviceDisciplina, serviceSerie);

        }

        public void Init(Servico<Disciplina> serviceDisciplina, Servico<Serie> serviceSerie)
        {
            foreach (Serie s in serviceSerie.Listagem())
            {
                cbxSerie.Items.Add(s);
            }
            foreach (Disciplina d in serviceDisciplina.Listagem())
            {
                cbxDisciplina.Items.Add(d);
            }
          
            txtNomeMateria.Select();
        }

        public void Limpar()
        {
            _materia = null;
        }

        public void Validacoes()
        {
            if (_service.RegistroRepetido(Valor))
                throw new ValidacoesExcepection("Essa matéria já existe!");
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

        private void txtNomeMateria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxDisciplina.Focus();
            }
        }

        private void cbxDisciplina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxSerie.Focus();
            }
        }

        private void cbxSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGravar.PerformClick();
            }
        }

    }
}
