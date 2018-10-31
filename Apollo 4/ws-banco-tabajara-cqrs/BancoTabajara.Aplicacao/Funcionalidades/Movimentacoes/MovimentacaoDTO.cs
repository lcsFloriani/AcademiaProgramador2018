using BancoTabajara.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BancoTabajara.Aplicacao.Funcionalidades.Movimentacoes
{
    [XmlType(TypeName = "Movimentacao")]
    public class MovimentacaoDTO
    {
        [XmlElement("id")]
        public long Id { get; set; }
        [XmlElement("data")]
        public DateTime Data { get; set; }
        [XmlElement("tipoOperacao")]
        public TipoOperacaoEnum TipoOperacao { get; set; }
        [XmlElement("valor")]
        public double Valor { get; set; }
    }
}
