using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Infra.ORM.Funcionalidades.Clientes;
using BancoTabajara.Infra.ORM.Tests.Inicializador;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoTabajara.Infra.ORM.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClienteRepositorioTeste : EffortBaseTeste
    {
        private ClienteRepositorio _repositorio;
        private int _igualZero = 0;

        [SetUp]
        public void Inicializar()
        {
            _repositorio = new ClienteRepositorio(contexto);
        }

        [Test]
        public void Clientes_InfraORM_Deve_adicionar_cliente()
        {
            //Cenario
            Cliente cliente = ObjetoMae.ObterClientePadrao();

            //Ação
            var clienteRegistrado = _repositorio.Adicionar(cliente);

            //Verificação
            clienteRegistrado.Should().NotBeNull();
            clienteRegistrado.Id.Should().NotBe(_igualZero);
            var contaEsperada = _repositorio.BuscarPorId(clienteRegistrado.Id);
            contaEsperada.Should().NotBeNull();
            contaEsperada.Should().Be(clienteRegistrado);
        }

        [Test]
        public void Clientes_InfraORM_Deve_atualizar_cliente()
        {
            //Cenário
            int idPesquisa = 1;
            Cliente cliente = _repositorio.BuscarPorId(idPesquisa);
            string nomeAntigo = cliente.Nome;
            cliente.Nome = "Novo";

            //Ação
            var resultado = _repositorio.Atualizar(cliente);

            //Verifica
            resultado.Should().BeTrue();
        }

        [Test]
        public void Clientes_InfraORM_Deve_excluir_cliente()
        {
            //Cenário
            int idPesquisa = 1;
            Cliente cliente = _repositorio.BuscarPorId(idPesquisa);

            //Ação
            var resultado = _repositorio.Excluir(cliente);

            //Verifica
            resultado.Should().BeTrue();
            Action acao = () => _repositorio.BuscarPorId(idPesquisa);
            acao.Should().Throw<NaoEncontradoExcecao>();
        }

        [Test]
        public void Clientes_InfraORM_Deve_buscar_cliente_por_id()
        {
            //Cenário
            int idPesquisa = 1;

            //Ação
            Cliente resultado = _repositorio.BuscarPorId(idPesquisa);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idPesquisa);
        }

        [Test]
        public void Clientes_InfraORM_Nao_deve_buscar_cliente_por_id_que_nao_exista()
        {
            //Cenário
            int idPesquisa = 0;

            //Ação
            Action acao = () => _repositorio.BuscarPorId(idPesquisa);

            //Verifica
            acao.Should().Throw<NaoEncontradoExcecao>();
        }

        [Test]
        public void Clientes_InfraORM_Deve_buscar_todos_os_clientes()
        {
            //Cenário
            int tamanhoLista = 2;
            int quantidade = 3;

            //Ação
            IQueryable<Cliente> clientes = _repositorio.Listagem(quantidade);

            //Verifica
            clientes.Should().NotBeNull();
            clientes.Count().Should().Be(tamanhoLista);
        }
    }
}
