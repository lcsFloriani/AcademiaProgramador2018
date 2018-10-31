using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Data.Features.Pedidos;
using Pizzaria.Infra.Data.Features.Produtos;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Tests.Features.Pedidos
{
    [TestFixture]
    public class PedidoSQLRepositorioTest
    {
        private IPedidoRepositorio _repositorio;
        private Cliente _cliente;
        private DataContext _contexto;
        private Produto _calzone;

        [SetUp]
        public void Inicializacao()
        {
            Database.SetInitializer(new CriarBaseDeDadosParaTeste());
            _contexto = new DataContext();
            _contexto.Database.Initialize(true);

            _repositorio = new PedidoSQLRepositorio(_contexto);

            _cliente = ObjectMother.ObterClienteTipoPessoaFisica(ObjectMother.ObterEndereco());
            _cliente.Id = 1;

            _calzone = ObjectMother.ObterCalzone();
            _calzone.Id = 1;
        }

        [Test]
        public void Pedidos_InfraData_Deve_salvar_um_pedido()
        {
            //Cenário
            Pedido pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(_cliente);

            long idEsperado = 2;
            int quantidade = 3;
            int maiorQue = 0;

            ItemPedido itemPedido = new ItemPedido(_calzone, quantidade);

            //Ação
            pedido.AdicionarItem(itemPedido);
            Pedido resultado = _repositorio.Salvar(pedido);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idEsperado);
            resultado.Cliente.Should().NotBeNull();
            resultado.ItensPedidos.Should().HaveCountGreaterThan(maiorQue);
        }

        [Test]
        public void Pedidos_InfraData_Deve_buscar_por_id_um_pedido()
        {
            //Cenário
            long idEsperado = 1;
            int maiorQue = 0;

            //Ação
            Pedido resultado = _repositorio.BuscarPorId(idEsperado);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idEsperado);
            resultado.Cliente.Should().NotBeNull();
            resultado.ItensPedidos.Should().HaveCountGreaterThan(maiorQue);
        }

        [Test]
        public void Pedidos_InfraData_Deve_atualizar_um_pedido()
        {
            //Cenario
            long idProcura = 1;
            StatusPedidoEnum novoStatus = StatusPedidoEnum.EmEntrega;
            Pedido pedido = _repositorio.BuscarPorId(idProcura);
            pedido.StatusPedido = novoStatus;

            //Ação
            var resultado = _repositorio.Atualizar(pedido);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.StatusPedido.Should().Equals(novoStatus);
        }

        [Test]
        public void Pedidos_InfraData_Deve_buscar_todos_os_pedidos()
        {
            //Cenario
            int tamanhoLista = 1;

            //Ação
            var lista = _repositorio.Listagem();

            //Verifica
            lista.Should().NotBeNull();
            lista.Should().HaveCount(tamanhoLista);
        }

        [Test]
        public void Pedidos_InfraData_Deve_excluir_um_pedido()
        {
            //Cenário
            long idPedido = 1;
            var pedido = _repositorio.BuscarPorId(idPedido);

            //Ação
            _repositorio.Excluir(pedido);

            //Verifica
            var pedidoDB = _repositorio.BuscarPorId(idPedido);
            pedidoDB.Should().BeNull();

        }

        [Test]
        public void Pedidos_InfraData_Deve_buscar_uma_lista_pedido_por_telefone_do_cliente()
        {
            //Cenário
            int tamanhoEsperado = 1;
            string telefoneDePesquisa = "32251709";

            //Ação
            var pedidos = _repositorio.BuscarPedidoPorTelefoneDoCliente(telefoneDePesquisa);

            //Verifica
            pedidos.Should().HaveCount(tamanhoEsperado);
            pedidos.First().Cliente.Telefone.Should().Be(telefoneDePesquisa);
        }
    }
}
