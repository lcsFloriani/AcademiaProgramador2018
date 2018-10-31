using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Domain.Features.Outgoing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Enedir.MF7.Application.Features.Outgoing.ViewModels
{
    [XmlType(TypeName = "Funcionario")]
    public class OutgoViewModel
    {
        [XmlElement("Descricao")]
        public string Description { set; get; }
        [XmlElement("Data")]
        public DateTime date { set; get; }
        [XmlElement("Tipo")]
        public OutgoTypeEnum OutgoType { set; get; }
        [XmlElement("Funcionario")]
        public string FunctionaryName { set; get; }
    }
}
