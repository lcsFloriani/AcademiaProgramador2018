using Projeto_NFe.Application.Features.Conveyors.Commands;
using Projeto_NFe.Application.Features.Conveyors.Queries;
using Projeto_NFe.Domain.Features.Conveyors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Conveyors
{
    public interface IConveyorService
    {
        long Add(ConveyorRegisterCommand command);
        bool Update(ConveyorUpdateCommand command);
        Conveyor Get(long id);
        IQueryable<Conveyor> GetAll();
        IQueryable<Conveyor> GetAll(ConveyorQuery query);
        bool Delete(ConveyorDeleteCommand command);
    }
}
