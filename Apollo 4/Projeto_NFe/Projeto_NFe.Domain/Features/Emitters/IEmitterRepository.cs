using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Emitters
{
    public interface IEmitterRepository
    {
        Emitter Save(Emitter emitter);
        Emitter Update(Emitter emitter);
        void Delete(Emitter emitter);
        Emitter Get(long id);
        IEnumerable<Emitter> GetAll();
        bool CheckDependency(Emitter emitter);
    }
}
