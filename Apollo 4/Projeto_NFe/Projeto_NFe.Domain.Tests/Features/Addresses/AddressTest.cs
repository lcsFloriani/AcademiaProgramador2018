using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Addresses
{
    [TestFixture]
    public class AddressTest
    {
        [Test]
        public void Addresses_Domain_Validate_ShouldValidateWithSuccess()
        {
            //Cenário
            Address a = ObjectMother.GetAddress();

            //Executa
            Action executeAction = a.Validate;

            //Saída
            executeAction.Should().NotThrow<Exception>();
        }

        [Test]
        public void Addresses_Domain_Validate_ShouldThrowStreetNullOrEmptyException()
        {
            //Cenário
            Address a = ObjectMother.GetAddressInvalidStreet();

            //Executa
            Action executeAction = a.Validate;

            //Saída
            executeAction.Should().Throw<AddressStreetNullOrEmptyException>();
        }

        [Test]
        public void Addresses_Domain_Validate_ShouldThrowNeighbourhoodNullOrEmptyException()
        {
            //Cenário
            Address a = ObjectMother.GetAddressInvalidNeighbourhood();

            //Executa
            Action executeAction = a.Validate;

            //Saída
            executeAction.Should().Throw<AddressNeighbourhoodNullOrEmptyException>();
        }

        [Test]
        public void Addresses_Domain_Validate_ShouldThrowCityNullOrEmptyException()
        {
            //Cenário
            Address a = ObjectMother.GetAddressInvalidCity();

            //Executa
            Action executeAction = a.Validate;

            //Saída
            executeAction.Should().Throw<AddressCityNullOrEmptyException>();
        }

        [Test]
        public void Addresses_Domain_Validate_ShouldThrowNumberLessThanOneException()
        {
            //Cenário
            Address a = ObjectMother.GetAddressInvalidNumber();

            //Executa
            Action executeAction = a.Validate;

            //Saída
            executeAction.Should().Throw<AddressNumberLessThanOneException>();
        }

        [Test]
        public void Addresses_Domain_Validate_ShouldThrowDefaultStateEnumException()
        {
            //Cenário
            Address a = ObjectMother.GetAddressInvalidState();

            //Executa
            Action executeAction = a.Validate;

            //Saída
            executeAction.Should().Throw<AddressDefaultStateEnumException>();
        }

        [Test]
        public void Addresses_Domain_Get_Country_ShouldGetCountryWithSuccess()
        {
            //Cenário
            Address a = ObjectMother.GetAddress();

            //Saída
            a.Country.Should().Be(Country.Brasil);
        }
    }
}
