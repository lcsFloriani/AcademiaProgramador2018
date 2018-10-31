using ExercicioContaCorrente.Domain;
using ExercicioContaCorrente.Features.ClienteModule;
using ExercicioContaCorrente.Features.ContaCorrenteModule;
using ExercicioContaCorrente.Infra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioContaCorrente
{
    public partial class Principal : Form
    {
        private ContaCorrenteMem repositorioContas = new ContaCorrenteMem();
        private ClienteMem repositorioClientes = new ClienteMem();
        private GerenciadorFormulario _gerenciador;

        public ContaCorrenteGerenciadorFormulario _contaCorrenteGerenciador;
        public ClienteGerenciadorFormulario _clienteGerenciador;

        public Principal()
        {
            InitializeComponent();

            IniciaBotoes(false, false);

            Cliente clienteFake = new Cliente();
            clienteFake.id = 663;
            clienteFake.nome = "Joao";
            clienteFake.cpf = "123456";
            clienteFake.telefone = "32234456";
            clienteFake.email = "qwerty@asdfg";

            repositorioClientes.Insert(clienteFake);

            Conta contaFake = new Conta();
            contaFake.id = 66;
            contaFake.numero = 34567;
            contaFake.especial = true;
            contaFake.saldo = 500;
            contaFake.limite = 1000;
            contaFake.cliente = clienteFake;

            repositorioContas.Insert(contaFake);

            Conta contaFake2 = new Conta();
            contaFake2.id = 66;
            contaFake2.numero = 1234;
            contaFake2.especial = true;
            contaFake2.saldo = 500;
            contaFake2.limite = 1000;
            contaFake2.cliente = clienteFake;

            repositorioContas.Insert(contaFake2);
        }

        private void contasCorrentesMenuItem_Click(object sender, EventArgs e)
        {
            if (_contaCorrenteGerenciador == null)
                _contaCorrenteGerenciador = new ContaCorrenteGerenciadorFormulario(repositorioContas, repositorioClientes);
            
            CarregarCadastro(_contaCorrenteGerenciador);
        }


        private void clientesMenuItem_Click(object sender, EventArgs e)
        {
            if (_clienteGerenciador == null)
                _clienteGerenciador = new ClienteGerenciadorFormulario(repositorioClientes);

            CarregarCadastro(_clienteGerenciador);
        }

        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;

            labelTipoCadastro.Text = _gerenciador.ObtemTipoCadastro();

            AtualizaTituloBotoes();
            AtualizaEstadoBotoes();

            UserControl listagem = _gerenciador.CarregarListagem();

            listagem.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();
            panelControl.Controls.Add(listagem);
        }

        private void AtualizaEstadoBotoes()
        {
            EstadoBotoes estadoBotoes = _gerenciador.ObtemEstadoBotoes();

            btnCadastrar.Enabled = estadoBotoes.Adicionar;
            btnExcluir.Enabled = estadoBotoes.Excluir;
            btnAtualizar.Enabled = estadoBotoes.Atualizar;
            btnRealizarSaque.Enabled = estadoBotoes.Sacar;
            btnRealizarDeposito.Enabled = estadoBotoes.Depositar;
            btnTransferirPara.Enabled = estadoBotoes.Transferir;
            btnExibirExtrato.Enabled = estadoBotoes.Extrato;
        }

        private void AtualizaTituloBotoes()
        {
            TituloBotoes tituloBotoes = _gerenciador.ObtemTituloBotoes();

            btnCadastrar.Text = tituloBotoes.Adicionar;
            btnExcluir.Text = tituloBotoes.Excluir;
            btnAtualizar.Text = tituloBotoes.Atualizar;
            btnRealizarSaque.Text = tituloBotoes.Sacar;
            btnRealizarDeposito.Text = tituloBotoes.Depositar;
            btnTransferirPara.Text = tituloBotoes.Transferir;
            btnExibirExtrato.Text = tituloBotoes.Extrato;
        }

        private void IniciaBotoes(bool param1, bool param2)
        {
            btnCadastrar.Enabled = param1;
            btnExcluir.Enabled = param2;
            btnAtualizar.Enabled = param2;
            btnRealizarSaque.Enabled = param2;
            btnRealizarDeposito.Enabled = param2;
            btnTransferirPara.Enabled = param2;
            btnExibirExtrato.Enabled = param2;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_gerenciador != null)
            {
                _gerenciador.Remover();
            }
        }

        private void btnRealizarSaque_Click(object sender, EventArgs e)
        {
            if (_gerenciador != null)
            {
                _gerenciador.Sacar();
            }
        }

        private void btnExibirExtrato_Click(object sender, EventArgs e)
        {
            if (_gerenciador != null)
            {
                _gerenciador.Extrato();
            }
        }

        private void btnRealizarDeposito_Click(object sender, EventArgs e)
        {
            if (_gerenciador != null)
            {
                _gerenciador.Depositar();
            }
        }

        private void btnTransferirPara_Click(object sender, EventArgs e)
        {
            if (_gerenciador != null)
            {
                _gerenciador.Transferir();
            }
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            if (_gerenciador != null)
            {
                _gerenciador.Adicionar();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (_gerenciador != null)
            {
                _gerenciador.Atualizar();
            }
        }
    }
}
