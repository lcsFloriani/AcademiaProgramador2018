using Banco.Dominio;
using Banco.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banco.WindowsApp.Features.ClienteModule;
using Banco.WindowsApp.Features.Compartilhado;

namespace Banco.WindowsApp.Features.ContaCorrenteModule
{
    public class ContaCorrenteGerenciadorFormulario : GerenciadorFormulario
    {
        private ContaCorrenteControl contaCorrenteControl;
        private ContaCorrenteMem _repositoryContas;
        private ClienteMem _repositoryClientes;
        public ContaCorrenteGerenciadorFormulario(ContaCorrenteMem repositorioContas, ClienteMem repositorioClientes) {
            _repositoryContas = repositorioContas;
            _repositoryClientes = repositorioClientes;
        }
        public override void Adicionar()
        {
            CadastroContaCorrenteDialog dialog = new CadastroContaCorrenteDialog(_repositoryClientes);
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                _repositoryContas.AdicionarConta(dialog.NovaConta);
                List<ContaCorrente> contas = _repositoryContas.TrazerContas();
                contaCorrenteControl.PopularListagemContasCorrentes(contas);
            }
        }

        public override UserControl CarregarListagem()
        {
            if(contaCorrenteControl == null)
                contaCorrenteControl = new ContaCorrenteControl();

            return contaCorrenteControl;
        }
        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Contas Correntes";
        }
        public void Sacar()
        {
            ContaCorrente contaSelecionada = contaCorrenteControl.ContaCorrenteSelecionada();

            ContaCorrenteSacarDepositarDialog dialog = new ContaCorrenteSacarDepositarDialog(contaSelecionada);
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                contaSelecionada.Sacar(dialog.ValorOperacao);
                List<ContaCorrente> contas = _repositoryContas.TrazerContas();
                contaCorrenteControl.PopularListagemContasCorrentes(contas);
            }
        }
        public void Depositar()
        {
            ContaCorrente contaSelecionada = contaCorrenteControl.ContaCorrenteSelecionada();

            ContaCorrenteSacarDepositarDialog dialog = new ContaCorrenteSacarDepositarDialog(contaSelecionada);
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                contaSelecionada.Depositar(dialog.ValorOperacao);
                List<ContaCorrente> contas = _repositoryContas.TrazerContas();
                contaCorrenteControl.PopularListagemContasCorrentes(contas);
            }
        }

        public override void Excluir()
        {
            ContaCorrente contaSelecionada = contaCorrenteControl.ContaCorrenteSelecionada();
            DialogResult resultado = MessageBox.Show("Excluir Conta",
               "Tem certeza que deseja excluir a conta " + contaSelecionada.Numero,
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                _repositoryContas.ExcluirConta(contaSelecionada);

                List<ContaCorrente> contas = _repositoryContas.TrazerContas();

                contaCorrenteControl.PopularListagemContasCorrentes(contas);
            }
        }

        public void Transferir()
        {
            List<ContaCorrente> contas = _repositoryContas.TrazerContas();
            ContaCorrente contaSelecionada = contaCorrenteControl.ContaCorrenteSelecionada();
            ContaCorrenteTransferenciaDialog dialog = new ContaCorrenteTransferenciaDialog(contas, contaSelecionada);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                contaSelecionada.TransferirPara(dialog.contaTransferencia, dialog.valor);
                contaCorrenteControl.PopularListagemContasCorrentes(contas);
            }
        }
        public void Extrato() {
            
            ContaCorrente contaSelecionada = contaCorrenteControl.ContaCorrenteSelecionada();
            string extrato = contaSelecionada.Extrato();
            ContaCorrenteExtratoDialog dialog = new ContaCorrenteExtratoDialog(contaSelecionada);
            DialogResult result = dialog.ShowDialog();
        }

        public override EstadoBotoes ObtemTipoBotoes()
        {
            return new EstadoBotoes
            {
                Cadastrar = true,
                Excluir = true,
                Deposito = true,
                Saque = true,
                Extrato = true,
                Transferencia = true
            };
        }
        public override TextoBotoes ObtemTextoBotoes()
        {
            return new TextoBotoes
            {
                Cadastrar = "Nova Conta",
                Excluir = "Excluir Conta"
            };
        }
    }
}
