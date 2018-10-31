using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Exceptions;

namespace Projeto_NFe.Application.Features.Products
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private long lessThan = 1;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Add(Product product)
        {
            product.Validate();

            product = _repository.Save(product);

            return product;
        }

        public void Delete(Product product)
        {
            if (product.Id < lessThan)
                throw new IdentifierUndefinedException();

            if (_repository.CheckDependency(product))
            {
                throw new ProductWithDependencyException();
            }
            else
                _repository.Delete(product);
        }

        public Product Get(long id)
        {
            if (id < lessThan)
                throw new IdentifierUndefinedException();

            return _repository.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product Update(Product product)
        {

            if (product.Id < lessThan)
                throw new IdentifierUndefinedException();

            product.Validate();

            product = _repository.Update(product);

            return product;
        }
    }
}
