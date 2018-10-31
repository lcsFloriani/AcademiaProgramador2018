using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
{
    public class ItemInvoiceXMLMapper : IMapper<ItemInvoiceXMLModel, ItemInvoice>
    {
        private ProductXMLMapper _productXMLMapper;

        private ItemInvoiceXMLModel _itemInvoiceXMLModel;

        public ItemInvoiceXMLModel Map(ItemInvoice entity)
        {
            _productXMLMapper = new ProductXMLMapper();

            _itemInvoiceXMLModel = new ItemInvoiceXMLModel
            {
                Product = _productXMLMapper.Map(entity),
            };

            return _itemInvoiceXMLModel;
        }
    }
}
