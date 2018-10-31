using BancoTabajara.API.Controllers.Contas;
using BancoTabajara.API.Excecoes;
using BancoTabajara.Aplicacao.Funcionalidades.Contas;
using BancoTabajara.Aplicacao.Funcionalidades.Extratos;
using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Controller.Tests.Inicializador;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BancoTabajara.Controller.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContasControllerTest : TestControllerBase
    {
        Mock<IContaServico> _contaServicoMock;
        ContasController _contasController;

        Mock<Conta> _conta;

        [SetUp]
        public void Inicializador()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            _contaServicoMock = new Mock<IContaServico>();

            _contasController = new ContasController(_contaServicoMock.Object)
            {
                Request = request
            };

            _conta = new Mock<Conta>();
        }

        #region Adicionar
        [Test]
        public void Contas_Controller_Adicionar_Deve_adicionar_uma_nova_conta_e_retornar_sucesso()
        {
            //Cenário
            long idEsperado = 1;

            _contaServicoMock.Setup(c => c.Adicionar(_conta.Object)).Returns(idEsperado);

            //Ação
            IHttpActionResult callback = _contasController.Adicionar(_conta.Object);

            //Verifica
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(idEsperado);
            _contaServicoMock.Verify(c => c.Adicionar(_conta.Object), Times.Once);
        }

        [Test]
        public void Contas_Controller_Adicionar_nao_deve_adicionar_conta_com_numero_da_conta_igual_a_zero_ou_negativo_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            _conta.Object.NumeroConta = 0;

            _contaServicoMock.Setup(c => c.Adicionar(_conta.Object)).Throws<ContaNumeroContaNegativoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Adicionar(_conta.Object);

            //Verifica
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            // Perceba que é um cenário onde o servico disporou a exception. Logo, ele deve ser chamado.
            _contaServicoMock.Verify(c => c.Adicionar(_conta.Object), Times.Once);
        }

        [Test]
        public void Contas_Controller_Adicionar_nao_deve_adicionar_conta_com_cliente_nulo_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            _conta.Object.Cliente = null;

            _contaServicoMock.Setup(c => c.Adicionar(_conta.Object)).Throws<ContaClienteNullExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Adicionar(_conta.Object);

            //Verifica
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            // Perceba que é um cenário onde o servico disporou a exception. Logo, ele deve ser chamado.
            _contaServicoMock.Verify(c => c.Adicionar(_conta.Object), Times.Once);
        }
        #endregion Adicionar

        #region Atualizar
        [Test]
        public void Contas_Controller_Atualizar_Deve_atualizar_uma_conta_e_retornar_sucesso()
        {
            // Cenário
            var eAtualizado = true;
            _contaServicoMock.Setup(c => c.Atualizar(_conta.Object)).Returns(eAtualizado);

            // Ação
            IHttpActionResult callback = _contasController.Atualizar(_conta.Object);
            // Verifica
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _contaServicoMock.Verify(s => s.Atualizar(_conta.Object), Times.Once);
        }

        [Test]
        public void Contas_Controller_Atualizar_Nao_Deve_atualizar_uma_conta_com_id_indefinido_e_Deve_retornar_erro_do_cliente()
        {
            // Cenário
            _contaServicoMock.Setup(c => c.Atualizar(_conta.Object)).Throws<IdentificadorIndefinidoExcecao>();

            // Ação
            IHttpActionResult callback = _contasController.Atualizar(_conta.Object);

            // Verifica
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            // Perceba que é um cenário onde o servico disporou a exception. Logo, ele deve ser chamado.
            _contaServicoMock.Verify(c => c.Atualizar(_conta.Object), Times.Once);
        }
        #endregion Atualizar

        #region Listagem
        [Test]
        public void Contas_Controller_Listagem_Deve_buscar_todas_as_contas_e_retornar_sucesso()
        {
            //Cenário
            string uri = "http://localhost:57701/api/contas?quantidade=3";
            Conta conta = ObjetoMae.ObterContaSemente();

            var response = new List<ContaDTO>() { conta.ConverterParaDTO() }.AsQueryable();

            int quantidade = 3;

            _contaServicoMock.Setup(c => c.Listagem(quantidade)).Returns(response);

            _contasController.Request = GetUri(uri);

            //Ação
            var callback = _contasController.Listagem();

            //Verifica
            _contaServicoMock.Verify(c => c.Listagem(quantidade), Times.Once);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ContaDTO>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(conta.Id);
        }
        #endregion Listagem

        #region BuscarPorId
        [Test]
        public void Contas_Controller_BuscarPorId_Deve_buscar_uma_conta_por_id_e_retornar_sucesso()
        {
            //Cenário
            ContaDTO conta = ObjetoMae.ObterContaValidaSemeada().ConverterParaDTO();
            long idBusca = 1;

            _contaServicoMock.Setup(c => c.BuscarPorId(idBusca)).Returns(conta);

            //Ação
            IHttpActionResult callback = _contasController.BuscarPorId(idBusca);

            //Verifica
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ContaDTO>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(idBusca);
            _contaServicoMock.Verify(c => c.BuscarPorId(idBusca), Times.Once);
        }

        [Test]
        public void Contas_Controller_BuscarPorId_Nao_Deve_buscar_uma_conta_com_id_indefinido_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            long idBusca = 0;

            _contaServicoMock.Setup(c => c.BuscarPorId(idBusca)).Throws<IdentificadorIndefinidoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.BuscarPorId(idBusca);

            //Verifica
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            // Perceba que é um cenário onde o servico disporou a exception. Logo, ele deve ser chamado.
            _contaServicoMock.Verify(c => c.BuscarPorId(idBusca), Times.Once);
        }

        [Test]
        public void Contas_Controller_BuscarPorId_Deve_retornar_erro_do_cliente_quando_conta_nao_for_encontrada_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            long idBusca = 500;

            _contaServicoMock.Setup(c => c.BuscarPorId(idBusca)).Throws<NaoEncontradoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.BuscarPorId(idBusca);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.NotFound);
            _contaServicoMock.Verify(c => c.BuscarPorId(idBusca), Times.Once);

        }

        [Test]
        public void Contas_Controller_BuscarPorId_Nao_Deve_buscar_uma_conta_que_não_exista()
        {
            //Cenário
            long idBusca = 20;

            _contaServicoMock.Setup(c => c.BuscarPorId(idBusca)).Throws<NaoEncontradoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.BuscarPorId(idBusca);

            //Verifica
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.NotFound);
            // Perceba que é um cenário onde o servico disporou a exception. Logo, ele deve ser chamado.
            _contaServicoMock.Verify(c => c.BuscarPorId(idBusca), Times.Once);
        }
        #endregion BuscarPorId

        #region Excluir
        [Test]
        public void Contas_Controller_Excluir_Deve_excluir_uma_conta_e_retornar_sucesso()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValidaSemeada();
            bool retorno = true;
            long id = 1;

            _contaServicoMock.Setup(c => c.Excluir(id)).Returns(retorno);

            //Ação
            IHttpActionResult callback = _contasController.Excluir(id);

            //Verifica
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().Be(retorno);
            _contaServicoMock.Verify(c => c.Excluir(id), Times.Once);
        }

        [Test]
        public void Contas_Controller_Excluir_Nao_Deve_excluir_uma_conta_com_id_indefinido_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            Conta conta = ObjetoMae.ObterContaValidaSemeada();
            long id = 1;


            _contaServicoMock.Setup(c => c.Excluir(id)).Throws<IdentificadorIndefinidoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Excluir(id);

            //Verifica
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            // Perceba que é um cenário onde o servico disporou a exception. Logo, ele deve ser chamado.
            _contaServicoMock.Verify(c => c.Excluir(id), Times.Once);
        }
        #endregion Excluir

        #region AlterarEstado
        [Test]
        public void Contas_Controller_AlterarEstado_Deve_alterar_o_estado_de_uma_conta_e_retornar_sucesso()
        {
            //Cenário
            var alterouEstado = true;
            var estado = false;
            var idConta = 1;

            _contaServicoMock.Setup(c => c.AlterarEstado(It.IsAny<long>(), It.IsAny<bool>())).Returns(alterouEstado);

            //Ação
            IHttpActionResult callback = _contasController.AlaterarEstado(idConta, estado);

            //Verificar
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _contaServicoMock.Verify(s => s.AlterarEstado(It.IsAny<long>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public void Contas_Controller_AlterarEstado_Nao_Deve_alterar_o_estado_de_uma_conta_com_id_indefinido_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            var estado = false;
            var idConta = 0;

            _contaServicoMock
                .Setup(c => c.AlterarEstado(It.IsAny<long>(), It.IsAny<bool>()))
                .Throws<IdentificadorIndefinidoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.AlaterarEstado(idConta, estado);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            _contaServicoMock.Verify(s => s.AlterarEstado(It.IsAny<long>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public void Contas_Controller_AlterarEstado_Nao_Deve_alterar_o_estado_de_uma_conta_quando_conta_nao_for_encontrada_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            var estado = false;
            var idConta = 500;

            _contaServicoMock
                .Setup(c => c.AlterarEstado(It.IsAny<long>(), It.IsAny<bool>()))
                .Throws<NaoEncontradoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.AlaterarEstado(idConta, estado);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.NotFound);
            _contaServicoMock.Verify(s => s.AlterarEstado(It.IsAny<long>(), It.IsAny<bool>()), Times.Once);

        }
        #endregion AlterarEstado

        #region Sacar
        [Test]
        public void Contas_Controller_Sacar_Deve_sacar_do_saldo_da_conta_e_retornar_sucesso()
        {
            //Cenário
            var alterouSaldo = true;
            var valorSaque = 50;
            var idConta = 1;

            _contaServicoMock.Setup(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>())).Returns(alterouSaldo);

            //Ação
            IHttpActionResult callback = _contasController.Sacar(idConta, valorSaque);

            //Verificar
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _contaServicoMock.Verify(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>()), Times.Once);

        }

        [Test]
        public void Contas_Controller_Sacar_Nao_Deve_sacar_do_saldo_da_conta_com_id_Indefinido_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            var valorSaque = 50;
            var idConta = 0;

            _contaServicoMock
                .Setup(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>()))
                .Throws<IdentificadorIndefinidoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Sacar(idConta, valorSaque);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            _contaServicoMock.Verify(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>()), Times.Once);
        }

        [Test]
        public void Contas_Controller_Sacar_Nao_Deve_sacar_do_saldo_da_conta_quando_valor_for_negativo_ou_zero_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            var valorSaque = 0;
            var idConta = 1;

            _contaServicoMock
                .Setup(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>()))
                .Throws<ContaValorNegativoOuZeroExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Sacar(idConta, valorSaque);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            _contaServicoMock.Verify(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>()), Times.Once);
        }

        [Test]
        public void Contas_Controller_Sacar_Nao_Deve_sacar_do_saldo_da_conta_quando_saldo_for_indisponivel_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            var valorSaque = 50;
            var idConta = 1;

            _contaServicoMock
                .Setup(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>()))
                .Throws<ContaSaldoIndisponivelExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Sacar(idConta, valorSaque);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            _contaServicoMock.Verify(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>()), Times.Once);
        }

        [Test]
        public void Contas_Controller_Sacar_Nao_Deve_sacar_do_saldo_quando_conta_nao_for_encontrada_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            var valorSaque = 50;
            var idConta = 1;

            _contaServicoMock
                .Setup(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>()))
                .Throws<NaoEncontradoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Sacar(idConta, valorSaque);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.NotFound);
            _contaServicoMock.Verify(c => c.Sacar(It.IsAny<long>(), It.IsAny<double>()), Times.Once);

        }
        #endregion Sacar

        #region Depositar
        [Test]
        public void Contas_Controller_Depositar_Deve_depositar_no_saldo_da_conta_e_retornar_sucesso()
        {
            //Cenário
            var alterouSaldo = true;
            var valorDeposito = 50;
            var idConta = 1;

            _contaServicoMock.Setup(c => c.Depositar(It.IsAny<long>(), It.IsAny<double>())).Returns(alterouSaldo);

            //Ação
            IHttpActionResult callback = _contasController.Depositar(idConta, valorDeposito);

            //Verificar
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _contaServicoMock.Verify(c => c.Depositar(It.IsAny<long>(), It.IsAny<double>()), Times.Once);

        }

        [Test]
        public void Contas_Controller_Depositar_Nao_Deve_depositar_no_saldo_da_conta_com_id_Indefinido_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            var valorDeposito = 50;
            var idConta = 0;

            _contaServicoMock
                .Setup(c => c.Depositar(It.IsAny<long>(), It.IsAny<double>()))
                .Throws<IdentificadorIndefinidoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Depositar(idConta, valorDeposito);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            _contaServicoMock.Verify(c => c.Depositar(It.IsAny<long>(), It.IsAny<double>()), Times.Once);
        }

        [Test]
        public void Contas_Controller_Depositar_Nao_Deve_depositar_no_saldo_da_conta_quando_valor_for_negativo_ou_zero_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            var valorDeposito = 0;
            var idConta = 1;

            _contaServicoMock
                .Setup(c => c.Depositar(It.IsAny<long>(), It.IsAny<double>()))
                .Throws<ContaValorNegativoOuZeroExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Depositar(idConta, valorDeposito);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            _contaServicoMock.Verify(c => c.Depositar(It.IsAny<long>(), It.IsAny<double>()), Times.Once);
        }

        [Test]
        public void Contas_Controller_Depositar_Nao_Deve_depositar_no_saldo_quando_conta_nao_for_encontrada_e_Deve_retornar_erro_do_cliente()
        {
            //Cenário
            var valorDeposito = 50;
            var idConta = 1;

            _contaServicoMock
                .Setup(c => c.Depositar(It.IsAny<long>(), It.IsAny<double>()))
                .Throws<NaoEncontradoExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.Depositar(idConta, valorDeposito);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.NotFound);
            _contaServicoMock.Verify(c => c.Depositar(It.IsAny<long>(), It.IsAny<double>()), Times.Once);

        }
        #endregion Depositar

        #region Transferir
        [Test]
        public void Contas_Controller_Realizar_Transferencia_Deve_transferir_saldo_de_uma_conta_para_outra()
        {
            //Cenário
            double valorDaTransferencia = 100;
            long idContaOrigem = 1;
            long idContaDestido = 2;
            var atualizou = true;

            _contaServicoMock.Setup(c => c.RealizarTransferencia(idContaOrigem, idContaDestido, valorDaTransferencia)).Returns(atualizou);

            //Ação
            IHttpActionResult callback = _contasController.RealizarTransferencia(idContaOrigem, idContaDestido, valorDaTransferencia);

            //Verificar
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _contaServicoMock.Verify(s => s.RealizarTransferencia(idContaOrigem, idContaDestido, valorDaTransferencia));
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Contas_Controller_RealizarTransferencia_Nao_Deve_transferir_o_saldo_de_uma_conta_para_outra_quando_valor_for_negativo_ou_zero()
        {
            //Cenário
            double valorDaTransferencia = 0;
            long idContaOrigem = 1;
            long idContaDestido = 2;

            _contaServicoMock.Setup(c => c.RealizarTransferencia(idContaOrigem, idContaDestido, valorDaTransferencia)).Throws<ContaValorNegativoOuZeroExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.RealizarTransferencia(idContaOrigem, idContaDestido, valorDaTransferencia);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            _contaServicoMock.Verify(c => c.RealizarTransferencia(idContaOrigem, idContaDestido, valorDaTransferencia), Times.Once);
        }

        [Test]
        public void Contas_Controller_RealizarTransferencia_Nao_Deve_transferir_com_uma_das_nao_encontrada()
        {
            //Cenário
            double valorDaTransferencia = 100;
            long idContaOrigem = 0;
            long idContaDestido = 2;

            _contaServicoMock.Setup(c => c.RealizarTransferencia(idContaOrigem, idContaDestido, valorDaTransferencia)).Throws<ContaValorNegativoOuZeroExcecao>();

            //Ação
            IHttpActionResult callback = _contasController.RealizarTransferencia(idContaOrigem, idContaDestido, valorDaTransferencia);

            //Verificar
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
            _contaServicoMock.Verify(c => c.RealizarTransferencia(idContaOrigem, idContaDestido, valorDaTransferencia), Times.Once);
        }

        #endregion Transferir

        #region GerarExtrato
        [Test]
        public void Contas_Controller_GerarExtrato_Deve_gerar_extrato_da_conta_e_retornar_sucesso()
        {
            //Cenário
            ExtratoDTO extrato = ObjetoMae.ObterExtrato().ConverterParaDTO();
            long idConta = 1;

            _contaServicoMock.Setup(c => c.GerarExtrato(idConta)).Returns(extrato);

            //Ação
            IHttpActionResult callback = _contasController.GerarExtrato(idConta);

            //Verifica
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ExtratoDTO>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.NomeCliente.Should().Be(extrato.NomeCliente);
            _contaServicoMock.Verify(c => c.GerarExtrato(idConta));
        }
        #endregion GerarExtrato
    }
}
