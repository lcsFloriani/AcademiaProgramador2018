using FluentAssertions;
using Moq;
using NDDResearch.API.Controllers.Customers;
using NDDResearch.Application.Features.Customers;
using NDDResearch.Application.Features.Customers.Queries;
using NDDResearch.Domain.Features.Customers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.OData;
using nddResearch.Controller.Tests.Initializer;
using System.Web.Http;
using System.Web.Http.Results;
using NDDResearch.Application.Features.Customers.Commands;
using NDDResearch.Infra.Structs;
using NDDResearch.Application.Features.Sites;
using NDDResearch.Application.Features.Addresses.Commands;

namespace nddResearch.Controller.Tests.Features.Customers
{
    [TestFixture]
    public class CustomerControllerTest : BaseTest
    {
        private Mock<ICustomersService> _customerServiceMock;
        private Mock<ISitesService> _sitesServiceMock;

        public CustomerControllerTest() : base()
        {
            _customerServiceMock = new Mock<ICustomersService>();
            _sitesServiceMock = new Mock<ISitesService>();
        }

        #region GET

        [Test]
        public void Customers_Controller_Get_ShouldOk()
        {
            // Arrange
            var controller = GetCustomersController();
            var response = new List<Customer>().AsQueryable();
            var queryOptions = GetOdataQueryOptions<Customer>(controller);
            _customerServiceMock.Setup(s => s.GetAll()).Returns(response);

            // Action
            var callback = controller.Get(queryOptions);

            //Assert
            var pageResult = callback.Should().BeOfType<PageResult<CustomerQuery>>().Subject;
            pageResult.Items.Should().BeEmpty();
            _customerServiceMock.Verify(s => s.GetAll(), Times.Once);
        }

        [Test]
        public void Customers_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var controller = GetCustomersController();
            var id = 0;
            _customerServiceMock.Setup(c => c.GetById(id)).Returns(It.IsAny<CustomerDetailQuery>());
            // Action
            IHttpActionResult callback = controller.GetById(id);
            // Assert
            callback.Should().BeOfType<OkNegotiatedContentResult<CustomerDetailQuery>>();
            _customerServiceMock.Verify(s => s.GetById(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Customers_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var controller = GetCustomersController();
            var addressCommand = new AddressRegisterCommand()
            {
                City = "Lages",
                Country = "Brasil",
                State = "Santa Catarina",
                PostalCode = "88509290",
                Street = "Rua Acre, 502,  São Cristovão"
            };
            var command = new CustomerRegisterCommand()
            {
                Name = "Empresa01",
                DisplayName = "Empresa 1",
                NationalIdNumber = "0000000000",
                Phone = "49999433351",
                WebSite = "http://nddresearch/",
                Address = addressCommand,
            };
            _customerServiceMock.Setup(c => c.Add(command)).Returns(It.IsAny<int>());
            // Action
            IHttpActionResult callback = controller.Post(command);
            // Assert
            callback.Should().BeOfType<OkNegotiatedContentResult<int>>();
            _customerServiceMock.Verify(s => s.Add(command), Times.Once);
        }

        #endregion

        #region PUT

        [Test]
        public void Customers_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var controller = GetCustomersController();
            var id = 10;
            var addressCommand = new AddressUpdateCommand()
            {
                City = "Lages",
                Country = "Brasil",
                State = "Santa Catarina",
                PostalCode = "88509290",
                Street = "Rua Acre, 502,  São Cristovão"
            };
            var command = new CustomerUpdateCommand()
            {
                DisplayName = "Empresa 1",
                NationalIdNumber = "0000000000",
                Phone = "49999433351",
                WebSite = "http://nddresearch/",
                Address = addressCommand,
            };
            _customerServiceMock.Setup(c => c.GetById(id)).Returns(It.IsAny<CustomerDetailQuery>());
            _customerServiceMock.Setup(c => c.Update(command)).Returns(Result.Successful);
            // Action
            IHttpActionResult callback = controller.Update(command);
            // Assert
            callback.Should().BeOfType<OkNegotiatedContentResult<Result>>();
            _customerServiceMock.Verify(s => s.Update(command), Times.Once);
        }

        #endregion

        #region DELETE

        [Test]
        public void Customers_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var controller = GetCustomersController();
            var id = 10;
            var command = new CustomerRemoveCommand()
            {
                CustomerIds = new int[] { id },
            };
            _customerServiceMock.Setup(c => c.GetById(id)).Returns(It.IsAny<CustomerDetailQuery>());
            _customerServiceMock.Setup(c => c.Remove(command)).Returns(Result.Successful);
            // Action
            IHttpActionResult callback = controller.Remove(command);
            // Assert
            callback.Should().BeOfType<OkNegotiatedContentResult<Result>>();
            _customerServiceMock.Verify(s => s.Remove(command), Times.Once);
        }

        #endregion

        private CustomersController GetCustomersController()
        {
            return new CustomersController(_customerServiceMock.Object, _sitesServiceMock.Object);
        }
    }
}
