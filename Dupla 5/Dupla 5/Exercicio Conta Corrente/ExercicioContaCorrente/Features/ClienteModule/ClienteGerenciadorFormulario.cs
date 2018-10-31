using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExercicioContaCorrente.Features.ClienteModule;
using ExercicioContaCorrente.Domain;
using ExercicioContaCorrente;
using ExercicioContaCorrente.Infra.Data;

namespace ExercicioContaCorrente.Features.ClienteModule
{
    public class ClienteGerenciadorFormulario : GerenciadorFormulario
    {
        private ClienteMem _repositorioClientes;
        private ClienteControl clienteControl;

        public ClienteGerenciadorFormulario(ClienteMem repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }

        public override void Adicionar()
        {
            CadastroClienteDialog dialog = new CadastroClienteDialog();
            dialog.NovoCliente = new Cliente();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {

                _repositorioClientes.Insert(dialog.NovoCliente);

                List<Cliente> clientes = _repositorioClientes.GetAll();

                clienteControl.PopularListagemClientes(clientes);
            }
        }

        public override void Atualizar()
        {
            Cliente clienteSelecionada = clienteControl.GetCliente();

            if (clienteSelecionada != null)
            {
                CadastroClienteDialog dialog = new CadastroClienteDialog();
                dialog.NovoCliente = clienteSelecionada;
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _repositorioClientes.Update(dialog.NovoCliente);

                    List<Cliente> clientes = _repositorioClientes.GetAll();

                    clienteControl.PopularListagemClientes(clientes);
                }
            }
        }

        public override void Remover()
        {
            Cliente clienteSelecionada = clienteControl.GetCliente();

            if (clienteSelecionada != null)
            {
                var resultado = MessageBox.Show("Deseja realmente excluir?", "Confirmar Exclusão", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    _repositorioClientes.Delete(clienteSelecionada);

                    List<Cliente> clientes = _repositorioClientes.GetAll();
                    clienteControl.PopularListagemClientes(clientes);
                }
            }
            else
            {
                MessageBox.Show("Selecione um Cliente");
            }
        }

        public override UserControl CarregarListagem()
        {
            if (clienteControl == null)
                clienteControl = new ClienteControl();

            List<Cliente> clientes = _repositorioClientes.GetAll();

            clienteControl.PopularListagemClientes(clientes);

            return clienteControl;
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Clientes";
        }

        public override TituloBotoes ObtemTituloBotoes()
        {
            return new TituloBotoes
            {
                Adicionar= "Adicionar Cliente",
                Excluir = "Excluir Cliente",
                Atualizar = "Atualizar Cliente",
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
                Sacar = false,
                Depositar = false,
                Transferir = false,
                Extrato = false
            };
        }
    }
}
