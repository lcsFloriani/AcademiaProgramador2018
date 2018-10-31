using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Resultados
{
    public interface IResultadoRepository
    {
        Resultado Inserir(Resultado result);

        Resultado Atualizar(Resultado result);

        List<Resultado> ObterTodos();

        Resultado ObterPorId(long id);

        bool Deletar(long id);
    }
}
