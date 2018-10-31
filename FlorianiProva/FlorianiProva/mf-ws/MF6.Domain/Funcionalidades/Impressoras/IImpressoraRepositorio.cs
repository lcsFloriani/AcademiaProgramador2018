using System.Linq;

namespace MF6.Domain.Funcionalidades.Impressoras
{
    public interface IImpressoraRepositorio
    {
        IQueryable<Impressora> PegarTodos();

        Impressora Inserir(Impressora impressora);

        bool Atualizar(Impressora impressora);

        Impressora PegarPorId(long impressoraId);

        bool Deletar(long impressoraId);
    }
}
