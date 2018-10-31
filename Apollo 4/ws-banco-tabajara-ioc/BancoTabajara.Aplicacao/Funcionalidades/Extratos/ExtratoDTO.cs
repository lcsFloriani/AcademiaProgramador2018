using BancoTabajara.Aplicacao.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BancoTabajara.Aplicacao.Funcionalidades.Extratos
{
    [XmlRoot("extrato")]
    public class ExtratoDTO
    {
        [XmlElement("numeroConta")]
        public int NumeroConta { get; set; }
        [XmlElement("dataEmissao")]
        public DateTime DataEmissao { get; set; }
        [XmlElement("nomeCliente")]
        public string NomeCliente { get; set; }
        [XmlElement("historicoMovimentacoes")]
        public List<MovimentacaoDTO> Movimentacoes { get; set; }
        [XmlElement("saldoDisponivel")]
        public double SaldoDisponivel { get; set; }
        [XmlElement("limiteAtual")]
        public double LimiteAtual { get; set; }
    }
}
