using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Application.Features.Products.Commands;
using AutoMapper;
using Projeto_NFe.Application.Features.Products.Queries;

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

        public long Add(ProductCommandRegister productcmd)
        {
            var product = Mapper.Map<ProductCommandRegister, Product>(productcmd);

            Product newproduct = _repository.Save(product);

            return newproduct.Id;
        }

        public bool Delete(ProductCommandDelete productcmd)
        {
            bool isRemoved;
            bool isRemovedAll = true;
            foreach (var id in productcmd.Ids)
            {
                if (!_repository.CheckDependency(id))
                {
                    isRemoved = _repository.Delete(id);
                    isRemovedAll = isRemoved ? isRemovedAll : false;
                }

            }
            return isRemovedAll;
        }

        public Product Get(long id)
        {
            if (id < lessThan)
                throw new IdentifierUndefinedException();

            return _repository.Get(id);
        }

        public IQueryable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Product> GetAll(ProductQuery query)
        {
            return _repository.GetAll(query.Size);
        }

        public bool Update(ProductCommandUpdate productcmd)
        {
            var product = Mapper.Map<ProductCommandUpdate, Product>(productcmd);

            bool ProductResult;
            ProductResult = _repository.Update(product);
            return ProductResult;
        }
    }
}
