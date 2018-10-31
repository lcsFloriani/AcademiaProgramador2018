using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Products;
using System.Xml.Serialization;

namespace Projeto_NFe.Domain.Features.ItemInvoices
{
    public class ItemInvoice
    {
        public long Id { get; set; }
        public int Quantity { get; set; }

        public long InvoiceInProcessId { get; set; }
        public InvoiceInProcess InvoiceInProcess { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
	

		public double ICMSValue
        {
            get
            {
                return TotalValue * Product.AliquotICMS;
            }
        }
        public double IPIValue
        {
            get
            {
               return TotalValue* Product.AliquotIPI;
            }
        }
        public double TotalValue
        {
            get
            {
                return Product.UnitaryValue * Quantity;
            }
        }
    }
}
