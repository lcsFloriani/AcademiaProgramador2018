using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Domain.Features.ItemInvoices
{
    public class ItemInvoice : IEntity
    {
        public long Id { get; set; }
        [XmlIgnore]
        public InvoiceInProcess Invoice { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
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

        public virtual void Validate()
        {
            if (Product == null)
                throw new ItemInvoiceNullProductException();

            Product.Validate();

            if (Quantity < 1)
                throw new ItemInvoiceQuantityLessThanOneException();
        }

        public void SetProduct(Product product)
        {
            if (product != null)
            {
                product.Validate();
                Product = product;
            }
            else
                throw new ItemInvoiceNullProductException();
        }
    }
}
