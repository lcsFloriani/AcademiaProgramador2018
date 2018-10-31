using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Domain.Features.Outgoing
{
    public interface IOutgoRepository
    {
        Outgo Save(Outgo outgo);
        Outgo GetById(long id);
        IQueryable<Outgo> GetAll(int quantity);
        bool Delete(Outgo outgo);
    }
}
