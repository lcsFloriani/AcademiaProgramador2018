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
        Conveyor Add(Conveyor conveyor);
        Conveyor Update(Conveyor conveyor);
        Conveyor Get(long id);
        IEnumerable<Conveyor> GetAll();
        void Delete(Conveyor conveyor);
    }
}
