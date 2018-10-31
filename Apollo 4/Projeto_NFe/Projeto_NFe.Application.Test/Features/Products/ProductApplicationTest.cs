using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Test.Features.Products
{
    [TestFixture]
    public class ProductApplicationTest
    {
        private Mock<IProductRepository> _mockRepository;
        private IProductService _service;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepository.Object);
        }

        [Test]
        public void Products_Service_Add_ShouldAddWithSuccess()
        {
            //Cenário
            long expectedId = 1;

            Product recurrence = ObjectMother.GetProduct();
            recurrence.Id = expectedId;

            Product product = ObjectMother.GetProduct();

            _mockRepository.Setup(x => x.Save(product)).Returns(recurrence);

            //Ação
            var result = _service.Add(product);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(expectedId);
            _mockRepository.Verify(m => m.Save(product));
        }

        [Test]
        public void Products_Service_Add_ShouldThrowDescriptionWithLessThanThreeCharactersException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithDescriptionWithLessThanThreeCharacters();

            //Ação
            Action action = () => _service.Add(product);

            //Saída
            action.Should().Throw<ProductDescriptionWithLessThanThreeCharactersException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Products_Service_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            long expectedId = 1;
            string expectedDescription = "Teste S2";

            Product product = ObjectMother.GetProduct();
            product.Id = expectedId;
            string oldDescription = product.Description;
            product.Description = expectedDescription;

            Product recurrence = ObjectMother.GetProduct();
            recurrence.Id = expectedId;
            recurrence.Description = expectedDescription;

            _mockRepository.Setup(x => x.Update(product)).Returns(recurrence);

            //Ação
            var result = _service.Update(product);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(expectedId);
            result.Description.Should().NotBe(oldDescription);
            _mockRepository.Verify(m => m.Update(product));
        }

        [Test]
        public void Products_Service_Update_ShouldThrowUnitaryValueLessThanZeroException()
        {
            //Cenário
            long expectedId = 1;
            Product product = ObjectMother.GetProductWithUnitaryValueWithLessThanNumberZero();
            product.Id = expectedId;

            //Ação
            Action action = () => _service.Update(product);

            //Saída
            action.Should().Throw<ProductUnitaryValueLessThanZeroException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Products_Service_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithUnitaryValueWithLessThanNumberZero();


            //Ação
            Action action = () => _service.Update(product);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Products_Service_Get_ShouldGetWithSuccess()
        {
            //Cenário
            long searchId = 1;

            Product recurrence = ObjectMother.GetProduct();
            recurrence.Id = searchId;

            _mockRepository.Setup(x => x.Get(searchId)).Returns(recurrence);

            //Ação
            var result = _service.Get(searchId);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
            result.Description.Should().Be(recurrence.Description);
            result.UnitaryValue.Should().Be(recurrence.UnitaryValue);
            _mockRepository.Verify(m => m.Get(searchId));
        }

        [Test]
        public void Products_Service_Get_ShouldThrowIdentifierUndefinedException()
        {
            // Inválido
            int id = -1;

            // Executa
            Action executeAction = () => _service.Get(id);

            //Saída
            executeAction.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Products_Service_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenário
            Product firstProduct = ObjectMother.GetProduct();
            firstProduct.Id = 1;
            Product secondProduct = ObjectMother.GetProduct();
            secondProduct.Id = 2;
            Product thirdProduct = ObjectMother.GetProduct();
            thirdProduct.Id = 3;


            List<Product> list = new List<Product>();
            list.Add(firstProduct);
            list.Add(secondProduct);
            list.Add(thirdProduct);

            _mockRepository.Setup(x => x.GetAll()).Returns(list);

            int size = 3;

            // Executa
            IEnumerable<Product> product = _service.GetAll();

            // Saída

            product.Count().Should().Equals(size);
            product.First().Should().Be(firstProduct);
            product.Last().Should().Be(thirdProduct);
            _mockRepository.Verify(m => m.GetAll());
        }

        [Test]
        public void Products_Service_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = id;

            _mockRepository.Setup(x => x.Delete(product));

            //Ação
            _service.Delete(product);

            //Saída
            _mockRepository.Verify(m => m.Delete(product));
        }

        [Test]
        public void Products_Service_Delete_ShouldThrowProductWithDependencyException()
        {
            //Cenário
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            bool exist = true;

            _mockRepository.Setup(x => x.CheckDependency(product)).Returns(exist);

            //Ação
            Action action = () => _service.Delete(product);

            //Saída
            action.Should().Throw<ProductWithDependencyException>();
            _mockRepository.Verify(m => m.CheckDependency(product));
        }

        [Test]
        public void Products_Service_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            long id = -1;
            Product product = ObjectMother.GetProduct();
            product.Id = id;

            //Ação
            Action action = () => _service.Delete(product);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
