using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
{
    public class ProductTaxXMLMapper : IMapper<ProductTaxXMLModel, ItemInvoice>
    {
        private ProductTaxICMSXMLMapper _productTaxICMSXMLMapper;
        private ProductTaxXMLModel _productTaxXMLModel;

        public ProductTaxXMLModel Map(ItemInvoice entity)
        {
            _productTaxICMSXMLMapper = new ProductTaxICMSXMLMapper();

            _productTaxXMLModel = new ProductTaxXMLModel
            {
                TaxICMS = _productTaxICMSXMLMapper.Map(entity)
            };

            return _productTaxXMLModel;
        }
    }
}
