using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public class Product
    {
       
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitaryValue { get; set; }
        public double AliquotICMS { get => 0.04; }
        public double AliquotIPI { get => 0.10; }

	}
}
