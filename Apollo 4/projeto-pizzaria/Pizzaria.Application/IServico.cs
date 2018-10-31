using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application
{
    public interface IServico<T>
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        T BuscarPorId(long id);
        List<T> Listagem();
        void Excluir(T entidade);
    }
}
