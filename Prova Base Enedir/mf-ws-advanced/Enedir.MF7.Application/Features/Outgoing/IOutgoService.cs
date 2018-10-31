using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enedir.MF7.Application.Features.Outgoing.Commands;
using Enedir.MF7.Application.Features.Outgoing.Querys;
using Enedir.MF7.Domain.Features.Outgoing;

namespace Enedir.MF7.Application.Features.Outgoing
{
    public interface IOutgoService
    {
        long Add(OutgoRegisterCommand command);
        Outgo GetById(long id);
        IQueryable<Outgo> GetAll(OutgoQuery query);
        bool Remove(OutgoDeleteCommand command);
    }
}
