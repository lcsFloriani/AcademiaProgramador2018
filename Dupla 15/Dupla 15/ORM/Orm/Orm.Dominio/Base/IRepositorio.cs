using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Dominio.Base
{
    public interface IRepositorio<T> where T : Entidade
    {
        T Salvar(T entidade);
        T Atualizar(T entidade);
        void Deletar(T entidade);
        IList<T> PegarTodos();
        T PegarPorId(long id);
    }
}
