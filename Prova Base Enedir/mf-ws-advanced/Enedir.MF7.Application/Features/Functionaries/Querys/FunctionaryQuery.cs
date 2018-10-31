using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Application.Features.Functionaries.Querys
{
    public class FunctionaryQuery
    {
        public int Quantity { get; set; }

        public FunctionaryQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
