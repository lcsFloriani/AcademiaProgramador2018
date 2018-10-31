using GerenciadorProvas.WinApp.Features;
using Pizzaria.Application.Features.Clientes;
using Pizzaria.Application.Features.Pedidos;
using Pizzaria.Application.Features.Produtos;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.WinApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Pedidos
{
    public class PedidoGerenciadorFormulario : GerenciadorFormulario<Pedido, PedidoServico>
    {
        private ClienteServico _clienteServico;
        private ProdutoServico _produtoServico;
        private int listaVazia = 0;

        public PedidoGerenciadorFormulario(PedidoServico servico, ClienteServico clienteServico, ProdutoServico produtoServico) : base(servico)
        {
            _clienteServico = clienteServico;
            _produtoServico = produtoServico;
        }

        public override void Editar()
        {
            PedidoStatusDialog dialog = new PedidoStatusDialog();
            dialog.Valor = controle.Valor;
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _servico.Atualizar(dialog.Valor);
                controle.LimparItemSelecionado();
                CarregarListagem();

                MessageBox.Show("Pedido alterado com sucesso no sistema!");
            }

        }

        public override void Filtrar()
        {
            PedidoFiltroDialog dialog = new PedidoFiltroDialog();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                List<Pedido> pedidos = _servico.BuscarPedidoPorTelefoneDoCliente(dialog.Valor) as List<Pedido>;

                if (pedidos.Count == listaVazia)
                {
                    CarregarListagem();
                    MessageBox.Show("Sem resultado encontrados!");
                }
                else
                {
                    CarregarListagem(pedidos);
                }
            }

        }

        public override void Gravar()
        {
            PedidoDialog dialog = new PedidoDialog(_clienteServico, _produtoServico);
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _servico.Adicionar(dialog.Valor);
                CarregarListagem();

                MessageBox.Show("Pedido salvo com sucesso no sistema!");
            }
        }

        public override TituloBotoes ObtemTituloBotoes(string selecionado)
        {
            return new TituloBotoes
            {
                Gravar = "Realizar " + selecionado,
                Editar = "Acompanhamento do " + selecionado,
                Excluir = "Excluir " + selecionado,
                Filtrar = string.Format("Filtrar {0} por telefone do cliente", selecionado)
            };
        }
    }
}
