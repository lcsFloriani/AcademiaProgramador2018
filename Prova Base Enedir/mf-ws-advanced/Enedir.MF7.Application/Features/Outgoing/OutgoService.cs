using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enedir.MF7.Application.Features.Functionaries;
using Enedir.MF7.Application.Features.Outgoing.Commands;
using Enedir.MF7.Application.Features.Outgoing.Querys;
using Enedir.MF7.Domain.Exceptions;
using Enedir.MF7.Domain.Features.Outgoing;

namespace Enedir.MF7.Application.Features.Outgoing
{
    public class OutgoService : IOutgoService
    {
        private IOutgoRepository _repository;
        private IFunctionaryService _functionaryService;

        private long _lessThan = 1;

        public OutgoService(IOutgoRepository repository, IFunctionaryService functionaryService)
        {
            _repository = repository;
            _functionaryService = functionaryService;
        }

        public long Add(OutgoRegisterCommand command)
        {
            Outgo outgo = command.ConvertToObject();

            outgo.Functionary = _functionaryService.GetById(outgo.FunctionaryId);

            var newOutgo = _repository.Save(outgo);

            return newOutgo.Id;
        }

        public IQueryable<Outgo> GetAll(OutgoQuery query)
        {
            return _repository.GetAll(query.Quantity);
        }

        public Outgo GetById(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            return _repository.GetById(id);
        }

        public bool Remove(OutgoDeleteCommand command)
        {
            var deleteOutgo = _repository.GetById(command.Id);

            return _repository.Delete(deleteOutgo);
        }

    }
}
