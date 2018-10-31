using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products
{
    public interface IProductService
    {
        Product Add(Product product);
        Product Update(Product product);
        Product Get(long id);
        IEnumerable<Product> GetAll();
        void Delete(Product product);
    }
}
