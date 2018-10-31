using BancoTabajara.API.Excecoes;
using BancoTabajara.API.Models;
using BancoTabajara.Controller.Tests.Inicializador;
using BancoTabajara.Dominio.Excecoes;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace BancoTabajara.Controller.Tests.Comum
{
    [TestFixture]
    public class ApiControllerBaseTests : TestControllerBase
    {
        /* Perceba que esse fake serve apenas para expor os comportamentos de ApiControllerBase */
        private ApiControllerBaseFake _apiControllerBase;
        private Mock<ApiControllerBaseDummy> _dummy;


        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _apiControllerBase = new ApiControllerBaseFake()
            {
                Request = request
            };
            _dummy = new Mock<ApiControllerBaseDummy>();
        }

        #region HandleCallback

        [Test]
        public void Base_Controller_HandleCallback_ShouldBeOk()
        {
            // Action
            var callback = _apiControllerBase.HandleCallback(_dummy.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ApiControllerBaseDummy>>().Subject;
            httpResponse.Content.Should().Be(_dummy.Object);
        }

        #endregion

        #region HandleQuery

        [Test]
        public void Base_Controller_HandleQuery_ShouldBeOk()
        {
            // Action
            var callback = _apiControllerBase.HandleQuery<ApiControllerBaseDummy, ApiControllerBaseDummyViewModel>(_dummy.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ApiControllerBaseDummyViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }


        #endregion

        #region HandleQueryable
        [Test]
        public void Base_Controller_HandleQueryable_ShouldBeOk()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            // Action
            var callback = _apiControllerBase.HandleQueryable<ApiControllerBaseDummy, ApiControllerBaseDummyViewModel>(query);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ApiControllerBaseDummyViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        #endregion

        #region HandleValidationFailure

        [Test]
        public void Base_Controller_HandleValidationFailure_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var validationFailure = new ValidationFailure("", ((int)CodigoErro.Unhandled).ToString());
            IList<ValidationFailure> errors = new List<ValidationFailure>() { validationFailure };
            // Action
            var callback = _apiControllerBase.HandleValidationFailure(errors);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.FirstOrDefault().Should().Be(validationFailure);
        }

        #endregion
    }
}