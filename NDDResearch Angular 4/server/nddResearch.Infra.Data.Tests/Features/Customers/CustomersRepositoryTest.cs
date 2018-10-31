using Effort;
using FluentAssertions;
using nddResearch.Infra.Data.Tests.Context;
using nddResearch.Infra.Data.Tests.Initializer;
using NDDResearch.Domain.Features.Addresses;
using NDDResearch.Domain.Features.Customers;
using NDDResearch.Domain.Features.Sites;
using NDDResearch.Infra.Data.Features.Customers;
using NDDResearch.Infra.Structs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nddResearch.Infra.Data.Tests.Features.Customers
{
    public class CustomersRepositoryTest : TestBase
    {
        private FakeDbContext _ctx;
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _customer = CreateNewCustomer();
            _ctx.Customers.Add(_customer);
            _ctx.SaveChanges();
        }

        #region ADD

        [Test]
        public void Customers_Repository_Add_ShouldBeOk()
        {
            //Arrange
            var repository = new CustomerRepository(_ctx);
            var newCustomer = CreateNewCustomer();
            newCustomer.SetKey();
            newCustomer.SetCreationDate();
            //Action
            var customerAddCB = repository.Add(newCustomer);

            //Assert
            customerAddCB.Result.Should().NotBeNull();
            customerAddCB.Result.Id.Should().NotBe(0);
            var expectedCustomer = _ctx.Customers.Find(customerAddCB.Result.Id);
            expectedCustomer.Should().NotBeNull();
        }

        #endregion

        #region GET

        [Test]
        public void Customers_Repository_GetAll_ShouldBeOk()
        {
            //Arrange
            var repository = new CustomerRepository(_ctx);

            //Action
            var customers = repository.GetAll().ToList();

            //Assert
            customers.Should().NotBeNull();
            customers.Should().HaveCount(_ctx.Customers.Count());
        }

        [Test]
        public void Customers_Repository_GetById_ShouldBeOk()
        {
            //Arrange
            var repository = new CustomerRepository(_ctx);

            //Action
            var customerCB = repository.GetById(_customer.Id);

            //Assert
            customerCB.Result.Should().NotBeNull();
            customerCB.Result.Id.Should().Equals(_customer.Id);
        }

        #endregion

        #region DELETE

        [Test]
        public void Customers_Repository_Delete_ShouldBeOk()
        {
            var repository = new CustomerRepository(_ctx);

            var callbackRemove = repository.Remove(_customer);

            callbackRemove.Result.Should().Be(Result.Successful);
        }

        #endregion

        #region UPDATE

        [Test]
        public void Customers_Repository_Update_ShouldBeOk()
        {
            var repository = new CustomerRepository(_ctx);
            var callbackRemove = repository.Update(_customer);

            callbackRemove.Result.Should().Be(Result.Successful);
        }

        #endregion

        private Customer CreateNewCustomer()
        {
            var customer = new Customer()
            {
                Name = "Empresa02",
                DisplayName = "Empresa 2",
                NationalIdNumber = "123456789",
                Phone = "49999433351",
                WebSite = "http://nddresearch/",
                Address = new Address()
                {
                    City = "Lages",
                    Country = "Brasil",
                    State = "Santa Catarina",
                    PostalCode = "88509290",
                    Street = "Rua São Paulo, 639,  São Cristovão"
                },
                Sites = new List<Site>()
            };
            customer.SetKey();
            customer.SetCreationDate();
            return customer;
        }
    }
}
