using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.ViewModels
{
    public class InvoiceInProcessViewModel
    {
        public long Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string NatureOperation { get; set; }
        public double ValueFreight { get; set; }
        public virtual Conveyor Conveyor { get; set; }
        public virtual Emitter Emitter { get; set; }
        public virtual Receiver Receiver { get; set; }
        public virtual List<ItemInvoice> Items { get; set; }
    }
}
