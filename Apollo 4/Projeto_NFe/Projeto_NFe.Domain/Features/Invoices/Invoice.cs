using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public abstract class Invoice : IEntity
    {
        public long Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string NatureOperation { get; set; }
        public Conveyor Conveyor { get; set; }
        public Emitter Emitter { get; set; }
        public Receiver Receiver { get; set; }
        public List<ItemInvoice> Items { get; set; }

        public abstract void Validate();
    }
}