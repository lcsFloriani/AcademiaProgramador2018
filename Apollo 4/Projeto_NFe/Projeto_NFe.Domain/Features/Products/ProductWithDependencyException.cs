using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public class ProductWithDependencyException : BusinessException
    {
        public ProductWithDependencyException() : base("O produto não pode ser excluído, pois esta sendo usado como dependência!")
        {
        }
    }
}
