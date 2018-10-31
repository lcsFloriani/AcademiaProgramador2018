using Projeto_NFe.Domain.Features.ItemInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Items_Invoice.Commands
{
    public class ItemInvoiceRegisterCommand
    {
        public long InvoiceId { get; set; }
        public long ItemInvoice { get; set; }
        public int Quantity { get; set; }
    }
}
