using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF6.Domain.Funcionalidades.Toners
{
    public interface ITonerRepositorio
    {
        IQueryable<Toner> PegarTodos();

        Toner Inserir(Toner toner);

        bool Atualizar(Toner toner);

        Toner PegarPorId(long tonerId);

        bool Deletar(long tonerId);
    }
}
