//using Projeto_NFe.Domain.Features.Invoices;
//using Projeto_NFe.Domain.Features.ItemInvoices;
//using Projeto_NFe.Infra.XML.Features.Invoices.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
//{
//    public class InvoiceXMLMapper : IMapper<InvoiceXMLModel, InvoiceIssued>
//    {
//        private InvoiceIssuedXMLMapper _invoiceIssuedXMLMapper;
//        private EmitterXMLMapper _emitterXMLMapper;
//        private ReceiverXMLMapper _receiverXMLMapper;
//        private ItemInvoiceXMLMapper _itemInvoiceXMLMapper;
//        private TotalTaxXMLMapper _totalTaxXMLMapper;

//        private InvoiceXMLModel _invoiceXMLModel;


//        public InvoiceXMLModel Map(InvoiceIssued entity)
//        {
//            _invoiceIssuedXMLMapper = new InvoiceIssuedXMLMapper();
//            _emitterXMLMapper = new EmitterXMLMapper();
//            _receiverXMLMapper = new ReceiverXMLMapper();
//            _itemInvoiceXMLMapper = new ItemInvoiceXMLMapper();
//            _totalTaxXMLMapper = new TotalTaxXMLMapper();

//            _invoiceXMLModel = new InvoiceXMLModel
//            {
//                Id = "NFe" + entity.Key.NumberAccessKey,
//                InvoiceIssued = _invoiceIssuedXMLMapper.Map(entity),
//                EmitterXML = _emitterXMLMapper.Map(entity.Emitter),
//                ReceiverXML = _receiverXMLMapper.Map(entity.Receiver),
//                ItemsInvoice = MapToListItemInvoice(entity.Items),
//                TotalTax = _totalTaxXMLMapper.Map(entity.Tax)
//            };

//            return _invoiceXMLModel;
//        }


//        private List<ItemInvoiceXMLModel> MapToListItemInvoice(List<ItemInvoice> items)
//        {
//            List<ItemInvoiceXMLModel> listItemInvoice = new List<ItemInvoiceXMLModel>();

//            int count = 1;
//            foreach (ItemInvoice item in items)
//            {
//                ItemInvoiceXMLModel itemInvoiceModel = new ItemInvoiceXMLModel();
//                itemInvoiceModel = _itemInvoiceXMLMapper.Map(item);
//                itemInvoiceModel.nItem = count++;
//                listItemInvoice.Add(itemInvoiceModel);
//            }

//            return listItemInvoice;
//        }
//    }
//}
