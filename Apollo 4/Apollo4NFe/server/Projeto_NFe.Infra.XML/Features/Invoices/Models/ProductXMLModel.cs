using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class ProductXMLModel
    {
        [XmlElement("cProd")]
        public string Code { get; set; }
        [XmlElement("xProd")]
        public string Description { get; set; }
        [XmlElement("qCom")]
        public string Amount { get; set; }
        [XmlElement("vUnCom")]
        public string UnitaryValue { get; set; }
        [XmlElement("vProd")]
        public string TotalValue { get; set; }
    }
}
