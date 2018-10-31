using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Conveyors
{
    public interface IConveyorRepository
    {
        Conveyor Save(Conveyor conveyor);
        Conveyor Update(Conveyor conveyor);
        void Delete(Conveyor conveyor);
        Conveyor Get(long id);
        IEnumerable<Conveyor> GetAll();
        bool CheckDependency(Conveyor conveyor);
    }
}
