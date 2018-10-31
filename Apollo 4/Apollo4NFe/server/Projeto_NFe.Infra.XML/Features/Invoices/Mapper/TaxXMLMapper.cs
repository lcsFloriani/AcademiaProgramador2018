//using Projeto_NFe.Domain.Features.Taxes;
//using Projeto_NFe.Infra.XML.Features.Invoices.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
//{
//    public class TaxXMLMapper : IMapper<TaxXMLModel, Tax>
//    {

//        private TaxXMLModel _taxXMLModel;

//        public TaxXMLModel Map(Tax entity)
//        {
//            _taxXMLModel = new TaxXMLModel
//            {
//                ICMSValue = entity.TotalIcmsValue.ToString(),
//                ValueFreight = entity.ValueFreight.ToString(),
//                IPIValue = entity.TotalIpiValue.ToString(),
//                ProductTotalValue = entity.TotalProductValue.ToString(),
//                TotalValue = entity.TotalInvoice.ToString()
//            };

//            return _taxXMLModel;
//        }
//    }
//}
