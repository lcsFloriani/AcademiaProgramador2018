using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Application.Features.Outgoing.Querys
{
    public class OutgoQuery
    {
        public int Quantity { get; set; }

        public OutgoQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
