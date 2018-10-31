using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Aplicacao.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas
{
    [XmlType(TypeName = "Conta")]
    public class ContaDTO
    {
        [XmlElement("id")]
        public long Id { get; set; }
        [XmlElement("numeroConta")]
        public int NumeroConta { get; set; }
        [XmlElement("saldo")]
        public double Saldo { get; set; }
        [XmlElement("estado")]
        public bool Estado { get; set; }
        [XmlElement("limite")]
        public double Limite { get; set; }
        [XmlArray("historicoMovimentacoes")]
        public List<MovimentacaoDTO> Movimentacoes { get; set; }
        public ClienteDTO Cliente { get; set; }
    }
}
