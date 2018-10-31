using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Emitters;

namespace Projeto_NFe.Application.Features.Emitters
{
    public class EmitterService : IEmitterService
    {
        private readonly long _lessThan = 1;

        private IEmitterRepository _emitterRepository;

        public EmitterService(IEmitterRepository repositoryEmitter)
        {
            _emitterRepository = repositoryEmitter;
        }

        public Emitter Add(Emitter emitter)
        {
            emitter.Validate();
            emitter = _emitterRepository.Save(emitter);
          
            return emitter;
        }

        public Emitter Update(Emitter emitter)
        {
            if (emitter.Id < _lessThan)
                throw new IdentifierUndefinedException();

            emitter.Validate();

            emitter = _emitterRepository.Update(emitter);
          
            return emitter;
        }

        public Emitter Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();
            return _emitterRepository.Get(id);
        }

        public IEnumerable<Emitter> GetAll()
        {
            return _emitterRepository.GetAll();
        }

        public void Delete(Emitter emitter)
        {
            if (emitter.Id < _lessThan)
                throw new IdentifierUndefinedException();

            if (_emitterRepository.CheckDependency(emitter))
            {
                throw new EmitterWithDependencyException();
            }
            else
                _emitterRepository.Delete(emitter);
        }
    }
}
