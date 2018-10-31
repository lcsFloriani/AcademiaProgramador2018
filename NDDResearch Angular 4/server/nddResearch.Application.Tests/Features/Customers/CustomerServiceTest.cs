using FluentAssertions;
using Moq;
using nddResearch.Application.Tests.Initializer;
using NDDResearch.Application.Features.Addresses.Commands;
using NDDResearch.Application.Features.Customers;
using NDDResearch.Application.Features.Customers.Commands;
using NDDResearch.Domain.Features.Addresses;
using NDDResearch.Domain.Features.Customers;
using NDDResearch.Domain.Features.Sites;
using NDDResearch.Domain.Features.Sites.Service;
using NDDResearch.Infra.Structs;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace nddResearch.Application.Tests.Features.Customers
{
    [TestFixture]
    public class CustomersServiceTest : TestBase
    {
        private CustomersService _service;
        private Mock<ISiteDomainService> _siteDomainServiceFake;
        private Mock<ICustomerRepository> _customerRepositoryFake;
        private Mock<ISiteRepository> _siteRepositoryFake;
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            _customerRepositoryFake = new Mock<ICustomerRepository>();
            _siteDomainServiceFake = new Mock<ISiteDomainService>();
            _siteRepositoryFake = new Mock<ISiteRepository>();
            _service = new CustomersService(_customerRepositoryFake.Object, _siteDomainServiceFake.Object, _siteRepositoryFake.Object);
            _customer = new Customer()
            {
                Name = "Empresa01",
                DisplayName = "Empresa 1",
                NationalIdNumber = "0000000000",
                Phone = "49999433351",
                WebSite = "http://nddresearch/",
                Address = new Address()
                {
                    City = "Lages",
                    Country = "Brasil",
                    State = "Santa Catarina",
                    PostalCode = "88509290",
                    Street = "Rua Acre, 502,  São Cristovão"
                },
                Sites = new List<Site>()
            };
        }


        #region GET

        [Test]
        public void Customers_Service_GetAll_ShouldBeOk()
        {
            //Arrange
            _customerRepositoryFake.Setup(x => x.GetAll()).Returns(new List<Customer>().AsQueryable());

            //Action
            var customers = _service.GetAll();

            //Assert
            _customerRepositoryFake.Verify(x => x.GetAll(), Times.Once);
        }

        public void Customers_Service_GetById_ShouldBeSuccess()
        {
            //Arrange
            var customerId = 10;
            _customerRepositoryFake.Setup(x => x.GetById(customerId)).Returns(It.IsAny<Customer>());
            //Action
            var customer = _service.GetById(customerId);
            //Assert
            customer.IsSuccess.Should().BeTrue();
            customer.Result.Should().NotBeNull();
            _customerRepositoryFake.Verify(x => x.GetById(customerId), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Customers_Service_Add_ShouldBeOk()
        {
            //Arrange
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
            _customerRepositoryFake.Setup(sr => sr.IsUnique(command.Name, 0)).Returns(true);
            _customerRepositoryFake.Setup(sr => sr.Add(It.IsAny<Customer>())).Returns(_customer);
            //Action
            var newCustomerCB = _service.Add(command);
            //Assert
            _customerRepositoryFake.Verify(sr => sr.Add(It.IsAny<Customer>()), Times.Once);
            _customerRepositoryFake.Verify(sr => sr.IsUnique(command.Name, 0), Times.Once);
            newCustomerCB.IsSuccess.Should().BeTrue();
            newCustomerCB.Result.Should().Equals(_customer.Id);
        }

        #endregion

        #region PUT

        [Test]
        public void Customers_Service_Update_ShouldBeOk()
        {
            //Arrange
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
            _customerRepositoryFake.Setup(sr => sr.GetById(command.Id)).Returns(_customer);
            _customerRepositoryFake.Setup(sr => sr.Update(It.IsAny<Customer>())).Returns(Result.Successful);

            //Action
            var updateCustomerCB = _service.Update(command);

            //Assert
            _customerRepositoryFake.Verify(sr => sr.Update(_customer), Times.Once);
            updateCustomerCB.IsSuccess.Should().BeTrue();
        }

        #endregion

        #region DELETE

        [Test]
        public void Customers_Service_Delete_ShouldBeOk()
        {
            //Arrange
            var customerRemoveCmd = new CustomerRemoveCommand()
            {
                CustomerIds = new int[] { _customer.Id },
            };
            _customerRepositoryFake.Setup(sr => sr.GetById(_customer.Id)).Returns(_customer);
            _customerRepositoryFake.Setup(sr => sr.Remove(_customer)).Returns(Result.Successful);

            //Action
            var removeCustomerCB = _service.Remove(customerRemoveCmd);

            //Assert
            _customerRepositoryFake.Verify(sr => sr.Remove(_customer), Times.Once);
            removeCustomerCB.IsSuccess.Should().BeTrue();
        }

        #endregion
    }
}
