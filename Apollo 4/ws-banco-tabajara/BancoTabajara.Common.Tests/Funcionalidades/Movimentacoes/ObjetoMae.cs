using BancoTabajara.Dominio.Enum;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
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
        
        public static Movimentacao ObterMovimentacaoDebito(Conta conta)
        {
            return new Movimentacao
            {
              TipoOperacao = TipoOperacaoEnum.Debito,
              Conta = conta,
              Data = DateTime.Now.AddDays(-2),
              Valor = 300
            };
        }

        public static Movimentacao ObterMovimentacaoCredito(Conta conta)
        {
            return new Movimentacao
            {
                TipoOperacao = TipoOperacaoEnum.Credito,
                Conta = conta,
                Data = DateTime.Now.AddDays(-1),
                Valor = 150
            };
        }
    }
}
