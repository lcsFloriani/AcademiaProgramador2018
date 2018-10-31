using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Aplicacao.Funcionalidades.Movimentacoes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas
{
    public static class ContaMapeador
    {
        public static ContaDTO ConverterParaDTO(this Conta conta)
        {
            return new ContaDTO
            {
                Id = conta.Id,
                NumeroConta = conta.NumeroConta,
                Saldo = conta.Saldo,
                Limite = conta.Limite,
                Estado = conta.Estado,
                Cliente = conta.Cliente.ConverterParaDTO(),
                Movimentacoes = ConverterParaListaMovimentacoes(conta.Movimentacoes)
            };
        }

        public static IQueryable<ContaDTO> ConverterParaListaDTO(this IQueryable<Conta> contas)
        {
            List<ContaDTO> lista = new List<ContaDTO>();

            foreach (Conta c in contas)
                lista.Add(c.ConverterParaDTO());

            return lista.AsQueryable();
        }

        private static List<MovimentacaoDTO> ConverterParaListaMovimentacoes(List<Movimentacao> movimentacoes)
        {
            List<MovimentacaoDTO> lista = new List<MovimentacaoDTO>();

            foreach (Movimentacao m in movimentacoes)
                lista.Add(m.ConverterParaDTO());

            return lista;
        }
    }
}
