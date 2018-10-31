using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Application.Features.Products.Queries;
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
        long Add(ProductCommandRegister productcmd);
        bool Update(ProductCommandUpdate productcmd);
        Product Get(long id);
        IQueryable<Product> GetAll();
        IQueryable<Product> GetAll(ProductQuery size);
        bool Delete(ProductCommandDelete productcmd);
    }
}
