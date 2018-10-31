using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Infra.CNPJs;
using Pizzaria.Infra.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Tests.Features.Clientes
{
    [TestFixture]
    public class ClienteTest
    {
        private Mock<Endereco> _mockEndereco;

        [SetUp]
        public void Inicializacao()
        {
            _mockEndereco = new Mock<Endereco>();
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_tipo_pessoa_fisica_com_todos_os_campos_validos()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_mockEndereco.Object);

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_com_nome_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComNomeNuloOuVazio(_mockEndereco.Object);

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().Throw<ClienteNomeNuloOuVazioExcecao>();
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_com_telefone_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComTelefoneNuloOuVazio(_mockEndereco.Object);

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().Throw<ClienteTelefoneNuloOuVazioExcecao>();
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_com_numero_documento_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComNumeroDocumentoNuloOuVazio(_mockEndereco.Object);

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().Throw<ClienteNumeroDocumentoNuloOuVazioExcecao>();
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_com_endereco_nulo()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComEnderecoNulo();

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().Throw<ClienteEnderecoNuloExcecao>();
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_tipo_pessoa_fisica_com_cpf_invalido()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisicaComCpfInvalido(_mockEndereco.Object);

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().Throw<CpfValorMenorQueOnzeExcecao>();
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_tipo_pessoa_juridica_com_cnpj_invalido()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaJuridicaComCnpjInvalido(_mockEndereco.Object);

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().Throw<CnpjValorMenorQueCatorzeExcecao>();
        }
    }
}
