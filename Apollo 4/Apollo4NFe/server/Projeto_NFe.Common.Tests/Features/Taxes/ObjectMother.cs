using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Tax GetTax(InvoiceIssued invoice)
        {
            return new Tax()
            {
                //invoice = invoice,
                ValueFreight = 2
            };
        }

        public static Tax GetTaxWithOutInvoice()
        {
            return new Tax()
            {
                ValueFreight = 2
            };
        }

        public static Tax GetInvalidValueFreightTax(InvoiceIssued invoice)
        {
            return new Tax()
            {
                ValueFreight = -1
            };
        }
    }
}
