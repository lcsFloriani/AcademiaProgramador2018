using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Dominio.Enum;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using BancoTabajara.Infra.ORM.Funcionalidades.Contas;
using BancoTabajara.Infra.ORM.Tests.Contexto;
using BancoTabajara.Infra.ORM.Tests.Inicializador;

using Effort;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoTabajara.Infra.ORM.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContaRepositorioTeste : EffortBaseTeste
    {
        private ContaRepositorio _repositorio;
        private Cliente _cliente;

        private int _igualZero = 0;

        [SetUp]
        public void Inicializar()
        {
            _repositorio = new ContaRepositorio(contexto);

            _cliente = ObjetoMae.ObterClienteSemeado();
        }

        [Test]
        public void Contas_InfraORM_Deve_adicionar_conta()
        {
            //Cenario
            Conta conta = ObjetoMae.ObterContaValida(_cliente);

            //Ação
            Conta contaRegistrada = _repositorio.Adicionar(conta);

            //Verificação
            contaRegistrada.Should().NotBeNull();
            contaRegistrada.Id.Should().NotBe(_igualZero);

            var contaEsperada = _repositorio.BuscarPorId(contaRegistrada.Id);
            contaEsperada.Should().NotBeNull();
            contaEsperada.Should().Be(contaRegistrada);
        }

        [Test]
        public void Contas_InfraORM_Deve_atualizar_conta()
        {
            //Cenario
            long idBusca = 1;
            bool retorno = true;

            Conta conta = _repositorio.BuscarPorId(idBusca);
            double limiteAntigo = conta.Limite;
            conta.Limite = 15000;
            //Ação
            bool resultado = _repositorio.Atualizar(conta);

            //Verificação
            resultado.Should().Be(retorno);
            var contaAtualizada = _repositorio.BuscarPorId(idBusca);
            contaAtualizada.Limite.Should().NotBe(limiteAntigo);
        }

        [Test]
        public void Contas_InfraORM_Deve_atualizar_conta_e_salvar_uma_saque()
        {
            //Cenario
            long primeiroId = 1;
            bool retorno = true;
            double saque = 25;
            double saldoEsperado = 1375;

            Conta conta = _repositorio.BuscarPorId(primeiroId);
            conta.Sacar(saque);

            //Ação
            bool resultado = _repositorio.AtualizarComMovimentacao(OperacaoContaEnum.SaqueOuDeposito,conta);

            //Verificação
            resultado.Should().Be(retorno);
            Conta resultado1 = _repositorio.BuscarPorId(primeiroId);
            resultado1.Saldo.Should().Be(saldoEsperado);
        }

        [Test]
        public void Contas_InfraORM_Deve_atualizar_conta_e_salvar_uma_transferencia()
        {
            //Cenario
            long primeiroId = 1;
            long segundoId = 2;
            bool retorno = true;

            double saldoConta1Atual = 900;
            double saldoConta2Atual = 2725;
            double transferecia = 500;

            Conta conta1 = _repositorio.BuscarPorId(primeiroId);
            Conta conta2 = _repositorio.BuscarPorId(segundoId);
            conta1.RealizarTransferencia(transferecia,conta2);

            //Ação
            bool resultado = _repositorio.AtualizarComMovimentacao(OperacaoContaEnum.Transferencia,conta1,conta2);

            //Verificação
            resultado.Should().Be(retorno);
            Conta resultado1 = _repositorio.BuscarPorId(primeiroId);
            Conta resultado2 = _repositorio.BuscarPorId(segundoId);
            resultado1.Saldo.Should().Be(saldoConta1Atual);
            resultado2.Saldo.Should().Be(saldoConta2Atual);
        }

        [Test]
        public void Contas_InfraORM_Deve_atualizar_estado_da_conta()
        {
            //Cenario
            long idBusca = 1;
            Conta conta = _repositorio.BuscarPorId(idBusca);
            conta.Estado = false;

            //Ação
            _repositorio.AtualizarEstado(conta);

            //Verificação
            Conta resultado = _repositorio.BuscarPorId(idBusca);
            resultado.Estado.Should().Be(conta.Estado);
        }

        [Test]
        public void Contas_InfraORM_Deve_buscar_conta_por_id()
        {
            //Cenario
            long id = 1;

            //Ação
            Conta resultado = _repositorio.BuscarPorId(id);

            //Verificação
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(id);
            resultado.Movimentacoes.Should().NotBeNull();
            resultado.Cliente.Should().NotBeNull();
        }

        [Test]
        public void Contas_InfraORM_Nao_deve_buscar_conta_por_id_que_nao_exista()
        {
            //Cenario
            long id = 20;

            //Ação
            Action acao = () => _repositorio.BuscarPorId(id);

            //Verificação
            acao.Should().Throw<NaoEncontradoExcecao>();
        }

        [Test]
        public void Contas_InfraORM_Deve_buscar_todas_as_contas()
        {
            //Cenario
            int tamanhoLista = 2;
            int quantidade = 3;


            //Ação
            var resultado = _repositorio.Listagem(quantidade);

            //Verificação
            resultado.Should().NotBeNull();
            resultado.Count().Should().Be(tamanhoLista);
        }

        [Test]
        public void Contas_InfraORM_Deve_excluir_uma_conta()
        {
            //Cenario
            long id = 1;
            Conta conta = _repositorio.BuscarPorId(id);

            bool retorno = true;

            //Ação
            bool resultado = _repositorio.Excluir(conta);

            //Verificação
            resultado.Should().Be(retorno);
            Action acao = () => _repositorio.BuscarPorId(id);
            acao.Should().Throw<NaoEncontradoExcecao>();
        }

        [Test]
        public void Contas_InfraORM_Deve_verificar_numero_da_conta_e_retornar_true()
        {
            //Cenário
            long id = 1;
            Conta conta = _repositorio.BuscarPorId(id);

            //Ação
            bool resultado = _repositorio.VerificarNumeroConta(conta);

            //Verificar
            resultado.Should().BeTrue();
        }

        [Test]
        public void Contas_InfraORM_Deve_verificar_numero_da_conta_e_retornar_false()
        {
            //Cenário
            long id = 1;
            Conta conta = _repositorio.BuscarPorId(id);
            conta.NumeroConta = 111;

            //Ação
            bool resultado = _repositorio.VerificarNumeroConta(conta);

            //Verificar
            resultado.Should().BeFalse();
        }
    }
}
