using Microsoft.AspNet.OData.Query;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Application.Features.Products.Queries;
using Projeto_NFe.Application.Features.Products.ViewModels;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.WebApi.Controllers.Common;
using Projeto_NFe.WebApi.Filters;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_NFe.WebApi.Controllers.Features.Products
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) : base()
        {
            _productService = productService;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Product> queryOptions)
        {
            var queryString = Request.GetQueryNameValuePairs()
                                   .Where(x => x.Key.Equals("size"))
                                   .FirstOrDefault();

            var query = default(IQueryable<Product>);
            int size = 0;
            if (queryString.Key != null && int.TryParse(queryString.Value, out size))
            {
                query = _productService.GetAll(new ProductQuery(size));
            }
            else
                query = _productService.GetAll();

            return HandleQueryable<Product, ProductViewModel>(query, queryOptions);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleQuery<Product, ProductViewModel>(_productService.Get(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(ProductCommandRegister productCmd)
        {
            var validator = productCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_productService.Add(productCmd));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(ProductCommandUpdate command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_productService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(ProductCommandDelete command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_productService.Delete(command));
        }

        #endregion HttpDelete
    }
}