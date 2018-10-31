using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T objeto);

        List<T> GetAll();

        T GetById(long Id);

        void Update(T objeto);

        void Delete(T objeto);
    }
}
