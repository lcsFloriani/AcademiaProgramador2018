using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Queries
{
    public class InvoiceIInProcessQuery
    {
        public virtual int Size { get; set; }

        public InvoiceIInProcessQuery(int _size)
        {
            Size = _size;
        }
    }
}
