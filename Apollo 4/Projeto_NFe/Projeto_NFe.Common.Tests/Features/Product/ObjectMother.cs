using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Product GetProduct()
        {
            return new Product
            {
                Code = "0001",
                Description = "Tenis",
                UnitaryValue = 12.32
            };
        }

        public static Product GetProductWithCodeNullOrEmpty()
        {
            return new Product
            {
                Description = "Tenis",
                UnitaryValue = 12.32
            };
        }

        public static Product GetProductWithCodeNotNumerical()
        {
            return new Product
            {
                Code = "123b",
                Description = "Tenis",
                UnitaryValue = 12.32
            };
        }

        public static Product GetProductWithDescriptionNullOrEmpty()
        {
            return new Product
            {
                Code = "0001",
                UnitaryValue = 1
            };
        }

        public static Product GetProductWithDescriptionWithLessThanThreeCharacters()
        {
            return new Product
            {
                Code = "0001",
                Description = "Tes",
                UnitaryValue = 1
            };
        }

        public static Product GetProductWithUnitaryValueWithLessThanNumberZero()
        {
            return new Product
            {
                Code = "0001",
                Description = "Teste Valor Unitario",
                UnitaryValue = -1
            };
        }
    }
}
