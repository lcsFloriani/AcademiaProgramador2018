using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
{
    public class ProductTaxICMS00XMLMapper : IMapper<ProductTaxICMS00XMLModel, ItemInvoice>
    {
        private ProductTaxICMS00XMLModel _productTaxICMS00XMLModel;

        public ProductTaxICMS00XMLModel Map(ItemInvoice entity)
        {
            _productTaxICMS00XMLModel = new ProductTaxICMS00XMLModel
            {
                AliquotICMS = entity.Product.AliquotICMS.ToString(),
                ICMSValue = entity.ICMSValue.ToString()
            };

            return _productTaxICMS00XMLModel;
        }
    }
}
