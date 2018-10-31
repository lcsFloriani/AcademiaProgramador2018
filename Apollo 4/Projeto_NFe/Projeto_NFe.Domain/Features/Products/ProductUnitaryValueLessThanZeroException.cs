using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public class ProductUnitaryValueLessThanZeroException : BusinessException
    {
        public ProductUnitaryValueLessThanZeroException() : base("O valor unitário não pode ser menor que zero!")
        {
        }
    }
}
