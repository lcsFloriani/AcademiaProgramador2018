using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class TaxXMLModel
    {
        [XmlElement("vICMS")]
        public string ICMSValue { get; set;}
        [XmlElement("vFrete")]
        public string ValueFreight { get; set; }
        [XmlElement("vIPI")]
        public string IPIValue { get; set; }
        [XmlElement("vNF")]
        public string ProductTotalValue { get; set; }
        [XmlElement("vTotTrib")]
        public string TotalValue { get; set; }
    }
}
