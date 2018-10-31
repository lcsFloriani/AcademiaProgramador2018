using FlorianiProva.Dominio.Features.Avaliações;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Comum.ObjetosMae.Avaliacoes
{
    public static class AvaliacaoObjetoMae
    {
        public static Avaliacao AvaliacaoComAssuntoEmBranco() => new Avaliacao
        {
            Assunto = "",
            Data = DateTime.Now,
        };
        public static Avaliacao AvaliacaoValida() => new Avaliacao { Id = 2, Assunto = "TDD", Data = DateTime.Now };
    }

}
