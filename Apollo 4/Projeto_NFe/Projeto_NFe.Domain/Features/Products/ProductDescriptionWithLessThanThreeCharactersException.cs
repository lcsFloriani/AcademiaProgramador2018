using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public class ProductDescriptionWithLessThanThreeCharactersException : BusinessException
    {
        public ProductDescriptionWithLessThanThreeCharactersException() : base("A descrição tem que ter mais de 3 caracteres!")
        {
        }
    }
}
