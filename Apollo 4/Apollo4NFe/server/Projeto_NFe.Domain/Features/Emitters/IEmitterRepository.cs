using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Emitters
{
    public interface IEmitterRepository
    {
        Emitter Save(Emitter conveyor);
        bool Update(Emitter conveyor);
        bool Delete(long conveyor);
        Emitter Get(long id);
        IQueryable<Emitter> GetAll();
		IQueryable<Emitter> GetAll(int size);
		bool CheckDependency(Emitter conveyor);
    }
}
