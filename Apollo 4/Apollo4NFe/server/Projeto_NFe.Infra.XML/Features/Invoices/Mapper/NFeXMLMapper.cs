//using Projeto_NFe.Domain.Features.Invoices;
//using Projeto_NFe.Infra.XML.Features.Invoices.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
//{
//    public class NFeXMLMapper : IMapper<NFeXMLModel, InvoiceIssued>
//    {
   
//        private InvoiceXMLMapper _invoiceXMLMapper;
//        private NFeXMLModel _nFeXMLModel;

//        public NFeXMLModel Map(InvoiceIssued entity)
//        {
//            _invoiceXMLMapper = new InvoiceXMLMapper();

//            _nFeXMLModel = new NFeXMLModel
//            {
//                InvoiceXMLModel = _invoiceXMLMapper.Map(entity),
//            };

//            return _nFeXMLModel;
//        }
//    }
//}
