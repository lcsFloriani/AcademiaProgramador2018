using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Aplicacao.Interfaces
{
    public interface IService<T>
    {
        void Add(T objeto);

        List<T> GetAll();

        T GetById(long Id);

        void Update(T objeto);

        void Delete(T objeto);
    }
}
