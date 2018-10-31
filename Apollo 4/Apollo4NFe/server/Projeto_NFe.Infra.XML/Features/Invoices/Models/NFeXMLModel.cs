using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    [XmlRoot("NFe")]
    public class NFeXMLModel
    {
   
        [XmlElement("infNFe")]
        public InvoiceXMLModel InvoiceXMLModel { get; set; }

    }
}
