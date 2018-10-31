using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;

using System;
using System.Collections.Generic;

namespace Pizzaria.Domain.Tests.Features.ItensPedido
{
    [TestFixture]
    public class ItemPedidoTest
    {
        private Mock<Pedido> _pedidoFake;

        private Produto _pizzaPequenaCalabresa;
        private Produto _pizzaPequenaCoracao;
        private Produto _pizzaMediaMussarela;
        private Produto _bordaPequenaCatupiry;
        private Produto _bordaMediaCheddar;

        [SetUp]
        public void Inicializacao()
        {
            _pedidoFake = new Mock<Pedido>();

            _pizzaPequenaCalabresa = ObjectMother.ObterPizzaPequenaDeCalabresa();
            _pizzaPequenaCoracao = ObjectMother.ObterPizzaPequenaDeCoracao();
            _pizzaMediaMussarela = ObjectMother.ObterPizzaMediaDeMussarela();
            _bordaPequenaCatupiry = ObjectMother.ObterBordaPequenaCatupiry();
            _bordaMediaCheddar = ObjectMother.ObterBordaMediaCheddar();
        }

        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_parcial_item_pedido_com_1_pizza_com_1_unico_sabor()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmProduto(_pedidoFake.Object,_pizzaPequenaCalabresa);

            double valorEsperado = 60;

            //Action
            double resultado = item.ValorParcial;

            //Assert
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_parcial_item_pedido_com_1_pizza_com_2_sabores_de_valores_diferentes()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmaPizzaComDoisSabores(_pedidoFake.Object, _pizzaPequenaCalabresa, _pizzaPequenaCoracao);

            double valorEsperado = 70;

            //Action
            double resultado = item.ValorParcial;

            //Assert
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_parcial_item_pedido_com_2_pizzas_com_o_mesmo_sabor()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmProduto(_pedidoFake.Object, _pizzaPequenaCalabresa);
            item.Quantidade = 2;

            double valorEsperado = 120;

            //Action
            double resultado = item.ValorParcial;

            //Assert

            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_parcial_item_pedido_com_1_pizza_com_1_unico_sabor_com_borda()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmaPizzaComAdicional(_pedidoFake.Object, _pizzaPequenaCalabresa, _bordaPequenaCatupiry);

            double valorEsperado = 61.25;

            //Action
            double resultado = item.ValorParcial;

            //Assert
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_parcial_item_pedido_com_1_pizza_com_2_sabores_com_borda_catupiry()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmPizzaComDoisSaboresEAdicional(_pedidoFake.Object, _pizzaPequenaCalabresa, _pizzaPequenaCoracao, _bordaPequenaCatupiry);

            double valorEsperado = 71.25;

            //Action
            double resultado = item.ValorParcial;

            //Assert
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmProduto(_pedidoFake.Object, _pizzaPequenaCalabresa);

            //Action

            Action acao = item.Validar;
            //Assert
            acao.Should().NotThrow<Exception>();
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido_com_pedido_nulo()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmPedidoNulo();

            //Action
            Action acao = item.Validar;

            //Assert
            acao.Should().Throw<ItemPedidoPedidoNuloExcecao>();
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido_com_o_primeiro_produto_nulo()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComPrimeiroProdutoNulo(_pedidoFake.Object);

            //Action
            Action acao = item.Validar;

            //Assert
            acao.Should().Throw<ItemPedidoPrimeiroProdutoNuloOuVazioExcecao>();
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido_com_quantidade_menor_que_1()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmProdutoComQuantidadeMenorQueUm(_pedidoFake.Object, _pizzaPequenaCalabresa);

            //Action
            Action acao = item.Validar;

            //Assert
            acao.Should().Throw<ItemPedidoQuantidadeZeroExcecao>();
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido_com_adicional_invalido()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmaPizzaComAdicional(_pedidoFake.Object, _pizzaPequenaCalabresa, _pizzaMediaMussarela);

            //Action
            Action acao = item.Validar;

            //Assert
            acao.Should().Throw<ItemPedidoAdicionalInvalidoExcecao>();
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido_com_dois_sabores_iguais()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObterItemPedidoComUmaPizzaComDoisSabores(_pedidoFake.Object, _pizzaPequenaCalabresa, _pizzaPequenaCalabresa);

            //Action
            Action acao = item.Validar;

            //Assert
            acao.Should().Throw<ItemPedidoPrimeiroProdutoIgualSegundoProdutoInvalidoExcecao>();
        }

    }
}
