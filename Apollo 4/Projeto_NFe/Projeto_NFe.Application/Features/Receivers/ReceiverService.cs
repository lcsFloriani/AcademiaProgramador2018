using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;

namespace Projeto_NFe.Application.Features.Receivers
{
    public class ReceiverService : IReceiverService
    {
        private readonly long _lessThan = 1;

        private IReceiverRepository _receiverRepository;

        public ReceiverService(IReceiverRepository receiverRepository)
        {
            _receiverRepository = receiverRepository;
        } 
        public Receiver Add(Receiver receiver)
        {
            receiver.Validate();

            receiver = _receiverRepository.Save(receiver);

            return receiver;
        }

        public Receiver Update(Receiver receiver)
        {
            if (receiver.Id < _lessThan)
                throw new IdentifierUndefinedException();

            receiver.Validate();

            receiver = _receiverRepository.Update(receiver);
            
            return receiver;
        }

        public Receiver Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            return _receiverRepository.Get(id);
        }

        public IEnumerable<Receiver> GetAll()
        {
            return _receiverRepository.GetAll();
        }

         public void Delete(Receiver receiver)
        {
            if (receiver.Id < _lessThan)
                throw new IdentifierUndefinedException();

            if (_receiverRepository.CheckDependency(receiver))
            {
                throw new ReceiverWithDependencyException();
            }
            else
                _receiverRepository.Delete(receiver);
        }
    }
}
