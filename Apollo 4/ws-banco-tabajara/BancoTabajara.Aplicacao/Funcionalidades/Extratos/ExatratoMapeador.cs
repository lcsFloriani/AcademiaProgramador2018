using BancoTabajara.Aplicacao.Funcionalidades.Movimentacoes;
using BancoTabajara.Dominio.Funcionalidades.Extratos;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Aplicacao.Funcionalidades.Extratos
{
    public static class ExatratoMapeador
    {
        public static ExtratoDTO ConverterParaDTO(this Extrato extrato)
        {
            return new ExtratoDTO
            {
                NumeroConta = extrato.NumeroConta,
                NomeCliente = extrato.NomeCliente,
                DataEmissao = extrato.DataEmissao,
                Movimentacoes = ConverterParaListaMovimentacoesDTO(extrato.Movimentacoes),
                SaldoDisponivel = extrato.SaldoDisponivel,
                LimiteAtual = extrato.LimiteAtual
            };
        }

        private static List<MovimentacaoDTO> ConverterParaListaMovimentacoesDTO(List<Movimentacao> movimentacoes)
        {
            List<MovimentacaoDTO> movimentacoesDTO = new List<MovimentacaoDTO>();

            foreach (Movimentacao m in movimentacoes)
                movimentacoesDTO.Add(m.ConverterParaDTO());

            return movimentacoesDTO;
        }
    }
}
