using Projeto_NFe.Domain.Features.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Emitters
{
    public interface IEmitterService
    {
        Emitter Add(Emitter emitter);
        Emitter Update(Emitter emitter);
        Emitter Get(long id);
        IEnumerable<Emitter> GetAll();
        void Delete(Emitter emitter);
    }
}
