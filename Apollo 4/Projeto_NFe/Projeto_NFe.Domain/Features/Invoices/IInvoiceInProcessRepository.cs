using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public interface IInvoiceInProcessRepository
    {
        InvoiceInProcess Save(InvoiceInProcess invoiceInProcess);
        InvoiceInProcess Update(InvoiceInProcess invoiceInProcess);
        void Delete(InvoiceInProcess invoiceInProcess);
        InvoiceInProcess Get(long id);
        IEnumerable<InvoiceInProcess> GetAll();
    }
}
