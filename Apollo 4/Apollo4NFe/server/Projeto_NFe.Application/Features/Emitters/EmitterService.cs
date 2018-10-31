using AutoMapper;
using Projeto_NFe.Application.Features.Emitters.Commands;
using Projeto_NFe.Application.Features.Emitters.Queries;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Emitters;
using System.Linq;

namespace Projeto_NFe.Application.Features.Emitters
{
    public class EmitterService : IEmitterService
    {
        private IEmitterRepository _emitterRepository;

        public EmitterService(IEmitterRepository repositoryEmitter)
        {
            _emitterRepository = repositoryEmitter;
        }

        public long Add(EmitterRegisterCommand command)
        {
            Emitter emitter = Mapper.Map<EmitterRegisterCommand, Emitter>(command);

            Emitter newEmitter = _emitterRepository.Save(emitter);

            return newEmitter.Id;
        }

        public bool Update(EmitterUpdateCommand command)
        {
            Emitter emitter = _emitterRepository.Get(command.Id) ?? throw new NotFoundException();

            Mapper.Map(command, emitter);

            return _emitterRepository.Update(emitter);
        }

        public Emitter Get(long id)
        {
            Emitter emitter = _emitterRepository.Get(id);

            if (emitter == null)
                throw new NotFoundException();

            return emitter;
        }

        public IQueryable<Emitter> GetAll(EmitterQuery query)
        {
            return _emitterRepository.GetAll(query.Size);
        }

        public IQueryable<Emitter> GetAll()
        {
            return _emitterRepository.GetAll();
        }

        public bool Delete(EmitterDeleteCommand emitterCmd)
        {
            var isRemovedAll = true;
            foreach (var emitterId in emitterCmd.EmitterIds)
            {
                var isRemoved = _emitterRepository.Delete(emitterId);
                isRemovedAll = isRemoved ? isRemovedAll : false;
            }
            return isRemovedAll;
        }
    }
}
