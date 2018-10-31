using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public class ProductCodeNullOrEmptyException : BusinessException
    {
        public ProductCodeNullOrEmptyException() : base("O produto não pode ter o código nula")
        {

        }
    }
}
