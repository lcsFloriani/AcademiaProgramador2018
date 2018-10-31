using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoTabajara.Aplicacao.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClienteServicoTeste
    {
        private Mock<IClienteRepositorio> _repositorioFake;
        private ClienteServico _servico;

        [SetUp]
        public void Inicializar()
        {
            _repositorioFake = new Mock<IClienteRepositorio>();
            _servico = new ClienteServico(_repositorioFake.Object);
        }

        [Test]
        public void Clientes_Aplicacao_Deve_adicionar_cliente()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClientePadrao();
            long idEsperado = 1;

            _repositorioFake.Setup(c => c.Adicionar(cliente)).Returns(ObjetoMae.ObterClientePadraoComId);

            //Ação
            long idRecebido = _servico.Adicionar(cliente);

            //Verifica
            idEsperado.Should().Be(idRecebido);
            _repositorioFake.Verify(repository => repository.Adicionar(cliente));
        }

        [Test]
        public void Clientes_Aplicacao_Nao_deve_adicionar_cliente_com_nome_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClienteComNomeNuloOuVazio();

            _repositorioFake.Setup(c => c.Adicionar(It.IsAny<Cliente>()));

            //Ação
            Action action = () => _servico.Adicionar(cliente);

            //Verifica
            action.Should().Throw<ClienteNomeNuloOuVazioExcecao>();
            _repositorioFake.Verify(c => c.Adicionar(It.IsAny<Cliente>()), Times.Never());
        }

        [Test]
        public void Clientes_Aplicacao_Nao_deve_adicionar_cliente_com_CPF_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClienteComCPFNuloOuVazio();

            _repositorioFake.Setup(c => c.Adicionar(It.IsAny<Cliente>()));

            //Ação
            Action action = () => _servico.Adicionar(cliente);

            //Verifica
            action.Should().Throw<ClienteCPFNuloOuVazioExcecao>();
            _repositorioFake.Verify(c => c.Adicionar(It.IsAny<Cliente>()), Times.Never());
        }

        [Test]
        public void Clientes_Aplicacao_Nao_deve_adicionar_cliente_com_RG_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClienteComRGNuloOuVazio();

            _repositorioFake.Setup(c => c.Adicionar(It.IsAny<Cliente>()));

            //Ação
            Action action = () => _servico.Adicionar(cliente);

            //Verifica
            action.Should().Throw<ClienteRGNuloOuVazioExcecao>();
            _repositorioFake.Verify(c => c.Adicionar(It.IsAny<Cliente>()), Times.Never());
        }


        [Test]
        public void Clientes_Aplicacao_Deve_atualizar_cliente_e_retornar_true()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClientePadrao();
            cliente.Id = 1;

            bool retorno = true;

            _repositorioFake.Setup(m => m.Atualizar(It.IsAny<Cliente>())).Returns(retorno);

            //Ação
            var resultado = _servico.Atualizar(cliente);

            //Verifica
            resultado.Should().BeTrue();
            _repositorioFake.Verify(repository => repository.Atualizar(cliente));
        }

        [Test]
        public void Clientes_Aplicacao_Nao_deve_atualizar_cliente_com_id_invalido()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClientePadrao();

            _repositorioFake.Setup(c => c.Atualizar(It.IsAny<Cliente>()));

            //Ação
            Action action = () => _servico.Atualizar(cliente);

            //Verifica
            action.Should().Throw<IdentificadorIndefinidoExcecao>();
            _repositorioFake.Verify(c => c.Atualizar(It.IsAny<Cliente>()), Times.Never());
        }

        [Test]
        public void Clientes_Aplicacao_Nao_deve_atualizar_cliente_com_nome_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClienteComNomeNuloOuVazio();
            cliente.Id = 1;

            _repositorioFake.Setup(c => c.Atualizar(It.IsAny<Cliente>()));

            //Ação
            Action action = () => _servico.Atualizar(cliente);

            //Verifica
            action.Should().Throw<ClienteNomeNuloOuVazioExcecao>();
            _repositorioFake.Verify(c => c.Atualizar(It.IsAny<Cliente>()), Times.Never());
        }

        [Test]
        public void Clientes_Aplicacao_Nao_deve_atualizar_cliente_com_CPF_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClienteComCPFNuloOuVazio();
            cliente.Id = 1;

            _repositorioFake.Setup(c => c.Atualizar(It.IsAny<Cliente>()));

            //Ação
            Action action = () => _servico.Atualizar(cliente);

            //Verifica
            action.Should().Throw<ClienteCPFNuloOuVazioExcecao>();
            _repositorioFake.Verify(c => c.Atualizar(It.IsAny<Cliente>()), Times.Never());
        }

        [Test]
        public void Clientes_Aplicacao_Nao_deve_atualizar_cliente_com_RG_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClienteComRGNuloOuVazio();
            cliente.Id = 1;

            _repositorioFake.Setup(c => c.Atualizar(It.IsAny<Cliente>()));

            //Ação
            Action action = () => _servico.Atualizar(cliente);

            //Verifica
            action.Should().Throw<ClienteRGNuloOuVazioExcecao>();
            _repositorioFake.Verify(c => c.Atualizar(It.IsAny<Cliente>()), Times.Never());
        }

        [Test]
        public void Clientes_Aplicacao_Deve_retornar_falso_quando_ocorrer_algum_erro_no_processo_de_atualizar_no_repositorio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClientePadrao();
            cliente.Id = 1;

            bool retorno = false;

            _repositorioFake.Setup(m => m.Atualizar(It.IsAny<Cliente>())).Returns(retorno);

            //Ação
            var resultado = _servico.Atualizar(cliente);

            //Verifica
            resultado.Should().BeFalse();
            _repositorioFake.Verify(repository => repository.Atualizar(cliente));
        }

        [Test]
        public void Clientes_Aplicacao_Deve_retornar_cliente_por_id()
        {
            //Cenário
            long idPesquisa = 1;
            Cliente cliente = ObjetoMae.ObterClientePadrao();
            cliente.Id = 1;

            _repositorioFake.Setup(m => m.BuscarPorId(It.IsAny<long>())).Returns(cliente);

            //Ação
            ClienteDTO resultado = _servico.BuscarPorId(idPesquisa);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Nome.Should().Be(cliente.Nome);
            _repositorioFake.Verify(m => m.BuscarPorId(It.IsAny<long>()));
        }

        [Test]
        public void Clientes_Aplicacao_Deve_retornar_excecao_quando_id_for_invalido()
        {
            //Cenário
            long idPesquisa = 0;

            _repositorioFake.Setup(m => m.BuscarPorId(It.IsAny<long>()));

            //Ação
            Action action = () => _servico.BuscarPorId(idPesquisa);

            //Verifica
            action.Should().Throw<IdentificadorIndefinidoExcecao>();
            _repositorioFake.Verify(c => c.BuscarPorId(It.IsAny<long>()), Times.Never());
        }

        [Test]
        public void Clientes_Aplicacao_Deve_excluir_cliente_e_retornar_true()
        {
            //Cenário
            long idBusca = 1;
            bool retorno = true;

            Cliente cliente = ObjetoMae.ObterClientePadrao();
            cliente.Id = idBusca;

            _repositorioFake.Setup(c => c.BuscarPorId(idBusca)).Returns(cliente);
            _repositorioFake.Setup(c => c.Excluir(cliente)).Returns(retorno);

            //Ação
            var resultado = _servico.Excluir(cliente.Id);

            //Verifica
            resultado.Should().BeTrue();
            _repositorioFake.Verify(c => c.Excluir(cliente));
        }

        [Test]
        public void Clientes_Aplicacao_Deve_retornar_excecao_quando_id_do_cliente_for_invalido()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClientePadrao();

            _repositorioFake.Setup(c => c.Excluir(cliente));

            //Ação
            Action action = () => _servico.Excluir(cliente.Id);

            //Verifica
            action.Should().Throw<IdentificadorIndefinidoExcecao>();
            _repositorioFake.Verify(c => c.Excluir(cliente), Times.Never);
        }

        [Test]
        public void Clientes_Aplicacao_Deve_retornar_falso_quando_ocorrer_algum_erro_no_processo_de_excluir_no_repositorio()
        {
            //Cenário
            long idBusca = 1;
            bool retorno = false;

            Cliente cliente = ObjetoMae.ObterClientePadrao();
            cliente.Id = idBusca;

            _repositorioFake.Setup(c => c.BuscarPorId(idBusca)).Returns(cliente);
            _repositorioFake.Setup(c => c.Excluir(cliente)).Returns(retorno);

            //Ação
            var resultado = _servico.Excluir(cliente.Id);

            //Verifica
            resultado.Should().BeFalse();
            _repositorioFake.Verify(c => c.Excluir(cliente));
        }

        [Test]
        public void Clientes_Aplicacao_Deve_retornar_todos_os_clientes()
        {
            //Cenário
            int tamanhoLista = 2;
            var listaClientes = new List<Cliente>() {
                new Cliente() { Id = 1 },
                new Cliente() { Id = 2 }
            };

            int quantidade = 2;

            _repositorioFake.Setup(c => c.Listagem(quantidade)).Returns(listaClientes.AsQueryable);

            //Ação
            IQueryable<ClienteDTO> clientes = _servico.Listagem(quantidade);

            //Verifica
            clientes.Should().NotBeNull();
            clientes.Should().HaveCount(tamanhoLista);
            _repositorioFake.Verify(c => c.Listagem(quantidade));
        }
    }
}
