using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Aplicacao.Funcionalidades.Movimentacoes
{
    public static class MovimentacaoMapeador
    {
        public static MovimentacaoDTO ConverterParaDTO(this Movimentacao movimentacao)
        {
            return new MovimentacaoDTO
            {
                Id = movimentacao.Id,
                TipoOperacao = movimentacao.TipoOperacao,
                Data = movimentacao.Data,
                Valor = movimentacao.Valor
            };
        }
    }
}
