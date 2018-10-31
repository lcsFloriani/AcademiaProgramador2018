using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Infra.ORM.Context;

using System.Data.Entity;
using System.Linq;


namespace Enedir.MF7.Infra.ORM.Features.Functionaries
{
    public class FunctionaryRepository : IFunctionaryRepository
    {
        private MF7DbContext _context;
        private int equalZero = 0;

        public FunctionaryRepository(MF7DbContext context)
        {
            this._context = context;
        }

        public Functionary Save(Functionary functionary)
        {
            var newFunctionary = _context.Functionaries.Add(functionary);
            _context.SaveChanges();

            return newFunctionary;
        }

        public bool Update(Functionary functionary)
        {
            _context.Functionaries.Attach(functionary);
            _context.Entry(functionary).State = EntityState.Modified;

            int affectedRows = _context.SaveChanges();

            return affectedRows > equalZero;
        }

        public Functionary GetById(long id)
        {
           return _context.Functionaries.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Delete(Functionary functionary)
        {
            _context.Functionaries.Remove(functionary);

            int affectedRows = _context.SaveChanges();

            return affectedRows > equalZero;
        }

        public IQueryable<Functionary> GetAll(int quantity)
        {
            return _context.Functionaries.Take(quantity);
        }

        public bool HasDependency(Functionary functionary)
        {
            int count = _context.Outgoing.Where( o => o.FunctionaryId == functionary.Id).Count();  

            return count > equalZero;
        }

        public bool CheckCredential(string user, string password)
        {
            int count = _context.Functionaries.Where(c => c.User.Equals(user) && c.Password.Equals(password)).Count();

            return count > equalZero;
        }
    }
}
