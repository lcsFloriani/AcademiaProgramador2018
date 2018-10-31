using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Features.Taxes;
using Projeto_NFe.Infra.AccessKeys;
using Projeto_NFe.Infra.Extension_Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceIssued 
    {
        public DateTime IssuanceDate { get; set; }
        public long Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string NatureOperation { get; set; }
        public double ValueFreight { get; set; }

        public long? ConveyorId { get; set; }
        public virtual Conveyor Conveyor { get; set; }
        public long EmitterId { get; set; }
        public virtual Emitter Emitter { get; set; }
        public long ReceiverId { get; set; }
        public virtual Receiver Receiver { get; set; }
        public List<ItemInvoice> Items { get; set; }

        public InvoiceIssued()
        {
            //GenereteAccessKey();
        }

        public InvoiceIssued(InvoiceInProcess invoceToEmit)
        {
            EntryDate = invoceToEmit.EntryDate;
            NatureOperation = invoceToEmit.NatureOperation;
            Conveyor = invoceToEmit.Conveyor;
            Emitter = invoceToEmit.Emitter;
            Receiver = invoceToEmit.Receiver;
            Items = invoceToEmit.Items;

            if (invoceToEmit.ConveyorId == null)
            {
                Conveyor = new Conveyor
                {
                    NameCompanyName = invoceToEmit.Receiver.NameCompanyName,
                    FreightResponsibility = FreightResponsibility.RECEIVER,
                    CpfCnpj = invoceToEmit.Receiver.CpfCnpj,
                    Address = invoceToEmit.Receiver.Address
                };
            }

            //GenereteAccessKey();

            //Tax = new Tax();
            //Tax.ValueFreight = invoceToEmit.ValueFreight;
            //Tax.invoice = this;
        }

        //public void GenereteAccessKey()
        //{
        //    Key = new AccessKey();
        //    Key.CreateNumberKey();
        //}

    }
}
