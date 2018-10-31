using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Application.Features.Products.Queries;
using Projeto_NFe.Application.Features.Products.ViewModels;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Controller.Tests.Common;
using Projeto_NFe.Controller.Tests.Inicializador;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.WebApi.Controllers.Features.Products;
using Projeto_NFe.WebApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controller.Tests.Features.Products
{
    [TestFixture]
    public class ProductControllerTest : ApiControllerBaseTests
    {
        private ProductsController _productController;
        private Mock<IProductService> _productService;
        private Mock<Product> _product;

        private Mock<ProductCommandRegister> _productRegisterCmd;
        private Mock<ProductCommandUpdate> _productUpdateCmd;
        private Mock<ProductCommandDelete> _productDeleteCmd;
        private ProductQuery _productQuery;
        private Mock<ValidationResult> _validator;
        private bool _isValid = true;
        private int limit = 1;

        [SetUp]
        public void SetUp()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _productService = new Mock<IProductService>();
            _productController = new ProductsController(_productService.Object)
            {
                Request = request
            };
            _product = new Mock<Product>();

            _productRegisterCmd = new Mock<ProductCommandRegister>();
            _productUpdateCmd = new Mock<ProductCommandUpdate>();
            _productDeleteCmd = new Mock<ProductCommandDelete>();
            _productQuery = new ProductQuery(limit);
            _validator = new Mock<ValidationResult>();
            _isValid = true;
            _validator.Setup(v => v.IsValid).Returns(_isValid);

            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }
        #region Get
        [Test]
        public void Product_Controller_GetById_ShouldWithSucess()
        {
            var id = 1;
            _productService.Setup(c => c.Get(id)).Returns(_product.Object);

            IHttpActionResult callback = _productController.GetById(id);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ProductViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _productService.Verify(s => s.Get(id), Times.Once);
        }
        [Test]
        public void Product_Controller_GetAll_ShouldWithSucess()
        {
            Product cliente = ObjectMother.GetProduct();
            var response = new List<Product>() { cliente }.AsQueryable();

            _productService.Setup(s => s.GetAll()).Returns(response);
            var odataOptions = GetOdataQueryOptions<Product>(_productController);

            var result = _productController.Get(odataOptions);
            _productService.Verify(x => x.GetAll());
            var httpResponse = result.Should().BeOfType<OkNegotiatedContentResult<PageResult<ProductViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(cliente.Id);
        }
        #endregion
        #region Post
        [Test]
        public void Product_Controller_Add_ShouldWithSucess()
        {
            var product = ObjectMother.GetProduct();
            product.Id = 1;
            var id = 1;
            _productRegisterCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _productService.Setup(c => c.Add(_productRegisterCmd.Object)).Returns(product.Id);

            IHttpActionResult callback = _productController.Post(_productRegisterCmd.Object);

            _productService.Verify(s => s.Add(_productRegisterCmd.Object), Times.Once);

        }
        #endregion
        #region PUT

        [Test]
        public void Product_Controller_Update_ShouldWithSucess()
        {
            var product = ObjectMother.GetProduct();
            product.Id = 1;

            var isUpdated = true;
            _productUpdateCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _productService.Setup(c => c.Update(_productUpdateCmd.Object)).Returns(isUpdated);

            IHttpActionResult callback = _productController.Update(_productUpdateCmd.Object);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _productService.Verify(s => s.Update(_productUpdateCmd.Object), Times.Once);
        }
        #endregion
        #region Delete
        [Test]
        public void Product_Controller_Delete_ShouldWithSucess()
        {
            var isDeleted = true;
            _productDeleteCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _productService.Setup(c => c.Delete(_productDeleteCmd.Object)).Returns(isDeleted);

            IHttpActionResult callback = _productController.Delete(_productDeleteCmd.Object);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _productService.Verify(s => s.Delete(_productDeleteCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();

        }
        #endregion
    }
}
