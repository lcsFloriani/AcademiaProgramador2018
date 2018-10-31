using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlorianiProva.Aplicacao;
using FlorianiProva.Infra.Data;
using FlorianiProva.WinApp.Funcionalidades.Contatos;
using FlorianiProva.WinApp.Funcionalidades;
using FlorianiProva.WinApp.Funcionalidades.Compromissos;

namespace FlorianiProva.WinApp
{
    public partial class Principal : Form
    {
        private static ContatoRepository _contatoRepository;
        private static CompromissoRepository _compromissoRepository;

        private static ContatoService _contatoService;
        private static CompromissoService _compromissoService;

        private GerenciadorFormulario _gerenciador;
        private ContatoGerenciadorFormulario _contatoGerenciador;
        private CompromissoGerenciadorFormulario _compromissoGerenciador;
        public Principal()
        {
            InitializeComponent();
            _contatoRepository = new ContatoRepository();
            _compromissoRepository = new CompromissoRepository();
            _contatoService = new ContatoService(_contatoRepository);
            _compromissoService = new CompromissoService(_compromissoRepository);

        }

        private void cadastroMenuItem_Click(object sender, EventArgs e)
        {
            

            
        }
        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;

            lblStatus.Text = _gerenciador.ObtemTipoCadastro();

            UserControl listagem = _gerenciador.CarregarListagem();

            listagem.Dock = DockStyle.Fill;

            panel.Controls.Clear();

            panel.Controls.Add(listagem);

            _gerenciador.AtualizarLista();

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Adicionar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Excluir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contatoMenuItem_Click(object sender, EventArgs e)
        {
            if (_contatoGerenciador == null)
                _contatoGerenciador = new ContatoGerenciadorFormulario(_contatoService);

            CarregarCadastro(_contatoGerenciador);
        }

        private void compromissoMenuItem_Click(object sender, EventArgs e)
        {
            if (_compromissoGerenciador == null)
                _compromissoGerenciador = new CompromissoGerenciadorFormulario(_compromissoService, _contatoRepository);

            CarregarCadastro(_compromissoGerenciador);
        }
    }
}
