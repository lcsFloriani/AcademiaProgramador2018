using Projeto_NFe.Infra.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public class Product : IEntity
    {
        private string _regexNumber = @"^\d+$";

        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitaryValue { get; set; }
        public double AliquotICMS { get => 0.04; }
        public double AliquotIPI { get => 0.10; }


        public virtual void Validate()
        {
            if (Code == null)
                throw new ProductCodeNullOrEmptyException();
            if (!Regex.IsMatch(Code, _regexNumber))
                throw new ProductCodeNotNumericalException();
            if (Description == null)
                throw new ProductDescriptionNullOrEmptyException();
            if (Description.Count() < 4)
                throw new ProductDescriptionWithLessThanThreeCharactersException();
            if (UnitaryValue <= 0)
                throw new ProductUnitaryValueLessThanZeroException();
        }
    }
}
