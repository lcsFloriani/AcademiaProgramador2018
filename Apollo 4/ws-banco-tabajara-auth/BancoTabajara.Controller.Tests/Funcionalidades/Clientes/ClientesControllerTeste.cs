using BancoTabajara.API.Controllers.Clientes;
using BancoTabajara.API.Excecoes;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Querys;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.ViewModels;
using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Controller.Tests.Inicializador;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BancoTabajara.Controller.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClientesControllerTeste : TestControllerBase
    {
        private ClientesController _clientesController;
        private Mock<IClienteServico> _clienteServicoMock;
        private Mock<ValidationResult> _validator;

        private Mock<Cliente> _cliente;
        private Mock<ClienteRegistraCommand> _registraCommand;
        private Mock<ClienteAtualizaCommand> _atualizaCommand;
        private Mock<ClienteDeletaCommand> _deletaCommand;
        private Mock<ClienteViewModel> _clienteViewModel;
        private Mock<ClienteQuery> _clienteQuery;
        
        private bool _ehValido = true;

        public object ErrorCodes { get; private set; }

        [SetUp]
        public void Inicializador()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _clienteServicoMock = new Mock<IClienteServico>();
            _clientesController = new ClientesController(_clienteServicoMock.Object)
            {
                Request = request
            };

            _cliente = new Mock<Cliente>();
            _registraCommand = new Mock<ClienteRegistraCommand>();
            _atualizaCommand = new Mock<ClienteAtualizaCommand>();
            _deletaCommand = new Mock<ClienteDeletaCommand>();
            _clienteViewModel = new Mock<ClienteViewModel>();
            _clienteQuery = new Mock<ClienteQuery>();

            _validator = new Mock<ValidationResult>();
            _validator.Setup(v => v.IsValid).Returns(_ehValido);
        }

        #region Adicionar
        [Test]
        public void Clientes_Controller_Adicionar_Deve_adicionar_um_novo_cliente_e_retornar_sucesso()
        {
            //Cenário
            long idEsperado = 1;

            _registraCommand.Setup(cmd => cmd.Validar()).Returns(_validator.Object);
            _clienteServicoMock.Setup(c => c.Adicionar(_registraCommand.Object)).Returns(idEsperado);
            
            //Ação
            IHttpActionResult callback = _clientesController.Adicionar(_registraCommand.Object);

            //Verifica
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(idEsperado);
            _clienteServicoMock.Verify(c => c.Adicionar(_registraCommand.Object), Times.Once);
        }

        [Test]
        public void Clientes_Controller_Nao_deve_adicionar_cliente_com_nome_nulo_ou_vazio()
        {
            //Cenário
            _ehValido = false;
            _validator.Setup(v => v.IsValid).Returns(_ehValido);
            _registraCommand.Setup(cmd => cmd.Validar()).Returns(_validator.Object);
            _clienteServicoMock.Setup(c => c.Adicionar(_registraCommand.Object));

            //Ação
            IHttpActionResult callback = _clientesController.Adicionar(_registraCommand.Object);

            //Verifica
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            _clienteServicoMock.VerifyNoOtherCalls();
        }

        #endregion Adicionar

        #region Atualizar
        [Test]
        public void Clientes_Controller_Atualizar_Deve_atualizar_um_cliente_e_retornar_sucesso()
        {
            // Cenário
            Cliente cliente = ObjetoMae.ObterClientePadraoComId();
            bool retorno = true;

            _atualizaCommand.Setup(cmd => cmd.Validar()).Returns(_validator.Object);
            _clienteServicoMock.Setup(c => c.Atualizar(_atualizaCommand.Object)).Returns(retorno);

            // Ação
            IHttpActionResult callback = _clientesController.Atualizar(_atualizaCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _clienteServicoMock.Verify(c => c.Atualizar(_atualizaCommand.Object), Times.Once);
        }

        [Test]
        public void Clientes_Controller_Nao_deve_atualizar_cliente_com_id_invalido()
        {
            //Cenário
            _ehValido = false;
            _validator.Setup(v => v.IsValid).Returns(_ehValido);
            _atualizaCommand.Setup(cmd => cmd.Validar()).Returns(_validator.Object);
            _clienteServicoMock.Setup(c => c.Atualizar(_atualizaCommand.Object));

            //Ação
            IHttpActionResult callback = _clientesController.Atualizar(_atualizaCommand.Object);

            //Verifica
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            _clienteServicoMock.VerifyNoOtherCalls();
        }

        #endregion Atualizar

        #region Listagem
        [Test]
        public void Clientes_Controller_Listagem_Deve_buscar_todos_os_clientes_e_retornar_sucesso()
        {
            //Cenário
            string uri = "http://localhost:57701/api/clientes?quantidade=3";
            Cliente cliente = ObjetoMae.ObterClientePadrao();

            var response = new List<Cliente>() { cliente }.AsQueryable();

            _clienteServicoMock.Setup(c => c.Listagem(It.IsAny<ClienteQuery>())).Returns(response);

            _clientesController.Request = GetUri(uri);

            //Ação
            var callback = _clientesController.Listagem();

            //Verifica
            _clienteServicoMock.Verify(c => c.Listagem(It.IsAny<ClienteQuery>()), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ClienteViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(cliente.Id);
        }
        #endregion Listagem

        #region BuscarPorId
        [Test]
        public void Clientes_Controller_BuscarPorId_Deve_buscar_um_cliente_por_id_e_retornar_sucesso()
        {
            //Cenário
            Cliente cliente = ObjetoMae.ObterClientePadrao();

            _clienteServicoMock.Setup(c => c.BuscarPorId(cliente.Id)).Returns(cliente);

            //Ação
            IHttpActionResult callback = _clientesController.BuscarPorId(cliente.Id);

            //Verifica
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ClienteViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(cliente.Id);
            _clienteServicoMock.Verify(c => c.BuscarPorId(cliente.Id), Times.Once);
        }

        //[Test]
        //public void Clientes_Controller_Nao_deve_buscar_cliente_por_id_quando_id_for_invalido()
        //{
        //    //Cenário
        //    Cliente cliente = ObjetoMae.ObterClientePadrao();
        //    long idPesquisa = 0;

        //    _clienteServicoMock.Setup(c => c.BuscarPorId(idPesquisa)).Throws<IdentificadorIndefinidoExcecao>();

        //    //Ação
        //    IHttpActionResult callback = _clientesController.BuscarPorId(idPesquisa);

        //    //Verifica
        //    var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<PayLoadExcecao>>().Subject;
        //    httpResponse.Content.CodigoErro.Should().Be((int)CodigoErro.ClientError);
        //    _clienteServicoMock.Verify(s => s.BuscarPorId(idPesquisa), Times.Once);
        //}

        #endregion BuscarPorId

        #region Excluir
        [Test]
        public void Clientes_Controller_Excluir_Deve_excluir_um_cliente_e_retornar_sucesso()
        {
            // Arrange
            Cliente cliente = ObjetoMae.ObterClientePadraoComId();
            bool retorno = true;

            _deletaCommand.Setup(cmd => cmd.Validar()).Returns(_validator.Object);
            _clienteServicoMock.Setup(c => c.Excluir(_deletaCommand.Object)).Returns(retorno);

            // Action
            IHttpActionResult callback = _clientesController.Excluir(_deletaCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _clienteServicoMock.Verify(c => c.Excluir(_deletaCommand.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Clientes_Controller_Nao_deve_excluir_cliente_quando_id_do_cliente_for_invalido()
        {
            //Cenário
            _ehValido = false;
            _validator.Setup(v => v.IsValid).Returns(_ehValido);
            _deletaCommand.Setup(cmd => cmd.Validar()).Returns(_validator.Object);
            _clienteServicoMock.Setup(c => c.Excluir(_deletaCommand.Object));

            //Ação
            IHttpActionResult callback = _clientesController.Excluir(_deletaCommand.Object);

            //Verifica
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            _clienteServicoMock.VerifyNoOtherCalls();
        }

        #endregion Excluir
    }
}
