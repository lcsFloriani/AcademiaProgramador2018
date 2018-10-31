using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Dominio.Contratos
{
    public interface IRepositorio<T>
    {
        T Inserir(T entidade);
        T Atualizar(T entidade);
        void Deletar(T entidade);
        ICollection<T> PegarTodos();
        T PegarPorId(long id);
    }
}
