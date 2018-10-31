using BancoTabajara.Dominio.Enum;
using System;
using System.Xml.Serialization;

namespace BancoTabajara.Aplicacao.Funcionalidades.Movimentacoes.ViewModels
{
    [XmlType(TypeName = "Movimentacao")]
    public class MovimentacaoViewModel
    {
        [XmlElement("id")]
        public long Id { get; set; }

        [XmlElement("Data")]
        public DateTime Data { get; set; }

        [XmlElement("TipoOperacao")]
        public TipoOperacaoEnum TipoOperacao { get; set; }

        [XmlElement("Valor")]
        public double Valor { get; set; }
    }
}
