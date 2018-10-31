using FluentAssertions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Application.Features.Products.Queries;
using Projeto_NFe.Application.Mapping;
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

        private Product _product;
        private ProductCommandDelete _DeleteProductCommand;
        private Mock<ProductCommandRegister> _mockRegisterProductCommand;
        private Mock<ProductCommandUpdate> _mockUpdateProductCommand;
        private Mock<ValidationResult> _validator;
        private bool _isValid = true;
        private int limit = 1;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepository.Object);
            _mockRegisterProductCommand = new Mock<ProductCommandRegister>();
            _mockUpdateProductCommand = new Mock<ProductCommandUpdate>();
            _DeleteProductCommand = new ProductCommandDelete();
            _validator = new Mock<ValidationResult>();
            _validator.Setup(v => v.IsValid).Returns(true);
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }

        [Test]
        public void Products_Service_Add_ShouldAddWithSuccess()
        {
            //Cenário
            long expectedId = 1;

            Product recurrence = ObjectMother.GetProduct();
            recurrence.Id = expectedId;

            Product product = ObjectMother.GetProduct();

            _mockRepository.Setup(x => x.Save(It.IsAny<Product>())).Returns(recurrence);

            //Ação
           long ProductId = _service.Add(_mockRegisterProductCommand.Object);

            //Saída
            ProductId.Should().Be(expectedId);
            _mockRepository.Verify(m => m.Save(It.IsAny<Product>()));
           
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

            bool isUpdated = true;

            _mockRepository.Setup(x => x.Update(It.IsAny<Product>())).Returns(isUpdated);
            _mockUpdateProductCommand.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _mockRepository.Setup(m => m.Get(It.IsAny<long>())).Returns(_product);
            //Ação
            bool result = _service.Update(_mockUpdateProductCommand.Object);

            //Saída
            result.Should().BeTrue();
            _mockRepository.Verify(m => m.Update(It.IsAny<Product>()));
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
        public void Products_Service_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenário
            Product firstProduct = ObjectMother.GetProduct();
            firstProduct.Id = 1;

            var list = new List<Product>() { firstProduct }.AsQueryable();

            _mockRepository.Setup(x => x.GetAll()).Returns(list);

            // Executa
            IEnumerable<Product> product = _service.GetAll();

            // Saída
            _mockRepository.Verify(m => m.GetAll());
        }

        [Test]
        public void Products_Service_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long id = 1;
            var ProductIds = new long[] { id };
           
            _mockRepository.Setup(x => x.Delete(It.IsAny<long>())).Returns(true);
            _DeleteProductCommand.Ids = ProductIds;
            //Ação
            _service.Delete(_DeleteProductCommand);

            //Saída
            _mockRepository.Verify(m => m.Delete(It.IsAny<long>()));
        }
    }
}
