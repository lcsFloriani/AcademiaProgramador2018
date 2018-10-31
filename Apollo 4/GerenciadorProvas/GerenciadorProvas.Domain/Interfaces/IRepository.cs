using GerenciadorProvas.Dominio;
using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Interfaces
{
    public interface IRepository<T> where T : Entidade
    {

        T Adicionar(T entidade);

        IList<T> Listagem();

        T ProcuraPorId(int id);

        T Atualizar(T entidade);

        void Excluir(T entidade);

    }
}
