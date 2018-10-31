using FluentAssertions;
using MF6.API.Controllers.Testes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace MF6.Controller.Tests.Features
{

    [TestFixture]
    public class TestesControllerTests
    {

        private TestesController _customersController;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _customersController = new TestesController()
            {
                Request = request
            };
        }

        [Test]
        public void Test_CustomerController_GetById_ShouldBeOk()
        {
            long id = 543;
            string expectedResult = "O ID enviado foi: " + id;

            IHttpActionResult callback = _customersController.GetById(id);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<string>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Should().Be(expectedResult);
        }

    }
}
