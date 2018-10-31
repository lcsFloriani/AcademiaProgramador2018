using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class EmitterXMLModel
    {
        [XmlElement("CNPJ")]
        public string Cnpj { get; set; }
        [XmlElement("xNome")]
        public string CompanyName { get; set; }
        [XmlElement("xFant")]
        public string FantasyName { get; set; }
        [XmlElement("IE")]
        public string StateRegistration { get; set; }
        [XmlElement("IM")]
        public string MunicipalRegistration { get; set; }
        [XmlElement("enderEmit")]
        public AddressXMLModel Address { get; set; }
    }
}
