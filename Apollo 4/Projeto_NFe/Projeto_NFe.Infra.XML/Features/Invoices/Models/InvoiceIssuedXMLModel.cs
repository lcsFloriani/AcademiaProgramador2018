using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class InvoiceIssuedXMLModel
    {
        [XmlElement("natOp")]
        public string NatureOperation { get; set; }
        [XmlElement("dhEmi")]
        public DateTime IssuanceDate { get; set; }
    }
}
