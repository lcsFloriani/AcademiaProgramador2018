using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
{
    public class ProductXMLMapper : IMapper<ProductXMLModel, ItemInvoice>
    {
        private ProductXMLModel _productXMLModel;

        public ProductXMLModel Map(ItemInvoice entity)
        {
            _productXMLModel = new ProductXMLModel
            {
                Code = entity.Product.Code,
                Description = entity.Product.Description,
                Amount = entity.Quantity.ToString(),
                UnitaryValue = entity.Product.UnitaryValue.ToString(),
                TotalValue = entity.TotalValue.ToString()
            };

            return _productXMLModel;
        }
    }
}
