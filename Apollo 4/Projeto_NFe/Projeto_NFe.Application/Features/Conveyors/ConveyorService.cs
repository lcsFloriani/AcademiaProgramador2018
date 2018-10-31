using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;

namespace Projeto_NFe.Application.Features.Conveyors
{
    public class ConveyorService : IConveyorService
    {
        private readonly long _lessThan = 1;

        private IConveyorRepository _conveyorRepository;

        public ConveyorService(IConveyorRepository conveyorRepository)
        {
            _conveyorRepository = conveyorRepository;
        }

        public Conveyor Add(Conveyor conveyor)
        {
            conveyor.Validate();

            conveyor = _conveyorRepository.Save(conveyor);

            return conveyor;
        }

        public Conveyor Update(Conveyor conveyor)
        {
            if (conveyor.Id < _lessThan)
                throw new IdentifierUndefinedException();

            conveyor.Validate();

            conveyor = _conveyorRepository.Update(conveyor);

            return conveyor;
        }

        public Conveyor Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            return _conveyorRepository.Get(id);
        }

        public IEnumerable<Conveyor> GetAll()
        {
            return _conveyorRepository.GetAll();
        }

        public void Delete(Conveyor conveyor)
        {
            if (conveyor.Id < _lessThan)
                throw new IdentifierUndefinedException();

            if (_conveyorRepository.CheckDependency(conveyor))
            {
                throw new ConveyorWithDependencyException();
            } else
                _conveyorRepository.Delete(conveyor);
        }
    }
}
