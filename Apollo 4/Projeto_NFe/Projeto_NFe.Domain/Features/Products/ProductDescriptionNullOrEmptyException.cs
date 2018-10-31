using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public class ProductDescriptionNullOrEmptyException : BusinessException
    {
        public ProductDescriptionNullOrEmptyException() : base("O produto não pode ter a descrição nula!")
        {
        }
    }
}
