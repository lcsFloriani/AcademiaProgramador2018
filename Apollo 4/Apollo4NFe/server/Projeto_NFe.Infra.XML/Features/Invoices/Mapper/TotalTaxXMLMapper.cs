//using Projeto_NFe.Domain.Features.Taxes;
//using Projeto_NFe.Infra.XML.Features.Invoices.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
//{
//    public class TotalTaxXMLMapper : IMapper<TotalTaxXMLModel, Tax>
//    {
//        private TaxXMLMapper _taxXMLMapper;
//        private TotalTaxXMLModel _totalTaxXMLModel;

//        public TotalTaxXMLModel Map(Tax entity)
//        {
//            _taxXMLMapper = new TaxXMLMapper();

//            _totalTaxXMLModel = new TotalTaxXMLModel
//            {
//                Tax = _taxXMLMapper.Map(entity)
//            };

//            return _totalTaxXMLModel;
//        }
//    }
//}
