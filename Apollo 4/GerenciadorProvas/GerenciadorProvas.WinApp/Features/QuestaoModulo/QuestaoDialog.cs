using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Aplicacao.Features;
using GerenciadorProvas.Aplicacao.Features.DisciplinaServico;
using GerenciadorProvas.Aplicacao.Features.MateriaServico;
using GerenciadorProvas.Aplicacao.Features.QuestaoServico;
using GerenciadorProvas.Aplicacao.Features.SerieServico;
using GerenciadorProvas.Dominio.Exceptions;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.WinApp.Features.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features.QuestaoModulo
{
    public partial class QuestaoDialog : Form, ICadastroDialog<Questao>
    {
        private DisciplinaServico _servicoDisciplina;
        private SerieServico _servicoSerie;
        private MateriaServico _servicoMateria;
        private QuestaoServico _servico;

        private Questao _questao;
        private Resposta _resposta;
        public Questao Valor
        {
            get
            {
                if (_questao == null)
                    _questao = new Questao();

                _questao.Enunciado = rtxtEnunciado.Text;
                _questao.Materia = cmbMateria.SelectedItem as Materia;
                _questao.Bimestre = cmbBimestre.SelectedItem as string;
                _questao.Respostas = PegarListaDeResposta();

                return _questao;
            }

            set
            {
                _questao = value;
                rtxtEnunciado.Text = _questao.Enunciado;
                cmbMateria.SelectedItem = _questao.Materia;
                cmbBimestre.SelectedItem = _questao.Bimestre;
                listaRespostas.Items.AddRange(_questao.Respostas.ToArray());
            }
        }


        public QuestaoDialog(
            DisciplinaServico servicoDisciplina,
            SerieServico servicoSerie,
            MateriaServico servicoMateria,
            QuestaoServico servico)
        {

            InitializeComponent();
            _servicoDisciplina = servicoDisciplina;
            _servicoSerie = servicoSerie;
            _servicoMateria = servicoMateria;
            _servico = servico;
            Desativar();
            Inicializacao();
        }

        public QuestaoDialog(
            DisciplinaServico servicoDisciplina,
            SerieServico servicoSerie,
            MateriaServico servicoMateria,
            QuestaoServico servico,
            Questao questao)
        {
            InitializeComponent();
            _servicoDisciplina = servicoDisciplina;
            _servicoSerie = servicoSerie;
            _servicoMateria = servicoMateria;
            _servico = servico;
            Ativar();

            Inicializacao();

            cbxCerta.Enabled = false;

            foreach (Materia materia in servicoMateria.Listagem())
            {
                cmbMateria.Items.Add(materia);
            }

            Valor = questao;
        }

        public void Ativar()
        {
            cmbMateria.Enabled = true;
            cmbBimestre.Enabled = true;
            rtxtEnunciado.Enabled = true;
            richTxtDescricao.Enabled = true;
            listaRespostas.Enabled = true;
            btnAdicionarResposta.Enabled = true;
            btnExcluirResposta.Enabled = true;
            btnGravar.Enabled = true;
            cbxCerta.Enabled = true;

        }

        public void Desativar()
        {
            cmbMateria.Enabled = false;
            cmbBimestre.Enabled = false;
            rtxtEnunciado.Enabled = false;
            richTxtDescricao.Enabled = false;
            listaRespostas.Enabled = false;
            btnAdicionarResposta.Enabled = false;
            btnExcluirResposta.Enabled = false;
            btnGravar.Enabled = false;
            cbxCerta.Enabled = false;

        }

        public void Inicializacao()
        {
            foreach (Disciplina disciplina in _servicoDisciplina.Listagem())
            {
                cmbDisciplina.Items.Add(disciplina);
            }
            foreach (Serie serie in _servicoSerie.Listagem())
            {
                cmbSerie.Items.Add(serie);
            }

            cmbBimestre.Items.Add(BimestreType.Primeiro);
            cmbBimestre.Items.Add(BimestreType.Segundo);
            cmbBimestre.Items.Add(BimestreType.Terceiro);
            cmbBimestre.Items.Add(BimestreType.Quarto);
        }

        public void Limpar()
        {
            _questao = null;
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

        private List<Resposta> PegarListaDeResposta()
        {

            List<Resposta> respostas = new List<Resposta>();

            for (int i = 0; i < listaRespostas.Items.Count; i++)
            {
                Resposta m = listaRespostas.Items[i] as Resposta;
                respostas.Add(m);
            }

            return respostas;
        }


        public void Validacoes()
        {
            if (_servico.RegistroRepetido(Valor)) {
                throw new ValidacoesExcepection("Questão repetida.");
            }
        }

        public void AdicionarResposta(List<Resposta> respostas)
        {
            if (Resposta.VerificarRespostaRepetida(respostas, _resposta))
            {
                MessageBox.Show("Não é permitido respostas iguais!");
            }
            else
            {
                int index = respostas.IndexOf(_resposta);

                if (index == -1 && respostas.Count > 4)
                {
                    richTxtDescricao.Text = "";
                    MessageBox.Show("Não é permitido adicionar mais de 5 respostas.");
                }
                else
                {
                    if (index > -1)
                        respostas[index] = _resposta;
                    else
                    {
                        int i = respostas.Count;
                        _resposta.AtribuirLetra(i);
                        respostas.Add(_resposta);
                    }

                    richTxtDescricao.Text = null;
                    cbxCerta.Checked = false;
                    _resposta = null;

                    listaRespostas.Items.Clear();
                    listaRespostas.Items.AddRange(respostas.ToArray());
                }
            }

        }

        public void ExcluirResposta(List<Resposta> respostas)
        {

            for (int i = 0; i < respostas.Count; i++)
                if (_resposta.Letra.Equals(respostas[i].Letra))
                    respostas.RemoveAt(i);

            for (int i = 0; i < respostas.Count; i++)
                respostas[i].AtribuirLetra(i);

            listaRespostas.Items.Clear();
            listaRespostas.Items.AddRange(respostas.ToArray());

            if (_resposta.Certa)
            {
                cbxCerta.Enabled = true;
                cbxCerta.Checked = false;
            }

            richTxtDescricao.Text = "";

            _resposta = null;

        }



        private void btnGravar_Click(object sender, EventArgs e)
        {
            SalvarOuAtualizar();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Disciplina d = cmbDisciplina.SelectedItem as Disciplina;
            Serie s = cmbSerie.SelectedItem as Serie;
            if (d != null && s != null)
            {
                var servico = ((MateriaServico)_servicoMateria);
                List<Materia> materias = (List<Materia>)servico.ProcurarMateriaPorDisciplinaSerie(d, s);
                cmbMateria.Items.Clear();
                if (materias == null || materias.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado nenhuma matéria para essa disciplina e série.");
                }
                else
                {
                    foreach (Materia m in materias)
                    {
                        cmbMateria.Items.Add(m);
                    }
                    Ativar();
                }
            }
            else
            {
                MessageBox.Show("É obrigatório selecionar uma disciplina e uma série.");
            }
        }

        private void btnAdicionarResposta_Click(object sender, EventArgs e)
        {
            try
            {
                if(_resposta == null)
                     _resposta = new Resposta();
                _resposta.Descricao = richTxtDescricao.Text;
                _resposta.Certa = cbxCerta.Checked;

              
                

                if(cbxCerta.Checked)
                {
                    cbxCerta.Enabled = false;
                }

                _resposta.Validacoes();

                List<Resposta> respostas = PegarListaDeResposta();

                AdicionarResposta(respostas);
            }
            catch (ValidacoesExcepection ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExcluirResposta_Click(object sender, EventArgs e)
        {
            try
            {
                if (_resposta == null)
                    MessageBox.Show("Selecione uma resposta!");
                else
                {
                    var message = MessageBox.Show("Deseja excluir essa resposta?", "Atenção!", MessageBoxButtons.YesNo);

                    if (message == DialogResult.Yes)
                    {
                        if (_resposta.Id > 0)
                        {
                            _servico.DeletarResposta(_resposta);
                        }

                        List<Resposta> respostas = PegarListaDeResposta();

                        ExcluirResposta(respostas);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void listaRespostas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listaRespostas.SelectedItem != null)
            {
                _resposta = listaRespostas.SelectedItem as Resposta;

                richTxtDescricao.Text = _resposta.Descricao;
                cbxCerta.Checked = _resposta.Certa;
            }
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cbxCerta_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
