using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Domain.Features.Functionaries
{
    public interface IFunctionaryRepository
    {
        Functionary Save(Functionary functionary);
        bool Update(Functionary functionary);
        Functionary GetById(long id);
        IQueryable<Functionary> GetAll(int quantity);
        bool Delete(Functionary functionary);
        bool HasDependency(Functionary functionary);
        bool CheckCredential(string user, string password);
    }
}
