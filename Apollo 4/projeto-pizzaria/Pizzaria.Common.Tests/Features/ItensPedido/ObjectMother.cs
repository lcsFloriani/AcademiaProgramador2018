using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static ItemPedido ObterItemPedidoComUmProduto(Pedido pedido, Produto produto)
        {
            return new ItemPedido
            {
                Pedido = pedido,
                PrimeiroProduto = produto,
                Quantidade = 1
            };
        }

        public static ItemPedido ObterItemPedidoComUmPedidoNulo()
        {
            return new ItemPedido
            {
                Quantidade = 1
            };
        }

        public static ItemPedido ObterItemPedidoComPrimeiroProdutoNulo(Pedido pedido)
        {
            return new ItemPedido
            {
                Pedido = pedido,
                Quantidade = 1
            };
        }

        public static ItemPedido ObterItemPedidoComUmProdutoComQuantidadeMenorQueUm(Pedido pedido, Produto produto)
        {
            return new ItemPedido
            {
                Pedido = pedido,
                PrimeiroProduto = produto,
                Quantidade = 0
            };
        }

        public static ItemPedido ObterItemPedidoComUmaPizzaComAdicional(Pedido pedido, Produto produto, Produto adicional)
        {
            return new ItemPedido
            {
                Pedido = pedido,
                PrimeiroProduto = produto,
                Adicional = adicional,
                Quantidade = 1
            };
        }

        public static ItemPedido ObterItemPedidoComUmaPizzaComDoisSabores(Pedido pedido, Produto primeiroProduto, Produto segundoProduto)
        {
            return new ItemPedido
            {
                Pedido = pedido,
                PrimeiroProduto = primeiroProduto,
                SegundoProduto = segundoProduto,
                Quantidade = 1
            };
        }

        public static ItemPedido ObterItemPedidoComUmPizzaComDoisSaboresEAdicional(Pedido pedido, Produto primeiroProduto, Produto segundoProduto, Produto adicional)
        {
            return new ItemPedido
            {
                Pedido = pedido,
                PrimeiroProduto = primeiroProduto,
                SegundoProduto = segundoProduto,
                Adicional = adicional,
                Quantidade = 1
            };
        }
    }
}
