using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Aplicacao.Features.DisciplinaServico;
using GerenciadorProvas.Aplicacao.Features.MateriaServico;
using GerenciadorProvas.Aplicacao.Features.QuestaoServico;
using GerenciadorProvas.Aplicacao.Features.TesteServico;
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

namespace GerenciadorProvas.WinApp.Features.TesteModulo
{
    public partial class TesteDialog : Form, ICadastroDialog<Teste>
    {
        private Teste _teste;
        private TesteServico _service;
        private MateriaServico _serviceMateria;
        private QuestaoServico _serviceQuestao;
        private List<Questao> questoes;

        public Teste Valor
        {
            get
            {
                if (_teste == null)
                    _teste = new Teste();

                _teste.Titulo = rbTxtTitle.Text;
                _teste.Cadeira = cbxMateria.SelectedItem as Materia;
                _teste.NumeroQuestoes = Convert.ToInt32(Math.Round(nudNumeroQuestoes.Value, 0));
                _teste.DataGeracao = DateTime.Now;
                _teste.Questoes = questoes;

                return _teste;
            }
            set
            {
                _teste = value;

                rbTxtTitle.Text = _teste.Titulo;
                cbxMateria.SelectedItem = _teste.Cadeira;
                nudNumeroQuestoes.Value = _teste.NumeroQuestoes;

            }
        }
        public TesteDialog(
            DisciplinaServico serviceDisciplina, 
            MateriaServico serviceMateria,
            QuestaoServico serviceQuestao,
            TesteServico serviceTeste, 
            string titulo)
        {
            InitializeComponent();

            _service = serviceTeste;
            _serviceMateria = serviceMateria;
            _serviceQuestao = serviceQuestao;

            labelDateTime.Text = DateTime.Now.ToShortDateString();
            cbxDisciplina.Items.AddRange(serviceDisciplina.Listagem().ToArray());
        }
        
        
        public void Limpar()
        {
            _teste = null;
        }

        public void SalvarOuAtualizar()
        {
            try
            {
                Validacoes();
                Valor.Validacoes();
            }
            catch (ValidacoesExcepection ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        public void Validacoes()
        {
            if (cbxDisciplina.SelectedItem == null)
                throw new ValidacoesExcepection("O campo disciplina é obrigatório!");


            if (cbxMateria.SelectedItem == null)
                throw new ValidacoesExcepection("O campo matéria é obrigatório!");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            SalvarOuAtualizar();
        }

        private void cbxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Disciplina selecao = cbxDisciplina.SelectedItem as Disciplina;

            List<Materia> disciplinas = (List<Materia>) _serviceMateria.ProcurarMateriaPorDisciplina(selecao);
            cbxMateria.Items.Clear();

            if (disciplinas != null || disciplinas.Count > 0) 
                cbxMateria.Items.AddRange(disciplinas.ToArray());
            
            else
            {
                MessageBox.Show("Não foi encontrado nenhuma matéria para essa disciplina.");
            }

            cbxMateria.Text = "";
        }

        private void cbxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selecao = cbxMateria.SelectedItem as Materia;

            if (selecao != null)
            {
                questoes = new List<Questao>();
                questoes = (List<Questao>)_serviceQuestao.ListagemPorMateria(selecao);
            }
        }
    }
}
