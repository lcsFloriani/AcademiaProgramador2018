using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.Data.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Features.Products
{
    [TestFixture]
    public class ProductSQLIntegrationTest
    {
        private IProductRepository _repository;
        private IProductService _service;
       
        [SetUp]
        public void Initialize()
        {
            _repository = new ProductSQLRepository();
            _service = new ProductService(_repository);
        }

        [Test]
        public void Products_Integration_Add_ShouldAddWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithoutProduct();

            long expectedId = 1;

            Product recurrence = ObjectMother.GetProduct();
            recurrence.Id = expectedId;

            Product product = ObjectMother.GetProduct();

            //Ação
            var result = _service.Add(product);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(expectedId);
        }


        [Test]
        public void Products_Integration_Add_ShouldThrowCodeNullOrEmptyException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithCodeNullOrEmpty();

            //Ação
            Action action = () => _service.Add(product);

            //Saída
            action.Should().Throw<ProductCodeNullOrEmptyException>();
        }

        [Test]
        public void Products_Integration_Add_ShouldThrowCodeNotNumericalException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithCodeNotNumerical();

            //Ação
            Action action = () => _service.Add(product);

            //Saída
            action.Should().Throw<ProductCodeNotNumericalException>();
        }

        [Test]
        public void Products_Integration_Add_ShouldThrowDescriptionWithLessThanThreeCharactersException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithDescriptionWithLessThanThreeCharacters();

            //Ação
            Action action = () => _service.Add(product);

            //Saída
            action.Should().Throw<ProductDescriptionWithLessThanThreeCharactersException>();            
        }

        [Test]
        public void Products_Integration_Add_ShouldThrowDescriptionNullOrEmptyException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithDescriptionNullOrEmpty();

            //Ação
            Action action = () => _service.Add(product);

            //Saída
            action.Should().Throw<ProductDescriptionNullOrEmptyException>();
        }

        [Test]
        public void Products_Integration_Add_ShouldThrowUnitaryValueLessThanZeroException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithUnitaryValueWithLessThanNumberZero();

            //Ação
            Action action = () => _service.Add(product);

            //Saída
            action.Should().Throw<ProductUnitaryValueLessThanZeroException>();
        }

        [Test]
        public void Products_Integration_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithProduct();

            long expectedId = 1;
            string expectedDescription = "Teste S2";
            double expectedUnitaryValue = 35.90;

            Product product  =_service.Get(expectedId);
            string oldDescription = product.Description;
            double oldUnitaryValue = product.UnitaryValue;
            product.Description = expectedDescription;
            product.UnitaryValue = expectedUnitaryValue;
            //Ação
             _service.Update(product);

            //Saída
            var result = _service.Get(expectedId);
            result.Should().NotBeNull();
            result.Description.Should().NotBe(oldDescription);
            result.UnitaryValue.Should().NotBe(oldUnitaryValue);
        }

        [Test]
        public void Products_Integration_Update_ShouldThrowUnitaryValueLessThanZeroException()
        {
            //Cenário
            long expectedId = 1;
            Product product = ObjectMother.GetProductWithUnitaryValueWithLessThanNumberZero();
            product.Id = expectedId;

            //Ação
            Action action = () => _service.Update(product);

            //Saída
            action.Should().Throw<ProductUnitaryValueLessThanZeroException>();
        }

        [Test]
        public void Products_Integration_Update_ShouldThrowCodeNullOrEmptyException()
        {
            //Cenário
            long expectedId = 1;
            Product product = ObjectMother.GetProductWithCodeNullOrEmpty();
            product.Id = expectedId;

            //Ação
            Action action = () => _service.Update(product);

            //Saída
            action.Should().Throw<ProductCodeNullOrEmptyException>();
        }

        [Test]
        public void Products_Integration_Update_ShouldThrowCodeNotNumericalException()
        {
            //Cenário
            long expectedId = 1;
            Product product = ObjectMother.GetProductWithCodeNotNumerical();
            product.Id = expectedId;

            //Ação
            Action action = () => _service.Update(product);

            //Saída
            action.Should().Throw<ProductCodeNotNumericalException>();
        }


        [Test]
        public void Products_Integration_Update_ShouldThrowDescriptionNullOrEmptyException()
        {
            //Cenário
            long expectedId = 1;
            Product product = ObjectMother.GetProductWithDescriptionNullOrEmpty();
            product.Id = expectedId;

            //Ação
            Action action = () => _service.Update(product);

            //Saída
            action.Should().Throw<ProductDescriptionNullOrEmptyException>();
        }

        [Test]
        public void Products_Integration_Update_ShouldThrowDescriptionWithLessThanThreeCharactersException()
        {
            //Cenário
            long expectedId = 1;
            Product product = ObjectMother.GetProductWithDescriptionWithLessThanThreeCharacters();
            product.Id = expectedId;

            //Ação
            Action action = () => _service.Update(product);

            //Saída
            action.Should().Throw<ProductDescriptionWithLessThanThreeCharactersException>();
        }

        [Test]
        public void Products_Integration_Get_ShouldGetWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithProduct();

            long searchId = 1;

            Product recurrence = ObjectMother.GetProduct();
            recurrence.Id = searchId;

            //Ação
            var result = _service.Get(searchId);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
        }

        [Test]
        public void Products_Integration_Get_ShouldBeFail()
        {
            //Cenário
            long searchId = 7;

            Product recurrence = ObjectMother.GetProduct();
            recurrence.Id = searchId;

            //Ação
            var result = _service.Get(searchId);

            //Saída
            result.Should().BeNull();
        }


        [Test]
        public void Products_Integration_Get_ShouldThrowIdentifierUndefinedException()
        {
            // Inválido
            int id = -1;

            // Executa
            Action executeAction = () => _service.Get(id);

            //Saída
            executeAction.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Products_Integration_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenário
            BaseSqlTest.SeedDatabaseWithProduct();

            int size = 1;
            long firstProductId = 1;
            int biggerThan = 0;

            // Executa
            IEnumerable<Product> product = _service.GetAll();

            // Saída
            product.Should().NotBeNull();
            product.Count().Should().BeGreaterThan(biggerThan);
            product.Count().Should().Equals(size);
            product.First().Id.Should().Be(firstProductId);
        }

        [Test]
        public void Products_Integration_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithProduct();

            long id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = id;

            //Ação
            _service.Delete(product);

            //Saída
            Product result = _repository.Get(id);
            result.Should().BeNull();
        }

        [Test]
        public void Products_Integration_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            long id = -1;
            Product product = ObjectMother.GetProduct();
            product.Id = id;

            //Ação
            Action action = () => _service.Delete(product);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
