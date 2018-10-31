using Projeto_loterica.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Interfaces
{
    public interface IRepository<T> where T : Entidade
    {
        T Add(T objeto);

        IEnumerable<T> GetAll();

        T GetById(long Id);

        T Update(T objeto);

        void Delete(T objeto);
    }
}
