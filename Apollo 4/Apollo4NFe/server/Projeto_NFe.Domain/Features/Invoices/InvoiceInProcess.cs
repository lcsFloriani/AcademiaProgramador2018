using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceInProcess
    {
		public long Id { get; set; }
		public DateTime EntryDate { get; set; }
		public string NatureOperation { get; set; }
		public double ValueFreight { get; set; }

		public long ConveyorId { get; set; }
		public virtual Conveyor Conveyor { get; set; }
		public long EmitterId { get; set; }
		public virtual Emitter Emitter { get; set; }
		public long ReceiverId { get; set; }
		public virtual Receiver Receiver { get; set; }
		public virtual List<ItemInvoice> Items { get; set; }

        public void AddItem(ItemInvoice item) {
            if (Items == null)
                Items = new List<ItemInvoice>();
           Items.Add(item);
        }       
    }
}
