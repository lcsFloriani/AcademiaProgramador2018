using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_NFe.Application.Features.Conveyors.Commands;
using Projeto_NFe.Application.Features.Conveyors.Queries;
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

        public long Add(ConveyorRegisterCommand command)
        {
            Conveyor conveyor = Mapper.Map<ConveyorRegisterCommand, Conveyor>(command);

            Conveyor newConveyor = _conveyorRepository.Save(conveyor);

            return newConveyor.Id;
        }

        public bool Update(ConveyorUpdateCommand command)
        {
            Conveyor conveyor = _conveyorRepository.Get(command.Id) ?? throw new NotFoundException();
            
            Mapper.Map(command, conveyor);

            return _conveyorRepository.Update(conveyor);
        }

        public Conveyor Get(long id)
        {
            Conveyor conveyor = _conveyorRepository.Get(id);

            if (conveyor == null)
                throw new NotFoundException();

            return conveyor;
        }

        public IQueryable<Conveyor> GetAll()
        {
            return _conveyorRepository.GetAll();
        }

        public IQueryable<Conveyor> GetAll(ConveyorQuery query)
        {
            return _conveyorRepository.GetAll(query.Size);
        }

        public bool Delete(ConveyorDeleteCommand command)
        {
            var isRemovedAll = true;
            foreach (var conveyorId in command.ConveyorsIds)
            {
                var isRemoved = _conveyorRepository.Delete(conveyorId);
                isRemovedAll = isRemoved ? isRemovedAll : false;
            }
            return isRemovedAll;
        }
    }
}
