using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Base
{
    public interface IService<T>
    {
        void Adicionar(T entidade);
        void Editar(T entidade);
        void Deletar(T entidade);

        IList<T> TrazerTodos();
    }
}
