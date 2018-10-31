using System;
using System.Xml.Serialization;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes.ViewModels
{
    [XmlType(TypeName = "Cliente")]
    public class ClienteViewModel
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
