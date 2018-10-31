using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static ItemInvoice GetItemInvoice(Product product, InvoiceInProcess invoice)
        {
            return new ItemInvoice
            {
                Invoice = invoice,
                Product = product,
                Quantity = 2
            };
        }

        public static ItemInvoice GetItemInvoiceWithoutInvoice(Product product)
        {
            return new ItemInvoice
            {
                Product = product,
                Quantity = 2
            };
        }

        public static ItemInvoice GetItemInvoiceInvalidInvoice(Product product)
        {
            return new ItemInvoice
            {
                Product = product,
                Quantity = 2
            };
        }

        public static ItemInvoice GetItemInvoiceInvalidProduct(InvoiceInProcess invoice)
        {
            return new ItemInvoice
            {
                Invoice = invoice,
                Quantity = 2
            };
        }

        public static ItemInvoice GetItemInvoiceInvalidQuantity(Product product, InvoiceInProcess invoice)
        {
            return new ItemInvoice
            {
                Invoice = invoice,
                Product = product,
                Quantity = 0
            };
        }
    }
}
