using BancoTabajara.Aplicacao.Funcionalidades.Movimentacoes.ViewModels;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas.ViewModels
{
    [XmlType(TypeName = "ContaExtrato")]
    public class ContaExtratoViewModel
    {
        [XmlElement("numeroConta")]
        public int NumeroConta { get; set; }

        [XmlElement("dataEmissao")]
        public DateTime DataEmissao { get; set; }

        [XmlElement("nomeCliente")]
        public string NomeCliente { get; set; }

        [XmlArray("Movimentacoes")]
        [XmlArrayItem("movimentacao")]
        public List<MovimentacaoViewModel> Movimentacoes { get; set; }

        [XmlElement("saldoDisponivel")]
        public double SaldoDisponivel { get; set; }

        [XmlElement("limiteAtual")]
        public double LimiteAtual { get; set; }
    }
}
