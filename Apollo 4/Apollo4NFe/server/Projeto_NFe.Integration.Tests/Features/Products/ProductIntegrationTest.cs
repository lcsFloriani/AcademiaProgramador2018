using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Application.Features.Products.Queries;
using Projeto_NFe.Application.Features.Products.ViewModels;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.Data.Features.Products;
using Projeto_NFe.Infra.ORM.Context;
using Projeto_NFe.WebApi.Controllers.Features.Products;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Projeto_NFe.Integration.Tests.Features.Products
{
    [TestFixture]
    public class ProductIntegrationTest
    {
        private IProductRepository _repository;
        private IProductService _service;
        private ProductsController _controller;
        private static ProjetoNFeContextTest _context;

        private ProductCommandDelete _productDelete;
        private ProductCommandRegister _productRegister;
        private ProductCommandUpdate _productUpdate;
        private ProductViewModel _productViewModel;
        private ProductQuery _productQuery;
        private Product _product;


        [SetUp]
        public void Initialize()
        {
            Database.SetInitializer(new DbInitializer());
            _context = new ProjetoNFeContextTest();

            _repository = new ProductRepository(_context);
            _service = new ProductService(_repository);
            _controller = new ProductsController(_service);

            _productDelete = new ProductCommandDelete();
            _productRegister = new ProductCommandRegister();
            _productUpdate = new ProductCommandUpdate();
            _productViewModel = new ProductViewModel();

            _product = ObjectMother.GetProduct();
            _product.Id = 1;


            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }

        [Test]
        [Order(1)]
        public void Products_Integration_Add_ShouldAddWithSuccess()
        {
            //Cenário
            int expectedId = 1;
            Product recurrence = ObjectMother.GetProduct();
            recurrence.Id = expectedId;

            _productRegister.Code = recurrence.Code;
            _productRegister.Description = recurrence.Description;
            _productRegister.UnitaryValue = recurrence.UnitaryValue;

            //Ação
            var result = _controller.Post(_productRegister);
            _product = _service.Get(expectedId);
            //Saída
            result.Should().NotBeNull();
            _product.Should().NotBeNull();
            _product.Id.Should().Be(expectedId);
        }

        [Test]
        [Order(2)]
        public void Products_Integration_Update_ShouldUpdateWithSuccess()
        {
            //Cenario

            long expectedId = 1;
            string expectedDescription = "Teste S2";
            double expectedUnitaryValue = 35.90;

            string oldDescription = _product.Description;
            double oldUnitaryValue = _product.UnitaryValue;
            _product.Description = expectedDescription;
            _product.UnitaryValue = expectedUnitaryValue;
            //Ação
            _productUpdate.UnitaryValue = _product.UnitaryValue;
            _productUpdate.Code = _product.Code;
            _productUpdate.Id = _product.Id;
            _productUpdate.Description = _product.Description;
            _controller.Update(_productUpdate);

            //Saída
            var result = _service.Get(_product.Id);
            result.Should().NotBeNull();
            result.Description.Should().NotBe(oldDescription);
            result.UnitaryValue.Should().NotBe(oldUnitaryValue);
        }

        [Test]
        [Order(3)]
        public void Products_Integration_Get_ShouldGetWithSuccess()
        {
            //Cenário
            int searchId = 1;

            Product recurrence = ObjectMother.GetProduct();
            recurrence.Id = searchId;

            //Ação
            var result = _controller.GetById(searchId);

            //Saída
            result.Should().NotBeNull();
        }



        [Test]
        [Order(4)]
        public void Products_Integration_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenário

            int size = 1;
            long firstProductId = 1;
            int biggerThan = 0;

            var odata = OdataQueryOptions.GetOdataQueryOptions<Product>(_controller);

            // Executa
            var product = _controller.Get(odata);

            // Saída
            product.Should().NotBeNull();
        }

        [Test]
        [Order (5)]
        public void Products_Integration_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long id = 1;
            var ProductIds = new long[] { id };
            _productDelete.Ids = ProductIds;

            //Ação
            _controller.Delete(_productDelete);

            //Saída
            Product result = _repository.Get(id);
            result.Should().BeNull();
            _context.Database.Delete();
        }
    }
}
