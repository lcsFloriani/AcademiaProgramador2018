using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T Save(T objeto);

        IEnumerable<T> GetAll();

        T GetById(long Id);

        T Update(T objeto);

        bool Delete(T objeto);
    }
}
