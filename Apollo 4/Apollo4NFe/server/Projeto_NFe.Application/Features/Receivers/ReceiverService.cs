using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Application.Features.Receivers.Commands;
using AutoMapper;
using Projeto_NFe.Application.Features.Receivers.Queries;

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

		public long Add(ReceiverRegisterCommand command)
		{
			var receiver = Mapper.Map<ReceiverRegisterCommand, Receiver>( command );

			Receiver newReceiver = _receiverRepository.Save(receiver);

			return newReceiver.Id;
		}

		public bool Update(ReceiverUpdateCommand command)
		{
			var receiver = _receiverRepository.Get( command.Id ) ?? throw new NotFoundException();

			if (receiver == null)
				throw new NotFoundException();
	
			Mapper.Map(command, receiver );

			return _receiverRepository.Update( receiver );
		}

		public Receiver Get(long id)
		{
			var receiver = _receiverRepository.Get( id );

			if (receiver == null)
				throw new NotFoundException();

			return receiver;
		}

		public IQueryable<Receiver> GetAll()
		{
			return _receiverRepository.GetAll();
		}

		public IQueryable<Receiver> GetAll(ReceiverQuery query)
		{
			return _receiverRepository.GetAll( query.Size );
		}

		public bool Delete(ReceiverDeleteCommand command)
		{
			var isRemovedAll = true;
			foreach (var orderId in command.ReceiverIds) {
				var isRemoved = _receiverRepository.Delete( orderId );
				// Aqui poderia dar o tramento adequado, armazenado quais ids foram removidos
				// e quais não forma removidos (e buscar o porquê). 
				// Como é somente um exemplo, vamos somente retornar false (que não foi totalmente concluído)
				isRemovedAll = isRemoved ? isRemovedAll : false;
			}
			return isRemovedAll;
		}
	}
}
