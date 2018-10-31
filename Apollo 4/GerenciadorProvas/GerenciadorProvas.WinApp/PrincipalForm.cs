using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.infra.CSV;
using GerenciadorProvas.infra.CSV.Mapper;
using GerenciadorProvas.infra.XML;
using GerenciadorProvas.WinApp.Features;
using GerenciadorProvas.WinApp.Features.Core.Common;
using GerenciadorProvas.WinApp.Features.DisciplinaModulo;
using GerenciadorProvas.WinApp.Features.MateriaModulo;
using GerenciadorProvas.WinApp.Features.QuestaoModulo;
using GerenciadorProvas.WinApp.Features.SerieModulo;
using GerenciadorProvas.WinApp.Features.TesteModulo;
using System;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp
{
    public partial class PrincipalForm : Form
    {

        private readonly XMLUtil<Teste> exportarXML = new XMLUtil<Teste>();
        private readonly CSVUtil<Teste, TesteMap> exportarCSV = new CSVUtil<Teste, TesteMap>();

        private IGerenciadorFormulario _gerenciador;
        private DisciplinaGerenciadorFormulario _disciplinaGerenciadorFormulario;
        private SerieGerenciadorFormulario _serieGerenciadorFormulario;
        private MateriaGerenciadorFormulario _materiaGerenciadorFormulario;
        private QuestaoGerenciadorFormulario _questaoGerenciadorFormulario;
        private TesteGerenciadorFormulario _testeGerenciadorFormulario;
      

        public PrincipalForm()
        {
            InitializeComponent();

            _disciplinaGerenciadorFormulario = new DisciplinaGerenciadorFormulario();
            _serieGerenciadorFormulario = new SerieGerenciadorFormulario();

            _materiaGerenciadorFormulario = new MateriaGerenciadorFormulario(
                _disciplinaGerenciadorFormulario.ObterServico(),
                _serieGerenciadorFormulario.ObterServico());

            _questaoGerenciadorFormulario = new QuestaoGerenciadorFormulario(
                _disciplinaGerenciadorFormulario.ObterServico(),
                _serieGerenciadorFormulario.ObterServico(),
                _materiaGerenciadorFormulario.ObterServico()
                );

            _testeGerenciadorFormulario = new TesteGerenciadorFormulario(
                _disciplinaGerenciadorFormulario.ObterServico(),
                _materiaGerenciadorFormulario.ObterServico(),
                _questaoGerenciadorFormulario.ObterServico()
                );
        }

        private void disciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_disciplinaGerenciadorFormulario, "Disciplina");
        }

        private void CarregarCadastro(IGerenciadorFormulario gerenciador, string selecionado)
        {
            _gerenciador = gerenciador;

            UserControl listagem = _gerenciador.PegarControle();
            _gerenciador.CarregarListagem();

            EstadoBotoes estadoBotoes = _gerenciador.ObtemEstadoBotoes();
            TituloBotoes tituloBotoes = _gerenciador.ObtemTituloBotoes(selecionado);
            ModificarEstadoBotoes(estadoBotoes);
            ModificarTituloBotoes(tituloBotoes);

            listagem.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();
            _gerenciador.LimparItemSelecionado();

            panelControl.Controls.Add(listagem);

        }

        private void ModificarEstadoBotoes(EstadoBotoes estadoBotoes)
        {
            toolStripBtnSalvar.Enabled = estadoBotoes.Gravar;
            toolStripBtnEditar.Enabled = estadoBotoes.Editar;
            toolStripBtnExcluir.Enabled = estadoBotoes.Excluir;
            toolStripBtnGerar.Enabled = estadoBotoes.PDF;
            tsbCSV.Enabled = estadoBotoes.CSV;
            tsbXML.Enabled = estadoBotoes.XML;
        }

        private void ModificarTituloBotoes(TituloBotoes tituloBotoes)
        {
            toolStripBtnSalvar.Text = tituloBotoes.Gravar;
            toolStripBtnEditar.Text = tituloBotoes.Editar;
            toolStripBtnExcluir.Text = tituloBotoes.Excluir;
            toolStripBtnGerar.Text = tituloBotoes.PDF;
            toolStripBtnGerar.Text = tituloBotoes.PDF;
            tsbCSV.Text = tituloBotoes.CSV;
            tsbXML.Text = tituloBotoes.XML;
        }

        private void toolStripBtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Gravar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Editar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripBtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.ItemSelecionado();
                var message = MessageBox.Show("Deseja excluir esse registro?", "Atenção!", MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    _gerenciador.Excluir();
                    MessageBox.Show("Registro deletado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_materiaGerenciadorFormulario, "Matéria");
        }

        private void serieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_serieGerenciadorFormulario, "Série");

        }

        private void questaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_questaoGerenciadorFormulario, "Questão");
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_testeGerenciadorFormulario, "Teste");
        }

        private void toolStripBtnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.ItemSelecionado();
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "PDF(*.pdf)|*.pdf";
                dialog.Title = "Visualizar Teste";
                dialog.ShowDialog();

                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    ((TesteGerenciadorFormulario)_gerenciador).VisualizarPDF(dialog.FileName);
                    System.Diagnostics.Process.Start(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbCSV_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.ItemSelecionado();
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "CSV|*.csv";
                dialog.Title = "Salvar em CSV";
                dialog.ShowDialog();

                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    _gerenciador.ItemSelecionado();
                    var gerenciador = (TesteGerenciadorFormulario)_gerenciador;
                    var t = (Teste)gerenciador.ObterValor();
                    exportarCSV.Exportar(dialog.FileName, t);
                    System.Diagnostics.Process.Start(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbXML_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.ItemSelecionado();
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "XML-File | *.xml";
                dialog.Title = "Salvar em XML";
                dialog.ShowDialog();

                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    _gerenciador.ItemSelecionado();
                    var gerenciador = (TesteGerenciadorFormulario)_gerenciador;
                    var t = (Teste) gerenciador.ObterValor(); 
                    exportarXML.Exportar(t, dialog.FileName);
                    System.Diagnostics.Process.Start(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
