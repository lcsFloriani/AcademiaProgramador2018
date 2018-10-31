using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public interface IProductRepository
    {
        Product Save(Product product);
        bool Update(Product product);
        Product Get(long id);
        IQueryable<Product> GetAll();
		IQueryable<Product> GetAll(int size);
		bool Delete(long id);
        bool CheckDependency(long id);
    }
}
