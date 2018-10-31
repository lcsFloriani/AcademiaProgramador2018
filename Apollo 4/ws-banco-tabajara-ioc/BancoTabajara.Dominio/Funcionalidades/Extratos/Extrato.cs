using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Dominio.Funcionalidades.Extratos
{
    public class Extrato
    {
        public int NumeroConta { get; set; }
        public DateTime DataEmissao { get; set; }
        public string NomeCliente { get; set; }
        public List<Movimentacao> Movimentacoes { get; set; }
        public double SaldoDisponivel { get; set; }
        public double LimiteAtual { get; set; }
    }
}
