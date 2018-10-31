using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
{
    public class ProductTaxICMSXMLMapper : IMapper<ProductTaxICMSXMLModel, ItemInvoice>
    {

        private ProductTaxICMS00XMLMapper _productTaxICMS00XMLMapper;
        private ProductTaxICMSXMLModel _productTaxICMSXMLModel;

        public ProductTaxICMSXMLModel Map(ItemInvoice entity)
        {
            _productTaxICMS00XMLMapper = new ProductTaxICMS00XMLMapper();

            _productTaxICMSXMLModel = new ProductTaxICMSXMLModel
            {
                TaxICMS00 = _productTaxICMS00XMLMapper.Map(entity)
            };

            return _productTaxICMSXMLModel;
        }
    }
}
