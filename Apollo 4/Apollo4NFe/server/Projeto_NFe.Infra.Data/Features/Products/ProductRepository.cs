using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Products
{
    public class ProductRepository : IProductRepository
    {
        private ProjetoNFeContext _context;

        public ProductRepository(ProjetoNFeContext context)
        {
            this._context = context;
        }

        public bool CheckDependency(long productId)
        {
            int count = _context.ItemInvoices.Where(i => i.Product.Id == productId).Count();

            return count > 0;
        }

        public bool Delete(long productId)
        {
            var product = this.Get(productId);

            _context.Products.Remove(product);

            return _context.SaveChanges() > 0;
        }

        public Product Get(long id)
        {
            return _context.Products.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<Product> GetAll(int size)
        {
            return this._context.Products.Take(size);
        }

        public IQueryable<Product> GetAll()
        {
            return this._context.Products;
        }

        public Product Save(Product product)
        {
            Product newProduct = _context.Products.Add(product);
            _context.SaveChanges();
            return newProduct;
        }

        public bool Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
