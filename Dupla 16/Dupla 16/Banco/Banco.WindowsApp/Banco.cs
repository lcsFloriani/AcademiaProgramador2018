using Banco.Dominio;
using Banco.Infra.Data;
using Banco.WindowsApp.Features.ClienteModule;
using Banco.WindowsApp.Features.Compartilhado;
using Banco.WindowsApp.Features.ContaCorrenteModule;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Banco.WindowsApp
{
    public partial class Banco : Form
    {
        public ContaCorrenteMem _repositoryContas = new ContaCorrenteMem();
        public ClienteMem _repositoryCliente = new ClienteMem();

        private GerenciadorFormulario _gerenciador;

        private ContaCorrenteGerenciadorFormulario gerenciadorConta;
        private ClienteGerenciadorFormulario gerenciadorCliente;

        public Banco()
        {
            InitializeComponent();
        }      

        private void contaCorrenteMenuItem_Click(object sender, EventArgs e)
        {          

            if (gerenciadorConta == null)
                gerenciadorConta = new ContaCorrenteGerenciadorFormulario(_repositoryContas, _repositoryCliente);

                CarregarCadastro(gerenciadorConta);


        }
        private void clienteMenuItem_Click(object sender, EventArgs e)
        {
            if (gerenciadorCliente == null)
                gerenciadorCliente = new ClienteGerenciadorFormulario(_repositoryCliente);

            CarregarCadastro(gerenciadorCliente);
        }

        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {

            _gerenciador = gerenciador;

            labelTipoCadastro.Text = _gerenciador.ObtemTipoCadastro();

            UserControl listagem = _gerenciador.CarregarListagem();

            listagem.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();

            panelControl.Controls.Add(listagem);

            TipoBotoes(_gerenciador);
            TextoBotoes(_gerenciador);
        }
        void TipoBotoes(GerenciadorFormulario gerenciador) {
            EstadoBotoes _gerenciadorTipoBotao = gerenciador.ObtemTipoBotoes();
            tSCadastrar.Enabled = _gerenciadorTipoBotao.Cadastrar;
            tSDeposito.Enabled = _gerenciadorTipoBotao.Deposito;
            tSSaque.Enabled = _gerenciadorTipoBotao.Saque;
            tSExcluir.Enabled = _gerenciadorTipoBotao.Excluir;
            tSTransferencia.Enabled = _gerenciadorTipoBotao.Transferencia;
            tSExtrato.Enabled = _gerenciadorTipoBotao.Extrato;
        }
        void TextoBotoes(GerenciadorFormulario gerenciador) {
            TextoBotoes _gerenciadorTextoBotoes = gerenciador.ObtemTextoBotoes();
            tSCadastrar.Text = _gerenciadorTextoBotoes.Cadastrar;
            tSExcluir.Text = _gerenciadorTextoBotoes.Excluir;
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            _gerenciador.Adicionar();
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tSSaque_Click(object sender, EventArgs e)
        {
            gerenciadorConta.Sacar();
        }

        private void tSDeposito_Click(object sender, EventArgs e)
        {
            gerenciadorConta.Depositar();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            _gerenciador.Excluir();
        }

        private void tSTransferencia_Click(object sender, EventArgs e)
        {
            gerenciadorConta.Transferir();
        }

        private void tSExtrato_Click(object sender, EventArgs e)
        {
            gerenciadorConta.Extrato();
        }

    }
}
