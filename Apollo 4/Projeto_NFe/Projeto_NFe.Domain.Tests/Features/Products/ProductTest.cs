using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Products
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void Products_Domain_Validate_ShouldValidateWithSuccess()
        {
            //Cenário
            Product product = ObjectMother.GetProduct();

            //Ação
            Action action = product.Validate;

            //Saída
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Products_Domain_Validate_ShouldThrowDescriptionNullOrEmptyException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithDescriptionNullOrEmpty();

            //Ação
            Action action = product.Validate;

            //Saída
            action.Should().Throw<ProductDescriptionNullOrEmptyException>();
        }

        [Test]
        public void Products_Domain_Validate_ShouldThrowCodeNullOrEmptyException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithCodeNullOrEmpty();

            //Ação
            Action action = product.Validate;

            //Saída
            action.Should().Throw<ProductCodeNullOrEmptyException>();
        }

        [Test]
        public void Products_Domain_Validate_ShouldThrowCodeNotNumericalException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithCodeNotNumerical();

            //Ação
            Action action = product.Validate;

            //Saída
            action.Should().Throw<ProductCodeNotNumericalException>();
        }


        [Test]
        public void Products_Domain_Validate_ShouldThrowDescriptionWithLessThanThreeCharactersException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithDescriptionWithLessThanThreeCharacters();

            //Ação
            Action action = product.Validate;

            //Saída
            action.Should().Throw<ProductDescriptionWithLessThanThreeCharactersException>();
        }

        [Test]
        public void Products_Domain_Validate_ShouldThrowUnitaryValueLessThanZeroException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithUnitaryValueWithLessThanNumberZero();

            //Ação
            Action action = product.Validate;

            //Saída
            action.Should().Throw<ProductUnitaryValueLessThanZeroException>();
        }

        [Test]
        public void Products_Domain_Aliquot_ShouldAliquotWithSuccess()
        {
            //Cenário
            double icms = 0.04;
            double ipi = 0.1;

            //Ação
            Product p = new Product();

            //Saída
            p.AliquotICMS.Should().Be(icms);
            p.AliquotIPI.Should().Be(ipi);
        }
    }
}
