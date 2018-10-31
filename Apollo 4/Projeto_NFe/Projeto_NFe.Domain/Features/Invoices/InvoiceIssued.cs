using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Conveyors;
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
    public class InvoiceIssued : Invoice
    {
        public Tax Tax { get; set; }
        public AccessKey Key { get; set; }
        public DateTime IssuanceDate { get; set; }

        public InvoiceIssued() {}

        public InvoiceIssued(InvoiceInProcess invoceToEmit)
        {
            EntryDate = invoceToEmit.EntryDate;
            NatureOperation = invoceToEmit.NatureOperation;
            Conveyor = invoceToEmit.Conveyor;
            Emitter = invoceToEmit.Emitter;
            Receiver = invoceToEmit.Receiver;
            Items = invoceToEmit.Items;

            if (invoceToEmit.Conveyor == null)
            {
                Conveyor = new Conveyor
                {
                    Type = invoceToEmit.Receiver.Type,
                    NameCompanyName = invoceToEmit.Receiver.NameCompanyName,
                    FreightResponsibility = FreightResponsibility.RECEIVER,
                    Cpf = invoceToEmit.Receiver.Cpf,
                    Cnpj = invoceToEmit.Receiver.Cnpj,
                    Address = invoceToEmit.Receiver.Address
                };
            }

            GenereteAccessKey();

            Tax = new Tax();
            Tax.ValueFreight = invoceToEmit.ValueFreight;
            Tax.invoice = this;
        }

        public override void Validate()
        {
            if (EntryDate.CompareDateSmallerThan(IssuanceDate))
                throw new InvoiceIssuedDateSmallerThanEntryDateException();
        }

        public void GenereteAccessKey()
        {
            Key = new AccessKey();
            Key.CreateNumberKey();
        }

    }
}
