using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices
{
    public interface IInvoiceInProcessService
    {
        InvoiceInProcess Add(InvoiceInProcess invoiceInProcess);
        InvoiceInProcess Update(InvoiceInProcess invoiceInProcess);
        InvoiceInProcess Get(long id);
        IEnumerable<InvoiceInProcess> GetAll();
        void Delete(InvoiceInProcess invoiceInProcess);


    }
}
