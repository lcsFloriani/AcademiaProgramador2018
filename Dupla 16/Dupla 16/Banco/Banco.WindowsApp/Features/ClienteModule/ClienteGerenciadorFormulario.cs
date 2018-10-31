using Banco.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banco.Infra.Data;
using Banco.WindowsApp.Features.Compartilhado;

namespace Banco.WindowsApp.Features.ClienteModule
{
    class ClienteGerenciadorFormulario : GerenciadorFormulario
    {
        private ClienteControl clienteControl;
        private ClienteMem _repositoryCliente;
        
        public ClienteGerenciadorFormulario(ClienteMem repositorioCliente)
        {
            _repositoryCliente = repositorioCliente;
        }

        public override void Adicionar()
        {
            CadastroClienteDialog dialog = new CadastroClienteDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _repositoryCliente.AdicionarCliente(dialog.NovoCliente);
                List<Cliente> clientes = _repositoryCliente.TrazerClientes();
                clienteControl.PopularListagemClientes(clientes);
            }
        }

        public override UserControl CarregarListagem()
        {
            if(clienteControl == null)
                clienteControl = new ClienteControl();

            return clienteControl;
        }

        public override EstadoBotoes ObtemTipoBotoes()
        {
            return new EstadoBotoes {
                Cadastrar = true,
                Deposito = false,
                Excluir = true,
                Extrato = false,
                Saque = false,
                Transferencia = false
                
            };
        }
        public override TextoBotoes ObtemTextoBotoes()
        {
            return new TextoBotoes
            {
                Cadastrar = "Novo Cliente",
                Excluir = "Excluir Cliente"
            };
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Clientes";
        }

        public override void Excluir()
        {
            Cliente ClienteSelecionado = clienteControl.TrazerCliente();
            DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir o cliente " + ClienteSelecionado.Nome,
               "Excluir Cliente",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                _repositoryCliente.ExcluirCliente(ClienteSelecionado);

                List<Cliente> contas = _repositoryCliente.TrazerClientes();

                clienteControl.PopularListagemClientes(contas);
            }
        }
    }
}
