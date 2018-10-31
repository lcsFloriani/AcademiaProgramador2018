using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public class ProductCodeNotNumericalException : BusinessException
    {
        public ProductCodeNotNumericalException() : base("O código do produto deve ser obrigatoriamente numerico!")
        {

        }
    }
}
