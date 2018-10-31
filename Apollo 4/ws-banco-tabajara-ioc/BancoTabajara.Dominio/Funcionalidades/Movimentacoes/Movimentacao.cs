using BancoTabajara.Dominio.Enum;
using BancoTabajara.Dominio.Funcionalidades.Contas;

using System;

namespace BancoTabajara.Dominio.Funcionalidades.Movimentacoes
{
    public class Movimentacao
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public TipoOperacaoEnum TipoOperacao { get; set; }
        public double Valor { get; set; }

        public long? ContaId { get; set; }
        public Conta Conta { get; set; }
        
    }
}