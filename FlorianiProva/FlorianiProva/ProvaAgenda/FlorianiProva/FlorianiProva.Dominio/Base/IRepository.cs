using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Base
{
    public interface IRepository<T> where T : Entidade 
    {
        T Adicionar(T entidade);
        T Editar(T entidade);
        void Deletar(T entidade);
        IList<T> TrazerTodos();

    }
}
