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
        Product Update(Product product);
        Product Get(long id);
        IEnumerable<Product> GetAll();
        void Delete(Product product);
        bool CheckDependency(Product product);
    }
}
