using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enedir.MF7.Domain.Features.Outgoing;
using Enedir.MF7.Infra.ORM.Context;

namespace Enedir.MF7.Infra.ORM.Features.Outgoing
{
    public class OutgoRepository : IOutgoRepository
    {
        private MF7DbContext _context;
        private int equalZero = 0;

        public OutgoRepository(MF7DbContext context)
        {
            _context = context;
        }

        public bool Delete(Outgo outgo)
        {
            _context.Outgoing.Remove(outgo);

            int affectedRows = _context.SaveChanges();

            return affectedRows > equalZero;
        }

        public IQueryable<Outgo> GetAll(int quantity)
        {
            return _context.Outgoing.Take(quantity);
        }

        public Outgo GetById(long id)
        {
            return _context.Outgoing.Where(c => c.Id == id).FirstOrDefault();
        }

        public Outgo Save(Outgo outgo)
        {
            var newFunctionary = _context.Outgoing.Add(outgo);
            _context.SaveChanges();

            return newFunctionary;
        }

    }
}
