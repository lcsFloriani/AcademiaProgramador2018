using FlorianiProva.Dominio.Features.Avaliações;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Aplicacao.Features.Avaliacoes
{
    public interface IAvaliacaoService
    {
        Avaliacao Inserir(Avaliacao avaliacao);

        Avaliacao Atualizar(Avaliacao avaliacao);

        List<Avaliacao> ObterTodos();

        Avaliacao ObterPorId(long id);

        bool Deletar(long id);
    }
}
