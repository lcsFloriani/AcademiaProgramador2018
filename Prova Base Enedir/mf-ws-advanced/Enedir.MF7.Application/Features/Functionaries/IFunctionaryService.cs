using Enedir.MF7.Application.Features.Functionaries.Commands;
using Enedir.MF7.Application.Features.Functionaries.Querys;
using Enedir.MF7.Domain.Features.Functionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Application.Features.Functionaries
{
    public interface IFunctionaryService
    {
        long Add(FunctionaryRegisterCommand command);
        bool ChangeStatus(FunctionaryChangeStatusCommand command);
        bool Update(FunctionaryUpdateCommand command);
        Functionary GetById(long id);
        IQueryable<Functionary> GetAll(FunctionaryQuery query);
        bool Remove(FunctionaryDeleteCommand command);
        bool CredentialVerify(string user, string password);
    }
}
