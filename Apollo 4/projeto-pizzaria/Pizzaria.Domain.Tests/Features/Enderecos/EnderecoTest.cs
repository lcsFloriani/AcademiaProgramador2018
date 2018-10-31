using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Tests.Features.Enderecos
{
    [TestFixture]
    public class EnderecoTest
    {
        [Test]
        public void Enderecos_Domain_Verificar_endereco_com_todos_os_campos_validos()
        {
            //Cenário
            Endereco endereco = ObjectMother.ObterEndereco();

            //Ação
            Action action = endereco.Validar;

            //Verificar
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Enderecos_Domain_Verificar_endereco_com_logradouro_nulo_ou_vazio()
        {
            //Cenário
            Endereco endereco = ObjectMother.ObterEnderecoComLogradouroNuloOuVazio();

            //Ação
            Action action = endereco.Validar;

            //Verificar
            action.Should().Throw<EnderecoLogradouroNuloOuVazioExcecao>();
        }

        [Test]
        public void Enderecos_Domain_Verificar_endereco_com_bairro_nulo_ou_vazio()
        {
            //Cenário
            Endereco endereco = ObjectMother.ObterEnderecoComBairroNuloOuVazio();

            //Ação
            Action action = endereco.Validar;

            //Verificar
            action.Should().Throw<EnderecoBairroNuloOuVazioExcecao>();
        }

        [Test]
        public void Enderecos_Domain_Verificar_endereco_com_cidade_nula_ou_vazia()
        {
            //Cenário
            Endereco endereco = ObjectMother.ObterEnderecoComCidadeNulaOuVazia();

            //Ação
            Action action = endereco.Validar;

            //Verificar
            action.Should().Throw<EnderecoCidadeNulaOuVaziaExcecao>();
        }

        [Test]
        public void Enderecos_Domain_Verificar_endereco_com_uf_nulo_ou_vazio()
        {
            //Cenário
            Endereco endereco = ObjectMother.ObterEnderecoComUFNuloOuVazio();

            //Ação
            Action action = endereco.Validar;

            //Verificar
            action.Should().Throw<EnderecoUFNuloOuVazioExcecao>();
        }

        [Test]
        public void Enderecos_Domain_Verificar_endereco_com_cep_nulo_ou_vazio()
        {
            //Cenário
            Endereco endereco = ObjectMother.ObterEnderecoComCepNuloOuVazio();

            //Ação
            Action action = endereco.Validar;

            //Verificar
            action.Should().Throw<EnderecoCepNuloOuVazioExcecao>();
        }

        [Test]
        public void Enderecos_Domain_Verificar_endereco_com_numero_invalido()
        {
            //Cenário
            Endereco endereco = ObjectMother.ObterEnderecoComNumeroInvalido();

            //Ação
            Action action = endereco.Validar;

            //Verificar
            action.Should().Throw<EnderecoNumeroInvalidoExcecao>();
        }

        [Test]
        public void Enderecos_Domain_Verificar_endereco_com_complemento_nulo_ou_vazio()
        {
            //Cenário
            Endereco endereco = ObjectMother.ObterEnderecoComComplementoNuloOuVazio();

            //Ação
            Action action = endereco.Validar;

            //Verificar
            action.Should().Throw<EnderecoComplementoNuloOuVazioExcecao>();
        }
    }
}
