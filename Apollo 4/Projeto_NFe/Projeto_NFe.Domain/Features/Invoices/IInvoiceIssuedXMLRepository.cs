using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public interface IInvoiceIssuedXMLRepository
    {
        void Export(InvoiceIssued invoiceIssued, string path);
    }
}
