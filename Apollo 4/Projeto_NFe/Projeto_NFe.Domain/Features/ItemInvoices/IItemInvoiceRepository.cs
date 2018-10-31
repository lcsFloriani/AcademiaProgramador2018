using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.ItemInvoices
{
    public interface IItemInvoiceRepository
    {
        ItemInvoice Save(ItemInvoice itemInvoice);
        ItemInvoice Update(ItemInvoice itemInvoice);
        IEnumerable<ItemInvoice> GetByInvoice(InvoiceInProcess invoiceInProcess);
        void Delete(ItemInvoice itemInvoice);
        ItemInvoice Get(long id);
    }
}
