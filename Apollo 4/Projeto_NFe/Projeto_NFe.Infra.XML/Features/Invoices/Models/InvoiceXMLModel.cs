using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class InvoiceXMLModel
    {
        [XmlAttribute]
        public string Id { get; set; }
        [XmlElement("ide")]
        public InvoiceIssuedXMLModel InvoiceIssued { get; set; }
        [XmlElement("emit")]
        public EmitterXMLModel EmitterXML { get; set; }
        [XmlElement("dest")]
        public ReceiverXMLModel ReceiverXML { get; set; }
        [XmlElement("det")]
        public List<ItemInvoiceXMLModel> ItemsInvoice { get; set; }
        [XmlElement("total")]
        public TotalTaxXMLModel TotalTax { get; set; }
    }
}
