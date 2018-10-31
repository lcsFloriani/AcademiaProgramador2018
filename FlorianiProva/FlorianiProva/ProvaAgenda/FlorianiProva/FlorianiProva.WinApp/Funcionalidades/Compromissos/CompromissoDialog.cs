using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;
using FlorianiProva.Aplicacao;
using FlorianiProva.Dominio.Funcionalidades.Compromissos;
using FlorianiProva.Dominio.Funcionalidades.Contatos;
using FlorianiProva.Infra.Data;

namespace FlorianiProva.WinApp.Funcionalidades.Compromissos
{
    public partial class CompromissoDialog : Form
    {
        private CompromissoService _compromissoService;
        private ContatoRepository _contatoRepository;
        private Compromisso _compromisso;
        public CompromissoDialog(ContatoRepository contatoRepository, CompromissoService compromissoService, string titulo, string textoBotao, Compromisso compromisso = null)
        {
            InitializeComponent();
            _compromissoService = compromissoService;
            _contatoRepository = contatoRepository;
            Text = titulo;
            this.btnCadastrar.Text = textoBotao;
            NovoCompromisso = compromisso;
            PopularContatos();
            if (NovoCompromisso != null)
            {
                _compromisso.Contatos = _compromissoService.TrazerTodosContatosCompromissos(_compromisso);
                PopularEditar();
            }

        }
        private void PopularContatos()
        {
            lbContatos.Items.Clear();

            foreach (Contato item in _contatoRepository.TrazerTodos())
            {
                lbContatos.Items.Add(item);
            }
        }
        private void PopularEditar()
        {
            txtAssunto.Text = _compromisso.Assunto;
            txtLocal.Text = _compromisso.Local;
            dateTimeInicio.Value = _compromisso.Inicio;


            PopularSelecionados();



            if (_compromisso.Fim == SqlDateTime.MinValue.Value)
            {
                checkBox1.Checked = true;
                dateTimeFinal.Value = DateTime.Now.AddDays(1);
            }
            else
                dateTimeFinal.Value = _compromisso.Fim;
        }

        private void PopularSelecionados()
        {
            foreach (var item in _compromisso.Contatos)
            {
                var index = lbContatos.FindString(item.ToString());
                lbContatos.SetSelected(index, true);
            }
        }
        public Compromisso NovoCompromisso
        {
            get { return _compromisso; }
            set { _compromisso = value; } 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                lblfinal.Visible = false;
                dateTimeFinal.Visible = false;
            }
            else
            {
                lblfinal.Visible = true;
                dateTimeFinal.Visible = true;
            }

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NovoCompromisso != null)
                {
                    NovoCompromisso.Assunto = txtAssunto.Text.Trim();
                    NovoCompromisso.Local = txtLocal.Text.Trim();
                    NovoCompromisso.Contatos = lbContatos.SelectedItems.Cast<Contato>().ToList();
                    NovoCompromisso.Inicio = dateTimeInicio.Value;
                    if (checkBox1.Checked)
                        NovoCompromisso.Fim = SqlDateTime.MinValue.Value;
                    else
                        NovoCompromisso.Fim = dateTimeFinal.Value;
                    try
                    {
                        _compromissoService.Editar(NovoCompromisso);
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
                    NovoCompromisso = new Compromisso();
                    NovoCompromisso.Assunto = txtAssunto.Text.Trim();
                    NovoCompromisso.Local = txtLocal.Text.Trim();
                    NovoCompromisso.Contatos = lbContatos.SelectedItems.Cast<Contato>().ToList();
                    NovoCompromisso.Inicio = dateTimeInicio.Value;
                    if (checkBox1.Checked)
                        NovoCompromisso.Fim = SqlDateTime.MinValue.Value;

                    else
                        NovoCompromisso.Fim = dateTimeFinal.Value;
                    _compromissoService.Adicionar(NovoCompromisso);

                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Compromisso Adicionado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                NovoCompromisso = null;
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
