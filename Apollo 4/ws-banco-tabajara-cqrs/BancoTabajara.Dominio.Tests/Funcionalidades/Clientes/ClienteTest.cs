using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace BancoTabajara.Dominio.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClienteTest
    {

        [SetUp]
        public void Inicializacao()
        {
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_com_todos_os_campos_validos()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClientePadrao();

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_com_nome_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClienteComNomeNuloOuVazio();

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().Throw<ClienteNomeNuloOuVazioExcecao>();
        }
        
        [Test]
        public void Clientes_Domain_Verificar_cliente_com_CPF_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClienteComCPFNuloOuVazio();

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().Throw<ClienteCPFNuloOuVazioExcecao>();
        }

        [Test]
        public void Clientes_Domain_Verificar_cliente_com_RG_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClienteComRGNuloOuVazio();

            //Ação
            Action action = cliente.Validar;

            //Verificar
            action.Should().Throw<ClienteRGNuloOuVazioExcecao>();
        }
    }
}
