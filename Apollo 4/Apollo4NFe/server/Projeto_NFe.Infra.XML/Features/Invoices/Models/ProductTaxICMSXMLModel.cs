using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class ProductTaxICMSXMLModel
    {
        [XmlElement("ICMS00")]
        public ProductTaxICMS00XMLModel TaxICMS00 { get; set; }
    }
}
