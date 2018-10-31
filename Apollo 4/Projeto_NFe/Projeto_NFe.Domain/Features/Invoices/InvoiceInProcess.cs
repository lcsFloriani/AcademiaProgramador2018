using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceInProcess : Invoice
    {
        private int _lessThan = 1;
        private int _valueFreightLessThan = 0;

        public double ValueFreight { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(NatureOperation))
                throw new InvoiceInProcessNatureOperationNullOrEmptyException();

            if (ValueFreight < _valueFreightLessThan)
                throw new InvoiceInProcessValueFreightLessThanZeroException();

            if (Emitter == null)
                throw new InvoiceInProcessEmitterNullException();

            Emitter.Validate();

            if (Receiver == null)
                throw new InvoiceInProcessReceiverNullException();

            Receiver.Validate();

            if (Conveyor != null)
                Conveyor.Validate();

            if (Items == null || Items.Count < _lessThan)
                throw new InvoiceInProcessItemsCountLessThanOneException();

            //Verifica se o Item da Nota tem um valor unitario e a quantiidade maior que 0.
            foreach (ItemInvoice item in Items)
                item.Validate();

            //Verifica se o emitente é diferente que o destinatario.
                if (Receiver.Cnpj != null && Emitter.Cnpj.Value.Equals(Receiver.Cnpj.Value))
                    throw new InvoiceInProcessEmitterEqualReceiverException();
        }
    }
}
