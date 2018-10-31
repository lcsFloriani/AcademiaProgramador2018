using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using System;
using System.Collections.Generic;

namespace Pizzaria.Domain.Tests.Features.Pedidos
{
    [TestFixture]
    public class PedidoTest
    {
        private Mock<Cliente> _pessoaFake;
        private Mock<Cliente> _empresaFake;

        private Produto _pizzaPequenaCalabresa;
        private Produto _pizzaPequenaCoracao;
        private Produto _pizzaMediaMussarela;
        private Produto _bordaPequenaCatupiry;
        private Produto _bordaMediaCheddar;

        private Pedido _pedido;
        private List<ItemPedido> _itensPedidos;

        [SetUp]
        public void Inicializacao()
        {
            _pessoaFake = new Mock<Cliente>();
            _pessoaFake.Object.TipoCliente = TipoClienteEnum.Fisico;

            _empresaFake = new Mock<Cliente>();
            _empresaFake.Object.TipoCliente = TipoClienteEnum.Juridico;

            _pizzaPequenaCalabresa = ObjectMother.ObterPizzaPequenaDeCalabresa();

            _pizzaPequenaCoracao = ObjectMother.ObterPizzaPequenaDeCoracao();
            _pizzaMediaMussarela = ObjectMother.ObterPizzaMediaDeMussarela();
            _bordaPequenaCatupiry = ObjectMother.ObterBordaPequenaCatupiry();
            _bordaMediaCheddar = ObjectMother.ObterBordaMediaCheddar();

            _itensPedidos = new List<ItemPedido>();
            _itensPedidos.Add(new ItemPedido { PrimeiroProduto = _pizzaMediaMussarela});
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_com_1_unico_sabor()
        {
            //Arrange
            _pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(_pessoaFake.Object);

            int quantidade = 1;
            double valorEsperado = 60;
            int tamanhoEsperado = 1;

            ItemPedido itemPizza = new ItemPedido(_pizzaPequenaCalabresa, quantidade);

            //Action
            _pedido.AdicionarItem(itemPizza);
            double resultado = _pedido.ValorTotal;

            //Assert
            _pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_com_2_sabores_de_valores_diferentes()
        {
            //Arrange
            _pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(_pessoaFake.Object);

            int quantidade = 1;
            double valorEsperado = 70;
            int tamanhoEsperado = 1;

            ItemPedido itemPizza = new ItemPedido(_pizzaPequenaCalabresa, _pizzaPequenaCoracao, null, quantidade);

            //Action
            _pedido.AdicionarItem(itemPizza);
            double resultado = _pedido.ValorTotal;

            //Assert
            _pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_2_pizzas_com_1_sabor_cada()
        {
            //Arrange
            _pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(_pessoaFake.Object);

            int quantidade = 1;
            double valorEsperado = 130;
            int tamanhoEsperado = 2;

            ItemPedido itemPrimeiraPizza = new ItemPedido(_pizzaPequenaCalabresa, quantidade);
            ItemPedido itemSegundaPizza = new ItemPedido(_pizzaPequenaCoracao, quantidade);

            //Action
            _pedido.AdicionarItem(itemPrimeiraPizza);
            _pedido.AdicionarItem(itemSegundaPizza);
            double resultado = _pedido.ValorTotal;

            //Assert
            _pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_com_1_unico_sabor_com_borda()
        {
            //Arrange
            _pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(_pessoaFake.Object);

            int quantidade = 1;
            double valorEsperado = 61.25;
            int tamanhoEsperado = 1;

            ItemPedido itemPizza = new ItemPedido(_pizzaPequenaCalabresa, null, _bordaPequenaCatupiry, quantidade);

            //Action
            _pedido.AdicionarItem(itemPizza);
            double resultado = _pedido.ValorTotal;

            //Assert
            _pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_com_2_sabores_com_borda_catupiry_e_1_pizza_media_com_2_sabores_com_borda_cheddar()
        {
            //Arrange
            _pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(_pessoaFake.Object);
            Produto pizzaMediaCalabresa = ObjectMother.ObterPizzaMediaDeCalabresa();
          
            int quantidade = 1;
            double valorEsperado = 147.75;
            int tamanhoEsperado = 2;

            ItemPedido itemPrimeiraPizza = new ItemPedido(_pizzaPequenaCalabresa, _pizzaPequenaCoracao, _bordaPequenaCatupiry, quantidade);
            ItemPedido itemSegundaPizza = new ItemPedido(_pizzaMediaMussarela, pizzaMediaCalabresa, _bordaMediaCheddar, quantidade);

            //Action
            _pedido.AdicionarItem(itemPrimeiraPizza);
            _pedido.AdicionarItem(itemSegundaPizza);
            double resultado = _pedido.ValorTotal;

            //Assert
            _pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_com_1_calzone()
        {
            //Arrange
            _pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(_pessoaFake.Object);
            Produto calzone = ObjectMother.ObterCalzone();

            int quantidadeCalzone = 1;
            int quantidadePizza = 1;
            double valorEsperado = 75.00;
            int tamanhoLista = 2;
            
            ItemPedido itemCalzone = new ItemPedido(calzone, quantidadeCalzone);
            ItemPedido itemPizza = new ItemPedido(_pizzaPequenaCalabresa, quantidadePizza);

            //Action
            _pedido.AdicionarItem(itemCalzone);
            _pedido.AdicionarItem(itemPizza);
            double resultado = _pedido.ValorTotal;

            //Assert
            _pedido.ItensPedidos.Should().HaveCount(tamanhoLista);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_com_1_bebida()
        {
            //Arrange
            _pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(_pessoaFake.Object);
            Produto bebida = ObjectMother.ObterBebida();
            
            int quantidadeBebida = 1;
            int quantidadePizza = 1;
            double valorEsperado = 68.00;

            ItemPedido itemBebida = new ItemPedido(bebida, quantidadeBebida);
            ItemPedido itemPizza = new ItemPedido(_pizzaPequenaCalabresa, quantidadePizza);

            //Action
            _pedido.AdicionarItem(itemBebida);
            _pedido.AdicionarItem(itemPizza);
            double resultado = _pedido.ValorTotal;

            //Assert
            _pedido.ItensPedidos.Should().HaveCount(2);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoComUmaListaDeItens(_pessoaFake.Object, _itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().NotThrow<Exception>();
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_o_cliente_nulo()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoComClienteNulo(_itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoClienteNuloExcecao>();
        }

        
        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_lista_de_itens_vazia()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(_pessoaFake.Object);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoItensPedidosVazioExcecao>();
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_setor_nulo_ou_vazio()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoComSetorNuloOuVazio(_empresaFake.Object, _itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoSetorNuloOuVazioExcecao>();
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_responsavel_nulo_ou_vazio()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoComResponsavelNuloOuVazio(_empresaFake.Object, _itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoResponsavelNuloOuVazioExcecao>();
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_documento_nulo_ou_vazio()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoComDocumentoNuloOuVazio(_pessoaFake.Object, _itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoDocumentoNuloOuVazioExcecao>();
        }
    }
}
