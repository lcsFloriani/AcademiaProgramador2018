using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class ProductTaxICMS00XMLModel
    {
        [XmlElement("pICMS")]
        public string AliquotICMS { get; set; }
        [XmlElement("vICMS")]
        public string ICMSValue { get; set; }
    }
}
