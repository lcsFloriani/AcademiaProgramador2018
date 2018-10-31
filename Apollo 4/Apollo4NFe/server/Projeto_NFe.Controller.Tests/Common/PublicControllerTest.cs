using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.WebApi.Controllers.Common;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controller.Tests.Common
{
    [TestFixture]
    public class PublicControllerTests
    {
        private PublicController _publicController;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _publicController = new PublicController()
            {
                Request = request
            };
        }

        #region GET

        [Test]
        public void Public_Controller_Get_ShouldOk()
        {
            var callback = _publicController.IsAlive();
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
        }

        #endregion
    }
}