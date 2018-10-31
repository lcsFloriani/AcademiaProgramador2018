using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class ItemInvoiceXMLModel
    {
        [XmlAttribute]
        public int nItem { get; set; }
        [XmlElement("prod")]
        public ProductXMLModel Product { get; set; }
        [XmlElement("imposto")]
        public ProductTaxXMLModel Tax { get; set; }

    }
}
