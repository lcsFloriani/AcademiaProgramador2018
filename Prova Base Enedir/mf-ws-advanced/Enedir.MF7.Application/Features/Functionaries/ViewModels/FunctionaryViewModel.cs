using Enedir.MF7.Domain.Features.Functionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Enedir.MF7.Application.Features.Functionaries.ViewModels
{
    [XmlType(TypeName = "Funcionario")]
    public class FunctionaryViewModel
    {
       
        [XmlElement("PrimerioNome")]
        public string FullName { set; get; }
        [XmlElement("Usuario")]
        public string User { set; get; }
        [XmlElement("Cargo")]
        public OfficeEnum Office { set; get; }
        [XmlElement("Ativo")]
        public bool Status { set; get; }
       
    }
}
