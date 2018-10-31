using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Application.Features.Pedidos;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using System;
using System.Collections.Generic;

namespace Pizzaria.Application.Tests.Features.Pedidos
{
    [TestFixture]
    public class PedidoServicoTest
    {
        private Mock<IPedidoRepositorio> _repositorio;
        private Mock<Cliente> _clienteFake;
        private Mock<ItemPedido> _itemPedidoFake;

        private PedidoServico _servico;
        private List<ItemPedido> _listaItemPedido;
        private Pedido _pedido;

        [SetUp]
        public void Inicializacao()
        {
            _repositorio = new Mock<IPedidoRepositorio>();
            _clienteFake = new Mock<Cliente>();
            _itemPedidoFake = new Mock<ItemPedido>();

            _servico = new PedidoServico(_repositorio.Object);

            _listaItemPedido = new List<ItemPedido>();
            _listaItemPedido.Add(_itemPedidoFake.Object);

            _pedido = ObjectMother.ObterPedidoComUmaListaDeItens(_clienteFake.Object, _listaItemPedido);
        }

        [Test]
        public void Pedidos_Application_Deve_adicionar_um_pedido()
        {
            //Cenário
            _repositorio.Setup(x => x.Salvar(_pedido)).Returns(new Pedido { Id = 1 });

            long idEsperado = 1;

            //Ação
            Pedido pedido = _servico.Adicionar(_pedido);

            //Verificação
            pedido.Id.Should().Be(idEsperado);
            _repositorio.Verify(x => x.Salvar(_pedido));
        }

        [Test]
        public void Pedidos_Application_Não_deve_adicionar_um_pedido_com_cliente_nulo()
        {
            //Cenário
            _pedido = ObjectMother.ObterPedidoComClienteNulo(_listaItemPedido);

            //Ação
            Action acao = () => _servico.Adicionar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoClienteNuloExcecao>();
            _repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pedidos_Application_Deve_atualizar_um_pedido()
        {
            //Cenário
            _repositorio.Setup(x => x.Atualizar(_pedido)).Returns(_pedido);

            StatusPedidoEnum novoStatus = StatusPedidoEnum.EmEntrega;
            _pedido.StatusPedido = novoStatus;
            _pedido.Id = 1;

            //Ação
            Pedido pedido = _servico.Atualizar(_pedido);

            //Verificação
            pedido.StatusPedido.Should().Be(novoStatus);
            _repositorio.Verify(x => x.Atualizar(_pedido));
        }

        [Test]
        public void Pedidos_Application_Nao_deve_atualizar_um_pedido_com_id_invalido()
        {
            //Cenário
            StatusPedidoEnum novoStatus = StatusPedidoEnum.EmEntrega;
            _pedido.StatusPedido = novoStatus;

            //Ação
            Action acao = () =>  _servico.Atualizar(_pedido);

            //Verificação
            acao.Should().Throw<IdentificadorIndefinidoExcecao>();
            _repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pedidos_Application_Não_deve_atualizar_um_pedido_com_cliente_nulo()
        {
            //Cenário
            _pedido = ObjectMother.ObterPedidoComClienteNulo(_listaItemPedido);
            _pedido.Id = 1;
            //Ação
            Action acao = () => _servico.Atualizar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoClienteNuloExcecao>();
            _repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pedidos_Application_Deve_excluir_um_pedido()
        {
            //Cenário
            _repositorio.Setup(x => x.Excluir(_pedido));
            _pedido.Id = 1;
            //Ação
            _servico.Excluir(_pedido);

            //Verificação
            _repositorio.Verify(x => x.Excluir(_pedido));
        }

        [Test]
        public void Pedidos_Application_Nao_deve_excluir_um_pedido_com_id_invalido()
        {
            //Cenário
            _pedido.Id = 0;

            //Ação
            Action acao = () => _servico.Excluir(_pedido);

            //Verificação
            acao.Should().Throw<IdentificadorIndefinidoExcecao>();
            _repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pedidos_Application_Deve_buscar_por_id_um_pedido()
        {
            //Cenário
            long idProcura = 1;
            _repositorio.Setup(x => x.BuscarPorId(idProcura)).Returns(_pedido);

            //Ação
            Pedido pedido = _servico.BuscarPorId(idProcura);

            //Verificação
            pedido.Should().NotBeNull();
            _repositorio.Verify(x => x.BuscarPorId(idProcura));
        }

        [Test]
        public void Pedidos_Application_Nao_deve_buscar_por_id_um_pedido_com_id_de_procura_invalida()
        {
            //Cenário
            long idProcura = 0;

            //Ação
            Action acao = () => _servico.BuscarPorId(idProcura);

            //Verificação
            acao.Should().Throw<IdentificadorIndefinidoExcecao>();
            _repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pedidos_Application_Deve_listar_os_pedidos()
        {
            //Cenário
            _repositorio.Setup(x => x.Listagem()).Returns(new List<Pedido>());

            //Ação
            var lista = _servico.Listagem();

            //Verificação
            lista.Should().NotBeNull();
            _repositorio.Verify(x => x.Listagem());
        }

        [Test]
        public void Pedidos_Application_Deve_buscar_pedidos_por_telefone_do_cliente()
        {
            //Cenário
            string telefoneProcura = "32251709";
            _repositorio.Setup(x => x.BuscarPedidoPorTelefoneDoCliente(telefoneProcura)).Returns(new List<Pedido>());

            //Ação
            var lista = _servico.BuscarPedidoPorTelefoneDoCliente(telefoneProcura);

            //Verificação
            lista.Should().NotBeNull();
            _repositorio.Verify(x => x.BuscarPedidoPorTelefoneDoCliente(telefoneProcura));
        }

        [Test]
        public void Pedidos_Application_Nao_deve_buscar_pedidos_por_telefone_do_cliente_com_telefone_nulo()
        {
            //Cenário
            string telefoneProcura = "";
            _repositorio.Setup(x => x.BuscarPedidoPorTelefoneDoCliente(telefoneProcura)).Returns(new List<Pedido>());

            //Ação
            Action acao = () =>_servico.BuscarPedidoPorTelefoneDoCliente(telefoneProcura);

            //Verificação
            acao.Should().Throw<PedidoTelefoneProcuraNuloOuVazioExcecao>();
            _repositorio.VerifyNoOtherCalls();
        }
    }
}
