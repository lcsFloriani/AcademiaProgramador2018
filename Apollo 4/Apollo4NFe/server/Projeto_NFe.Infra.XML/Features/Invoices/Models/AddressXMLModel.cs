using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class AddressXMLModel
    {
        [XmlElement("xLgr")]
        public string Street { get; set; }
        [XmlElement("nro")]
        public int Number { get; set; }
        [XmlElement("xBairro")]
        public string Neighbourhood { get; set; }
        [XmlElement("xMun")]
        public string City { get; set; }
        [XmlElement("UF")]
        public string State { get; set; }
        [XmlElement("xPais")]
        public string Country { get; set; }
    }
}
