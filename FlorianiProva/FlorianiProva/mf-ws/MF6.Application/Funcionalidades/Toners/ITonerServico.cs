using MF6.Domain.Funcionalidades.Toners;
using System.Linq;

namespace MF6.Application.Funcionalidades.Toners
{
    public interface ITonerServico
    {
        long Inserir(Toner toner);
        bool Atualizar(Toner toner);
        bool Deletar(Toner toner);
        IQueryable<Toner> PegarTodos();
        Toner PegarPorId(long id);
    }
}
