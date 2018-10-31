using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Models
{
    public class ReceiverXMLModel
    {
        [XmlElement("CNPJ")]
        public string Cnpj { get; set; }
        [XmlElement("CPF")]
        public string Cpf { get; set; }
        [XmlElement("xNome")]
        public string NameCompanyName { get; set; }
        [XmlElement("IE")]
        public string StateRegistration { get; set; }
        [XmlElement("enderDest")]
        public AddressXMLModel Address { get; set; }
    }
}
