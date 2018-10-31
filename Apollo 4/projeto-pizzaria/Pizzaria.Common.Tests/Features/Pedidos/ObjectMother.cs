using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using System;
using System.Collections.Generic;

namespace Pizzaria.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Pedido ObterPedidoSemUmaListaDeItens(Cliente cliente)
        {
            return new Pedido()
            {
                Data = DateTime.Now.AddHours(4),
                Cliente = cliente,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Responsavel = "Doctor Who",
                Documento = "59651873191"
            };
        }

        public static Pedido ObterPedidoComUmaListaDeItens(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now.AddHours(4),
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Responsavel = "Doctor Who",
                Documento = "59651873191"
            };
        }

        public static Pedido ObterPedidoComClienteNulo(List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now.AddHours(4),
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Responsavel = "Doctor Who",
                Documento = "59651873191"
            };
        }

       public static Pedido ObterPedidoComDataMenorQueAtual(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Responsavel = "Doctor Who",
                Documento = "59651873191"
            };
        }

        public static Pedido ObterPedidoComSetorNuloOuVazio(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now.AddHours(4),
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Responsavel = "Doctor Who",
                Documento = "44277721000119"
            };
        }

        public static Pedido ObterPedidoComResponsavelNuloOuVazio(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now.AddHours(4),
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Documento = "44277721000119"
            };
        }

        public static Pedido ObterPedidoComDocumentoNuloOuVazio(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now.AddHours(4),
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = true,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Responsavel = "Doctor Who"
            };
        }
    }
}
