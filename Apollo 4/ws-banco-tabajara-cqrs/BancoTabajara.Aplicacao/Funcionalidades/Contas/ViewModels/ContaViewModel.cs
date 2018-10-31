using BancoTabajara.Aplicacao.Funcionalidades.Movimentacoes.ViewModels;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas.ViewModels
{
    [XmlType(TypeName = "Conta")]
    public class ContaViewModel
    {
        [XmlElement("id")]
        public long Id { get; set; }

        [XmlElement("NumeroConta")]
        public int NumeroConta { get; set; }

        [XmlElement("Saldo")]
        public double Saldo { get; set; }

        [XmlElement("Estado")]
        public bool Estado { get; set; }

        [XmlElement("Limite")]
        public double Limite { get; set; }

        [XmlArray("Movimentacoes")]
        [XmlArrayItem("movimentacao")]
        public virtual List<MovimentacaoViewModel> Movimentacoes { get; set; }

        [XmlElement("ClienteId")]
        public long ClienteId { get; set; }

        [XmlElement("Cliente")]
        public virtual Cliente Cliente { get; set; }
    }
}
