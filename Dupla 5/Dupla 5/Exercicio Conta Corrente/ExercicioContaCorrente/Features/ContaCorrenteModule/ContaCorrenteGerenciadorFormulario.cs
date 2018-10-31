using ExercicioContaCorrente.Domain;
using ExercicioContaCorrente.Infra.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    public class ContaCorrenteGerenciadorFormulario : GerenciadorFormulario
    {
        private readonly ContaCorrenteMem _repositorioContas;
        private readonly ClienteMem _repositorioClientes;

        private ContaCorrenteControl contaCorrenteControl;

        public ContaCorrenteGerenciadorFormulario(ContaCorrenteMem repositorioContas, ClienteMem repositorioClientes)
        {
            _repositorioContas = repositorioContas;
            _repositorioClientes = repositorioClientes;
        }
        public override void Adicionar()
        {

            List<Cliente> list = new List<Cliente>();
            list = _repositorioClientes.GetAll();

            CadastroContaCorrente dialog = new CadastroContaCorrente(list);
            dialog.NovaConta = new Conta();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _repositorioContas.Insert(dialog.NovaConta);

                List<Conta> contas = _repositorioContas.GetAll();

                contaCorrenteControl.PopularListagemContasCorrentes(contas);
            }
        }

        public override void Atualizar()
        {
            Conta contaSelecionada = contaCorrenteControl.GetConta();

            if (contaSelecionada != null)
            {
                List<Cliente> list = new List<Cliente>();
                list = _repositorioClientes.GetAll();

                CadastroContaCorrente dialog = new CadastroContaCorrente(list);

                dialog.NovaConta = contaSelecionada;
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _repositorioContas.Update(dialog.NovaConta);

                    List<Conta> contas = _repositorioContas.GetAll();

                    contaCorrenteControl.PopularListagemContasCorrentes(contas);
                }
            }

        }

        public override void Remover()
        {
            Conta contaSelecionada = contaCorrenteControl.GetConta();

            if (contaSelecionada != null)
            {
                var resultado = MessageBox.Show("Deseja realmente excluir?", "Confirmar Exclusão", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    _repositorioContas.Delete(contaSelecionada);

                    List<Conta> contas = _repositorioContas.GetAll();
                    contaCorrenteControl.PopularListagemContasCorrentes(contas);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma conta");
            }
        }

        public override void Sacar()
        {
            Conta contaSelecionada = contaCorrenteControl.GetConta();

            if (contaSelecionada != null)
            {
                SacarDepositarContaCorrente dialog = new SacarDepositarContaCorrente();
                dialog.Operacao = "Saque";
                dialog.NovoSaque = contaSelecionada;

                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _repositorioContas.Update(dialog.NovoSaque);

                    CarregarListagem();
                }

            }
        }

        public override void Depositar()
        {
            Conta contaSelecionada = contaCorrenteControl.GetConta();

            if (contaSelecionada != null)
            {
                SacarDepositarContaCorrente dialog = new SacarDepositarContaCorrente();
                dialog.Operacao = "Depósito";
                dialog.NovoSaque = contaSelecionada;

                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _repositorioContas.Update(dialog.NovoSaque);

                    CarregarListagem();
                }

            }
        }

        public override void Transferir()
        {
            Conta contaSelecionada = contaCorrenteControl.GetConta();

            if (contaSelecionada != null)
            {
                TransferirContaCorrente dialog = new TransferirContaCorrente(contaSelecionada);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _repositorioContas.Update(dialog.ContaOrigem);
                    _repositorioContas.Update(dialog.ContaDestino);

                    CarregarListagem();
                }

            }
        }

        public override void Extrato()
        {
            Conta contaSelecionada = contaCorrenteControl.GetConta();

            if (contaSelecionada != null)
            {
                ExtratoContaCorrente dialog = new ExtratoContaCorrente(contaSelecionada);
                DialogResult resultado = dialog.ShowDialog();
            }
        }
        

        public override UserControl CarregarListagem()
        {
            if (contaCorrenteControl == null)
                contaCorrenteControl = new ContaCorrenteControl();

            List<Conta> contas = _repositorioContas.GetAll();

            contaCorrenteControl.PopularListagemContasCorrentes(contas);

            return contaCorrenteControl;
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Contas Correntes";
        }

        public override TituloBotoes ObtemTituloBotoes()
        {
            return new TituloBotoes
            {
                Adicionar = "Adicionar Conta",
                Excluir = "Excluir Conta",
                Atualizar = "Atualizar Conta",
                Sacar = "Realizar Saque",
                Depositar = "Realizar Depósito",
                Transferir = "Transferir Para",
                Extrato = "Exibir Extrato"
            };
        }

        public override EstadoBotoes ObtemEstadoBotoes()
        {
            return new EstadoBotoes
            {
                Adicionar = true,
                Excluir = true,
                Atualizar = true,
                Sacar = true,
                Depositar = true,
                Transferir = true,
                Extrato = true
            };
        }
    }
}