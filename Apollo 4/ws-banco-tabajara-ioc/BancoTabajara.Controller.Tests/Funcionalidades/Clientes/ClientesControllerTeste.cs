using BancoTabajara.API.Controllers.Clientes;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Controller.Tests.Inicializador;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using FluentAssertions;
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

        private Mock<Cliente> _cliente;

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
        }

        #region Adicionar
        [Test]
        public void Clientes_Controller_Adicionar_Deve_adicionar_um_novo_cliente_e_retornar_sucesso()
        {
            //Cenário
            long idEsperado = 1;

            _clienteServicoMock.Setup(c => c.Adicionar(_cliente.Object)).Returns(idEsperado);

            //Ação
            IHttpActionResult callback = _clientesController.Adicionar(_cliente.Object);

            //Verifica
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(idEsperado);
            _clienteServicoMock.Verify(c => c.Adicionar(_cliente.Object), Times.Once);
        }
        #endregion Adicionar

        #region Atualizar
        [Test]
        public void Clientes_Controller_Atualizar_Deve_atualizar_um_cliente_e_retornar_sucesso()
        {
            // Cenário
            Cliente cliente = ObjetoMae.ObterClientePadraoComId();
            bool retorno = true;
            _clienteServicoMock.Setup(c => c.Atualizar(cliente)).Returns(retorno);

            // Ação
            IHttpActionResult callback = _clientesController.Atualizar(cliente);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _clienteServicoMock.Verify(c => c.Atualizar(cliente), Times.Once);
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

            int quantidade = 3;

            _clienteServicoMock.Setup(c => c.Listagem(quantidade)).Returns(response.ConverterParaListaDTO());

            _clientesController.Request = GetUri(uri);

            //Ação
            var callback = _clientesController.Listagem();

            //Verifica
            _clienteServicoMock.Verify(c => c.Listagem(quantidade), Times.Once);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ClienteDTO>>>().Subject;
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

            _clienteServicoMock.Setup(c => c.BuscarPorId(cliente.Id)).Returns(cliente.ConverterParaDTO());

            //Ação
            IHttpActionResult callback = _clientesController.BuscarPorId(cliente.Id);

            //Verifica
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ClienteDTO>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(cliente.Id);
            _clienteServicoMock.Verify(c => c.BuscarPorId(cliente.Id), Times.Once);
        }
        #endregion BuscarPorId
        
        #region Excluir
        [Test]
        public void Clientes_Controller_Excluir_Deve_excluir_um_cliente_e_retornar_sucesso()
        {
            // Arrange
            Cliente cliente = ObjetoMae.ObterClientePadraoComId();
            bool retorno = true;
            _clienteServicoMock.Setup(c => c.Excluir(cliente.Id)).Returns(retorno);
            // Action
            IHttpActionResult callback = _clientesController.Excluir(cliente.Id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _clienteServicoMock.Verify(c => c.Excluir(cliente.Id), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }
        #endregion Excluir
    }
}
