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
		bool Delete(ItemInvoice itemInvoice);
    }
}
