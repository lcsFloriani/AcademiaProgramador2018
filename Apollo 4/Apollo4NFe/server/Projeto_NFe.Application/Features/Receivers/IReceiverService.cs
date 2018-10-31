using Projeto_NFe.Application.Features.Receivers.Commands;
using Projeto_NFe.Application.Features.Receivers.Queries;
using Projeto_NFe.Domain.Features.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Receivers
{
    public interface IReceiverService
    {
        long Add(ReceiverRegisterCommand command);
        bool Update(ReceiverUpdateCommand command);
        Receiver Get(long id);
		IQueryable<Receiver> GetAll();
		IQueryable<Receiver> GetAll(ReceiverQuery query);
		bool Delete(ReceiverDeleteCommand command);
    }
}
