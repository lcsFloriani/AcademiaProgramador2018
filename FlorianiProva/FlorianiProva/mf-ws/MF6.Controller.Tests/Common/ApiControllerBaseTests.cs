using FluentAssertions;
using FluentValidation.Results;
using MF6.API.Exceptions;
using MF6.API.Models;
using MF6.Controller.Tests.Initializer;
using MF6.Domain.Exceptions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace MF6.Controller.Tests.Common
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
        public void Base_Controller_HandleCallback_ShouldHandleBusinessException()
        {
            //Arrange
            var message = "message error test";
            var exception = new ExcecaoDeNegocio(CodigoErros.AlreadyExists, message);
            // Action
            var callback = _apiControllerBase.HandleCallback<ApiControllerBaseDummy>(() => throw exception);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            httpResponse.Content.ErrorCode.Should().Be((int)CodigoErros.AlreadyExists);
            httpResponse.Content.ErrorMessage.Should().Be(message);
        }

        [Test]
        public void Base_Controller_HandleCallback_ShouldHandleRuntimeException()
        {
            //Arrange
            var message = "message error test";
            var exception = new Exception(message);
            // Action
            var callback = _apiControllerBase.HandleCallback<ApiControllerBaseDummy>(() => throw exception);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            httpResponse.Content.ErrorCode.Should().Be((int)CodigoErros.Unhandled);
            httpResponse.Content.ErrorMessage.Should().Be(message);
        }

        #endregion HandleCallback

        #region HandleQuery

        [Test]
        public void Base_Controller_HandleQuery_ShouldBeOk()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            // Action
            var callback = _apiControllerBase.HandleQuery(query);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ApiControllerBaseDummy>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        #endregion HandleQuery

        #region HandleQueryable

        [Test]
        public void Base_Controller_HandleQueryable_ShouldBeOk()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            // Action
            var callback = _apiControllerBase.HandleQueryable<ApiControllerBaseDummy>(query);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ApiControllerBaseDummy>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        #endregion HandleQueryable

        #region HandleValidationFailure

        [Test]
        public void Base_Controller_HandleValidationFailure_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var validationFailure = new ValidationFailure("", ((int)CodigoErros.Unhandled).ToString());
            IList<ValidationFailure> errors = new List<ValidationFailure>() { validationFailure };
            // Action
            var callback = _apiControllerBase.HandleValidationFailure(errors);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.FirstOrDefault().Should().Be(validationFailure);
        }

        #endregion HandleValidationFailure
    }
}