using BancoTabajara.Dominio.Funcionalidades.Extratos;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Common.Tests.Funcionalidades
{
    public partial class ObjetoMae
    {
        public static Extrato ObterExtrato()
        {
            return new Extrato
            {
                NumeroConta = 1452,
                NomeCliente = "Teste",
                DataEmissao = DateTime.Now,
                LimiteAtual = 100,
                SaldoDisponivel = 50,
                Movimentacoes = new List<Movimentacao>()
            };
        }
    }
}