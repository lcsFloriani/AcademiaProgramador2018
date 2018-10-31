using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Application.Features.Clientes;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Infra.Data;
using Pizzaria.Infra.Data.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Integration.Tests.Features.Clientes
{
    [TestFixture]
    public class ClienteIntegracaoTest
    {
        private IClienteRepositorio _repositorio;
        private Endereco _endereco;
        private IClienteServico _servico;
        private DataContext _contexto;

        [SetUp]
        public void Inicializacao()
        {
            _contexto = new DataContext();
            Database.SetInitializer(new CriarBaseDeDadosParaTeste());
            _contexto.Database.Initialize(true);

            _endereco = ObjectMother.ObterEndereco();
            _repositorio = new ClienteSQLRepositorio(_contexto);

            _servico = new ClienteServico(_repositorio);
        }

        [Test]
        public void Clientes_Integration_Deve_adicionar_cliente_tipo_pessoa_fisica()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_endereco);

            int idEsperado = 4;

            //Ação
            Cliente resultado = _servico.Adicionar(cliente);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idEsperado);
            resultado.Endereco.Should().NotBeNull();
        }

        [Test]
        public void Clientes_Integration_Nao_deve_adicionar_cliente_com_nome_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComNomeNuloOuVazio(_endereco);

            //Ação
            Action action = () => _servico.Adicionar(cliente);

            //Verifica
            action.Should().Throw<ClienteNomeNuloOuVazioExcecao>();
        }

        [Test]
        public void Clientes_Integration_Nao_deve_adicionar_cliente_com_telefone_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComTelefoneNuloOuVazio(_endereco);

            //Ação
            Action action = () => _servico.Adicionar(cliente);

            //Verifica
            action.Should().Throw<ClienteTelefoneNuloOuVazioExcecao>();
        }

        [Test]
        public void Clientes_Integration_Nao_deve_adicionar_cliente_com_numero_de_documento_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComNumeroDocumentoNuloOuVazio(_endereco);

            //Ação
            Action action = () => _servico.Adicionar(cliente);

            //Verifica
            action.Should().Throw<ClienteNumeroDocumentoNuloOuVazioExcecao>();
        }

        [Test]
        public void Clientes_Integration_Nao_deve_adicionar_cliente_com_endereco_nulo()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComEnderecoNulo();

            //Ação
            Action action = () => _servico.Adicionar(cliente);

            //Verifica
            action.Should().Throw<ClienteEnderecoNuloExcecao>();
        }

        [Test]
        public void Clientes_Integration_Deve_atualizar_cliente()
        {
            //Cenário
            int idPesquisa = 1;
            Cliente cliente = _servico.BuscarPorId(idPesquisa);
            string nomeAntigo = cliente.Nome;
            cliente.Nome = "Novo";

            //Ação
            Cliente resultado = _servico.Atualizar(cliente);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(cliente.Id);
            resultado.Endereco.Should().NotBeNull();
            resultado.Nome.Should().NotBe(nomeAntigo);
        }

        [Test]
        public void Clientes_Integration_Nao_deve_atualizar_cliente_com_endereco_nulo()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComEnderecoNulo();
            cliente.Id = 1;

            //Ação
            Action action = () => _servico.Atualizar(cliente);

            //Verifica
            action.Should().Throw<ClienteEnderecoNuloExcecao>();
        }

        [Test]
        public void Clientes_Integration_Nao_deve_atualizar_cliente_com_id_invalido()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_endereco);

            //Ação
            Action action = () => _servico.Atualizar(cliente);

            //Verifica
            action.Should().Throw<IdentificadorIndefinidoExcecao>();
        }

        [Test]
        public void Clientes_Integration_Deve_buscar_cliente_por_id()
        {
            //Cenário
            int idPesquisa = 1;

            //Ação
            Cliente resultado = _servico.BuscarPorId(idPesquisa);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idPesquisa);
            resultado.Endereco.Should().NotBeNull();
        }

        [Test]
        public void Clientes_Integration_Nao_deve_buscar_cliente_por_id_com_id_invalido()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_endereco);

            //Ação
            Action action = () => _servico.BuscarPorId(cliente.Id);

            //Verifica
            action.Should().Throw<IdentificadorIndefinidoExcecao>();
        }

        [Test]
        public void Clientes_Integration_Deve_buscar_cliente_por_telefone()
        {
            //Cenário
            int idPesquisa = 1;
            Cliente cliente = _servico.BuscarPorId(idPesquisa);
            string telefone = cliente.Telefone;

            //Ação
            Cliente resultado = _servico.BuscarPorTelefone(telefone);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Telefone.Should().Be(telefone);
            resultado.Endereco.Should().NotBeNull();
        }

        [Test]
        public void Clientes_Integration_Nao_deve_buscar_cliente_por_telefone_com_telefone_invalido()
        {
            //Cenário
            string telefone = "";

            //Ação
            Action action = () => _servico.BuscarPorTelefone(telefone);

            //Verifica
            action.Should().Throw<ClienteTelefoneNuloOuVazioExcecao>();
        }

        [Test]
        public void Clientes_Integration_Deve_buscar_todos_os_clientes()
        {
            //Cenário
            int idEsperado = 1;
            int size = 3;

            //Ação
            List<Cliente> clientes = _servico.Listagem();

            //Verifica
            clientes.Should().NotBeNull();
            clientes.Count().Should().Be(size);
            clientes.First().Id.Should().Be(idEsperado);
        }

        [Test]
        public void Clientes_Integration_Deve_excluir_cliente()
        {
            //Cenário
            int idPesquisa = 1;
            Cliente cliente = _servico.BuscarPorId(idPesquisa);

            //Ação
            _servico.Excluir(cliente);

            //Verifica
            Cliente resultado = _servico.BuscarPorId(idPesquisa);
            resultado.Should().BeNull();
        }

        [Test]
        public void Clientes_Integration_Nao_deve_excluir_cliente_com_id_invalido()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_endereco);

            //Ação
            Action action = () => _servico.Excluir(cliente);

            //Verifica
            action.Should().Throw<IdentificadorIndefinidoExcecao>();
        }

        [Test]
        public void Clientes_Integration_Deve_verificar_cliente_com_telefone_repetido_com_telefone_igual_existente()
        {
            //Cenário
            int idPesquisa = 1;
            Cliente cliente = _servico.BuscarPorId(idPesquisa);
            cliente.Id = 0;

            //Ação
            bool resultado = _servico.VerificarClienteComTelefoneRepetido(cliente);

            //Verificar
            resultado.Should().Be(true);
        }

        [Test]
        public void Clientes_Integration_Deve_verificar_cliente_com_telefone_repetido_sem_telefone_igual_existente()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaJuridica(_endereco);
            cliente.Telefone = "999677658";
            cliente.Id = 0;

            //Ação
            bool resultado = _servico.VerificarClienteComTelefoneRepetido(cliente);

            //Verificar
            resultado.Should().Be(false);
        }
    }
}
