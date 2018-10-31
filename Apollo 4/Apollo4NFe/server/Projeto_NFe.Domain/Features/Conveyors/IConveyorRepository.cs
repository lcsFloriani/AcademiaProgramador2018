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
        bool Update(Conveyor conveyor);
        Conveyor Get(long id);
        IQueryable<Conveyor> GetAll();
        IQueryable<Conveyor> GetAll(int size);
        bool Delete(long conveyorId);
        bool CheckDependency(Conveyor conveyor);
    }
}
