using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Dominio.Enum;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Dominio.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContaTeste
    {
        private Mock<Cliente> _fakeCliente;

        [SetUp]
        public void Inicializador()
        {
            _fakeCliente = new Mock<Cliente>();
        }
     
         [Test]
        public void Contas_Dominio_Deve_validar_conta_com_todos_os_campos_obrigatorios()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

            //Ação
            Action action = conta.Validar;

            //Verifica
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Contas_Dominio_Nao_deve_validar_conta_com_numero_da_conta_invalido()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaComNumeroInvalido();

            //Ação
            Action action = conta.Validar;

            //Verifica
            action.Should().Throw<ContaNumeroContaNegativoExcecao>();
        }

        [Test]
        public void Contas_Dominio_Nao_deve_validar_conta_com_cliente_nulo()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaComClienteIdInvalido();

            //Ação
            Action action = conta.Validar;

            //Verifica
            action.Should().Throw<ContaClienteNullExcecao>();
        }

        [Test]
        public void Contas_Dominio_Deve_validar_conta_com_saldo_total()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

            double saldoTotal = 100;

            //Ação
            double resultado = conta.SaldoTotal;

            //Verifica
            resultado.Should().Be(saldoTotal);
        }

        [Test]
        public void Contas_Dominio_Deve_validar_saque_na_conta()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

            double valor = 50;
            double saldoAtual = 50;
            
            //Ação
            conta.Sacar(valor);

            //Verifica
            conta.SaldoTotal.Should().Be(saldoAtual);
            conta.Movimentacoes.Last().Valor.Should().Be(valor);
            conta.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoEnum.Debito);
        }

        [Test]
        public void Contas_Dominio_Nao_deve_validar_saque_na_conta()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

            double valor = 110;

            //Ação
            Action action = () => conta.Sacar(valor);

            //Verifica
            action.Should().Throw<ContaSaldoIndisponivelExcecao>();
        }

        [Test]
        public void Contas_Dominio_Nao_deve_validar_saque_na_conta_valor_De_saque_negativo_ou_zero()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

            double valor = 0;

            //Ação
            Action action = () => conta.Sacar(valor);

            //Verifica
            action.Should().Throw<ContaValorNegativoOuZeroExcecao>();
        }

        [Test]
        public void Contas_Dominio_Deve_validar_deposito_na_conta()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

            double valor = 50;
            double saldoAtual = 150;

            //Ação
            conta.Depositar(valor);

            //Verifica
            conta.SaldoTotal.Should().Be(saldoAtual);
            conta.Movimentacoes.Last().Valor.Should().Be(valor);
            conta.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoEnum.Credito);
        }

        [Test]
        public void Contas_Dominio_Nao_deve_validar_deposito_na_conta_valor_De_saque_negativo_ou_zero()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

            double valor = 0;

            //Ação
            Action action = () => conta.Depositar(valor);

            //Verifica
            action.Should().Throw<ContaValorNegativoOuZeroExcecao>();
        }

        [Test]
        public void Contas_Dominio_Deve_validar_transferencia_em_outra_conta()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

            Conta destinatario = ObjetoMae.ObterContaDestinatario();

            double valor = 40;
            double saldoAtual = 60;
            double saldoAtualDestinatario = 40;

            //Ação
            conta.RealizarTransferencia(valor, destinatario);

            //Verifica
            conta.SaldoTotal.Should().Be(saldoAtual);
            conta.Movimentacoes.Last().Valor.Should().Be(valor);
            conta.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoEnum.Debito);

            destinatario.SaldoTotal.Should().Be(saldoAtualDestinatario);
            destinatario.Movimentacoes.Last().Valor.Should().Be(valor);
            destinatario.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoEnum.Credito);
        }

        //[Test]
        //public void Contas_Dominio_Deve_gerar_um_extrato()
        //{
        //    //Cenário
        //    Conta conta = ObjetoMae.ObterContaValidaComCliente(_fakeCliente.Object);
        //    conta.Id = 1;

        //    _fakeCliente.Object.Nome = "Teste";
        //    _fakeCliente.Object.Id = 1;

        //    //Ação
        //    Extrato extrato = conta.GerarExtrato();

        //    //Verifica]
        //    extrato.NumeroConta.Should().Be(conta.NumeroConta);
        //    extrato.NomeCliente.Should().Be(_fakeCliente.Object.Nome);
        //    extrato.Movimentacoes.Count().Should().Be(conta.Movimentacoes.Count());
        //    extrato.SaldoDisponivel.Should().Be(conta.Saldo);
        //    extrato.LimiteAtual.Should().Be(conta.Limite);
        //}
    }
}
