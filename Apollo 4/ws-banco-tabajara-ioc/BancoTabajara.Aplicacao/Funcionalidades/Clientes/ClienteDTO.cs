using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes
{
    [XmlType(TypeName = "Cliente")]
    public class ClienteDTO
    {
        [XmlElement("id")]
        public long Id { get; set; }
        [XmlElement("nome")]
        public string Nome { get; set; }
        [XmlElement("cpf")]
        public string CPF { get; set; }
        [XmlElement("dataNascimento")]
        public DateTime DataNascimento { get; set; }
        [XmlElement("rg")]
        public string RG { get; set; }
    }
}
