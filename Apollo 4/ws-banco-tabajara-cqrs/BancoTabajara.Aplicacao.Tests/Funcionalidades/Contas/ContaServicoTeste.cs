using BancoTabajara.Aplicacao.Funcionalidades.Contas;
using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Dominio.Enum;
using BancoTabajara.Dominio.Excecoes;
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

namespace BancoTabajara.Aplicacao.Tests.Funcionalidades.Contas
{
    //Comentario de teste   

    [TestFixture]
    public class ContaServicoTeste
    {
        private Mock<IContaRepositorio> _mockRepositorio;
        private Mock<Cliente> _fakeCliente;
        private IContaServico _servico;

        [SetUp]
        public void Inicializar()
        {
            _mockRepositorio = new Mock<IContaRepositorio>();
            _fakeCliente = new Mock<Cliente>();

            //_servico = new ContaServico(_mockRepositorio.Object);
        }

//        [Test]
//        public void Contas_Aplicacao_Deve_adicionar_conta()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

//            long idEsperado = 1;

//            _mockRepositorio.Setup(m => m.Adicionar(conta)).Returns(new Conta() { Id = 1 });

//            //Ação
//            long resultado = _servico.Adicionar(conta);

//            //Verificar
//            resultado.Should().Be(idEsperado);
//            _mockRepositorio.Verify(repository => repository.Adicionar(conta));
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_adicionar_conta_com_cliente_id_invalido()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaComClienteIdInvalido();

//            //Ação
//            Action action = () => _servico.Adicionar(conta);

//            //Verificar
//            action.Should().Throw<ContaClienteNullExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }

//        [Test]
//        public void Contas_Aplicacao_Deve_atualizar_conta()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);
//            conta.Id = 1;

//            bool retorno = true;

//            _mockRepositorio.Setup(m => m.VerificarNumeroConta(conta)).Returns(retorno);
//            _mockRepositorio.Setup(m => m.Atualizar(conta)).Returns(retorno);

//            //Ação
//            bool resultado = _servico.Atualizar(conta);

//            //Verificar
//            resultado.Should().Be(retorno);
//            _mockRepositorio.Verify(repository => repository.VerificarNumeroConta(conta));
//            _mockRepositorio.Verify(repository => repository.Atualizar(conta));
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_atualizar_conta_com_numero_de_conta_alterado()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);
//            conta.Id = 1;

//            bool retorno = false;

//            _mockRepositorio.Setup(m => m.VerificarNumeroConta(conta)).Returns(retorno);

//            //Ação
//            Action action = () => _servico.Atualizar(conta);

//            //Verificar
//            action.Should().Throw<ContaNumeroContaAlteradoExcecao>();
//            _mockRepositorio.Verify(repository => repository.VerificarNumeroConta(conta));
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_atualizar_conta_com_numero_de_conta_invalido()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaComNumeroInvalido();
//            conta.Id = 1;

//            //Ação
//            Action action = () => _servico.Atualizar(conta);

//            //Verificar
//            action.Should().Throw<ContaNumeroContaNegativoExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_atualizar_conta_com_id_invalido()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaIdInvalido(_fakeCliente.Object);

//            //Ação
//            Action action = () => _servico.Atualizar(conta);

//            //Verificar
//            action.Should().Throw<IdentificadorIndefinidoExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }

//        [Test]
//        public void Contas_Aplicacao_Deve_buscar_conta_por_id()
//        {
//            //Cenário
//            long idBusca = 1;
//            Conta resultadoBusca = ObjetoMae.ObterContaSemente();

//            _mockRepositorio.Setup(m => m.BuscarPorId(idBusca)).Returns(resultadoBusca);

//            //Ação
//            ContaDTO resultado = _servico.BuscarPorId(idBusca);

//            //Verificar
//            resultado.Should().NotBeNull();
//            _mockRepositorio.Verify(repository => repository.BuscarPorId(idBusca));
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_buscar_conta_por_id_com_id_invalido()
//        {
//            //Cenário
//            long id = 0;

//            //Ação
//            Action action = () => _servico.BuscarPorId(id);

//            //Verificar
//            action.Should().Throw<IdentificadorIndefinidoExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }

//        [Test]
//        public void Contas_Aplicacao_Deve_listar_todos_os_clientes()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaSemente();
//            int quantidade = 1;

//            var lista = new List<Conta> { conta }.AsQueryable();

//            _mockRepositorio.Setup(m => m.Listagem(quantidade)).Returns(lista);

//            //Ação
//            var contas = _servico.Listagem(quantidade);

//            //Verificar
//            contas.Should().NotBeNull();
//            contas.First().Id.Should().Be(conta.Id);
//            _mockRepositorio.Verify(repository => repository.Listagem(quantidade));
//        }

//        [Test]
//        public void Contas_Aplicacao_Deve_excluir_conta()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaValidaSemeada();
//            bool retorno = true;
//            long id = 1;

//            _mockRepositorio.Setup(m => m.Excluir(conta)).Returns(retorno);
//            _mockRepositorio.Setup(m => m.BuscarPorId(It.IsAny<long>())).Returns(conta);

//            //Ação
//            bool resultado = _servico.Excluir(id);

//            //Verificar
//            resultado.Should().BeTrue();
//            _mockRepositorio.Verify(repository => repository.Excluir(conta));
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_excluir_conta_com_id_invalido()
//        {
//            //Cenário
////            Conta conta = ObjetoMae.ObterContaIdInvalido(_fakeCliente.Object);
//            long id = 0;

//            //Ação
//            Action action = () => _servico.Excluir(id);

//            //Verificar
//            action.Should().Throw<IdentificadorIndefinidoExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }
        
//        [Test]
//        public void Contas_Aplicacao_Sacar_Deve_realizar_saque_na_conta_e_retornar_true()
//        {
//            //Cenário
//            bool retorno = true;
//            double valor = 20;
//            double saldoAtual = 80;

//            Conta conta = ObjetoMae.ObterContaValidaSemeada();

//            _mockRepositorio.Setup(c => c.BuscarPorId(It.IsAny<long>())).Returns(conta);
//            _mockRepositorio.Setup(c => c.AtualizarComMovimentacao(It.IsAny<OperacaoContaEnum>(),It.IsAny<Conta>())).Returns(retorno);
            
//            //Ação
//            var retornoSacar = _servico.Sacar(conta.Id, valor);

//            //Verificar
//            retornoSacar.Should().BeTrue();
//            conta.SaldoTotal.Should().Be(saldoAtual);
//            conta.Movimentacoes.Last().Valor.Should().Be(valor);
//            conta.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoEnum.Debito);
//            _mockRepositorio.Verify(c => c.BuscarPorId(It.IsAny<long>()));
//            _mockRepositorio.Verify(c => c.AtualizarComMovimentacao(It.IsAny<OperacaoContaEnum>(), It.IsAny<Conta>()));
//        }
               
//        [Test]
//        public void Contas_Aplicacao_Sacar_Nao_deve_realizar_saque_na_conta_com_valor_negativo_ou_zero()
//        {
//            //Cenário
//            long contaId = 1;
//            double valor = -20;

//            Conta conta = ObjetoMae.ObterContaValidaSemeada();

//            _mockRepositorio.Setup(c => c.BuscarPorId(It.IsAny<long>())).Returns(conta);

//            //Ação
//            Action action = () => _servico.Sacar(contaId, valor);

//            //Verificar
//            action.Should().Throw<ContaValorNegativoOuZeroExcecao>();
//            _mockRepositorio.Verify(c => c.BuscarPorId(It.IsAny<long>()));
//            _mockRepositorio.Verify(c => c.AtualizarComMovimentacao(It.IsAny<OperacaoContaEnum>(), It.IsAny<Conta>()), Times.Never);
//        }

//        [Test]
//        public void Contas_Aplicacao_Sacar_Nao_deve_realizar_saque_na_conta_com_id_invalido()
//        {
//            //Cenário
//            long contaId = 0;
//            double valor = -20;

//            Conta conta = ObjetoMae.ObterContaValidaSemeada();

//            //Ação
//            Action action = () => _servico.Sacar(contaId, valor);

//            //Verificar
//            action.Should().Throw<IdentificadorIndefinidoExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }

//        [Test]
//        public void Contas_Aplicacao_Depositar_Deve_realizar_deposito_na_conta_e_retornar_true()
//        {
//            //Cenário
//            long contaId = 1;
//            bool retorno = true;
//            double valor = 20;
//            double saldoAtual = 120;

//            Conta conta = ObjetoMae.ObterContaValidaSemeada();

//            _mockRepositorio.Setup(c => c.BuscarPorId(It.IsAny<long>())).Returns(conta);
//            _mockRepositorio.Setup(c => c.AtualizarComMovimentacao(It.IsAny<OperacaoContaEnum>(),It.IsAny<Conta>())).Returns(retorno);

//            //Ação
//            var retornoDepositar = _servico.Depositar(contaId, valor);

//            //Verificar
//            retornoDepositar.Should().BeTrue();
//            conta.SaldoTotal.Should().Be(saldoAtual);
//            conta.Movimentacoes.Last().Valor.Should().Be(valor);
//            conta.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoEnum.Credito);
//            _mockRepositorio.Verify(c => c.BuscarPorId(It.IsAny<long>()));
//            _mockRepositorio.Verify(c => c.AtualizarComMovimentacao(It.IsAny<OperacaoContaEnum>(),It.IsAny<Conta>()));
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_realizar_deposito_na_conta_com_valor_negativo()
//        {
//            //Cenário
//            long idBusca = 1;
//            double valor = -20;

//            Conta conta = ObjetoMae.ObterContaValidaSemeada();

//            _mockRepositorio.Setup(c => c.BuscarPorId(idBusca)).Returns(conta);
           
//            //Ação
//            Action action = () => _servico.Depositar(idBusca, valor);

//            //Verificar
//            action.Should().Throw<ContaValorNegativoOuZeroExcecao>();
//            _mockRepositorio.Verify(c => c.BuscarPorId(idBusca));
//            _mockRepositorio.Verify(c => c.AtualizarComMovimentacao(It.IsAny<OperacaoContaEnum>(),conta), Times.Never());
//        }

//        [Test]
//        public void Contas_Aplicacao_Deve_realizar_transferencia_na_conta_para_destinatario()
//        {
//            //Cenário
//            bool retorno = true;
//            long contaId = 1;
//            long destinatarioId = 2;
//            double valor = 300;

//            Conta conta = ObjetoMae.ObterContaSemente();

//            _mockRepositorio.Setup(m => m.BuscarPorId(It.IsAny<long>())).Returns(conta);
//            _mockRepositorio.Setup(m => m.AtualizarComMovimentacao(It.IsAny<OperacaoContaEnum>(), It.IsAny<Conta>(), It.IsAny<Conta>())).Returns(retorno);

//            //Ação
//            bool resultado = _servico.RealizarTransferencia(contaId, destinatarioId, valor);

//            //Verificar
//            resultado.Should().Be(retorno);
//            _mockRepositorio.Verify(repository => repository.BuscarPorId(It.IsAny<long>()));
//            _mockRepositorio.Verify(repository => repository.AtualizarComMovimentacao(It.IsAny<OperacaoContaEnum>(),It.IsAny<Conta>(), It.IsAny<Conta>()));
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_realizar_transferencia_com_valor_negativo()
//        {
//            //Cenário
//            long contaId = 1;
//            long destinatarioId = 2;
//            double valor = -20;

//            Conta conta = ObjetoMae.ObterContaValidaSemeada();

//            _mockRepositorio.Setup(m => m.BuscarPorId(It.IsAny<long>())).Returns(conta);
//            //Ação
//            Action action = () => _servico.RealizarTransferencia(contaId, destinatarioId, valor);

//            //Verificar
//            action.Should().Throw<ContaValorNegativoOuZeroExcecao>();
//            _mockRepositorio.Verify(repository => repository.BuscarPorId(It.IsAny<long>()));
//            _mockRepositorio.Verify(repository => repository.AtualizarComMovimentacao(It.IsAny<OperacaoContaEnum>(),It.IsAny<Conta>()), Times.Never);
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_realizar_transferencia_com_conta_com_id_invalido()
//        {
//            //Cenário
//            long contaId = 0;
//            long destinatarioId = 2;
//            double valor = 20;

//            Conta conta = ObjetoMae.ObterContaValidaSemeada();

//            _mockRepositorio.Setup(m => m.BuscarPorId(It.IsAny<long>())).Returns(conta);
//            //Ação
//            Action action = () => _servico.RealizarTransferencia(contaId, destinatarioId, valor);

//            //Verificar
//            action.Should().Throw<IdentificadorIndefinidoExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }

//        [Test]
//        public void Contas_Aplicacao_Nao_deve_realizar_transferencia_com_conta_do_destinatario_com_id_invalido()
//        {
//            //Cenário
//            long contaId = 1;
//            long destinatarioId = 0;
//            double valor = 20;

//            Conta conta = ObjetoMae.ObterContaValidaSemeada();

//            _mockRepositorio.Setup(m => m.BuscarPorId(It.IsAny<long>())).Returns(conta);
//            //Ação
//            Action action = () => _servico.RealizarTransferencia(contaId, destinatarioId, valor);

//            //Verificar
//            action.Should().Throw<IdentificadorIndefinidoExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }
        
//        [Test]
//        public void Contas_Aplicacao_Deve_atualizar_o_estado_da_conta()
//        {
//            //Cenário
//            bool estado = false;
//            long idBusca = 1;

//            Conta contaEncontrada = ObjetoMae.ObterContaValidaSemeada();

//            _mockRepositorio.Setup(c => c.BuscarPorId(idBusca)).Returns(contaEncontrada);
//            _mockRepositorio.Setup(c => c.AtualizarEstado(contaEncontrada)).Returns(true);

//            //Ação
//            bool  resultado =_servico.AlterarEstado(idBusca, estado);

//            //Verificar
//            resultado.Should().BeTrue();
//            _mockRepositorio.Verify(repository => repository.BuscarPorId(idBusca));
//            _mockRepositorio.Verify(repository => repository.AtualizarEstado(contaEncontrada));
//        }
        
//        [Test]
//        public void Contas_Aplicacao_Nao_deve_atualizar_o_estado_da_conta_com_id_invalido()
//        {
//            //Cenário
//            bool estado = false;
//            long idBusca = 0;

//            Conta contaEncontrada = ObjetoMae.ObterContaValidaSemeada();

//            //Ação
//            Action action = () =>_servico.AlterarEstado(idBusca, estado);

//            //Verificar
//            action.Should().Throw<IdentificadorIndefinidoExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }

//        [Test]
//        public void Contas_Aplicacao_GerarExtrato_Deve_gerar_o_extrato_e_retornar_um_extrato()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaValidaSemeada();

//            _mockRepositorio.Setup(c => c.BuscarPorId(It.IsAny<long>())).Returns(conta);

//            //Ação
//            ExtratoDTO extrato = _servico.GerarExtrato(conta.Id);

//            //Verificar
//            extrato.NumeroConta.Should().Be(conta.NumeroConta);
//            extrato.NomeCliente.Should().Be(conta.Cliente.Nome);
//            extrato.Movimentacoes.Count().Should().Be(conta.Movimentacoes.Count());
//            extrato.SaldoDisponivel.Should().Be(conta.Saldo);
//            extrato.LimiteAtual.Should().Be(conta.Limite);
//            _mockRepositorio.Verify(c => c.BuscarPorId(It.IsAny<long>()));
//        }

//        [Test]
//        public void Contas_Aplicacao_GerarExtrato_Nao_deve_gerar_o_extrato_com_id_invalido()
//        {
//            //Cenário
//            Conta conta = ObjetoMae.ObterContaValida(_fakeCliente.Object);

//            //Ação
//            Action action = () => _servico.GerarExtrato(conta.Id);

//            //Verificar
//            action.Should().Throw<IdentificadorIndefinidoExcecao>();
//            _mockRepositorio.VerifyNoOtherCalls();
//        }
    }
}
