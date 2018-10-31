using FluentAssertions;
using nddResearch.Domain.Tests.ObjectMothers;
using NDDResearch.Domain.Features.Customers;
using NUnit.Framework;
using System;

namespace nddResearch.Domain.Tests.Features.Customers
{
    [TestFixture]
    public class CustomerDomainTest
    {
        [Test]
        public void Customers_Domain_SetCreationDate_ShouldBeOk()
        {
            // Arrange
            var customer = new Customer();
            // Action
            customer.SetCreationDate();
            // Assert
            customer.CreationDate.Date.Should().Be(DateTime.Now.Date);
        }

        [Test]
        public void Customers_Domain_SetKey_ShouldBeOk()
        {
            // Arrange
            var customer = new Customer();
            // Action
            customer.SetKey();
            // Assert
            customer.Key.Should().NotBeNull();
        }

        [Test]
        public void Customers_Domain_SetDefaultSite_ShouldBeOk()
        {
            // Arrange
            var customer = ObjectMother.CustomerObjectMother.Default;
            var site = ObjectMother.SiteObjectMother.Default;
            site.CustomerId = customer.Id;
            site.Customer = customer;
            site.Address = customer.Address;
            customer.Sites.Add(site);
            // Action
            var setDefaultSiteCB = customer.SetDefaultSite(site);
            // Assert
            setDefaultSiteCB.IsFailure.Should().BeFalse();
            site.IsDefault.Should().BeTrue();
        }

    }
}
