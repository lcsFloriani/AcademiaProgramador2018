using MF6.Domain.Funcionalidades.Impressoras;
using System.Linq;

namespace MF6.Application.Funcionalidades.Impressoras
{
    public interface IImpressoraServico
    {
        long Inserir(Impressora impressora);
        bool Atualizar(Impressora impressora);
        bool Deletar(Impressora impressora);
        IQueryable<Impressora> PegarTodos();
        Impressora PegarPorId(long id);
    }
}
