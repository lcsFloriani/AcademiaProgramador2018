using Projeto_NFe.Application.Features.Emitters.Commands;
using Projeto_NFe.Application.Features.Emitters.Queries;
using Projeto_NFe.Domain.Features.Emitters;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_NFe.Application.Features.Emitters
{
    public interface IEmitterService
    {
        long Add(EmitterRegisterCommand emitterCmd);
        bool Update(EmitterUpdateCommand emitterCmd);
        Emitter Get(long id);
        IQueryable<Emitter> GetAll(EmitterQuery query);
        IQueryable<Emitter> GetAll();
        bool Delete(EmitterDeleteCommand emitterCmd);
    }
}
