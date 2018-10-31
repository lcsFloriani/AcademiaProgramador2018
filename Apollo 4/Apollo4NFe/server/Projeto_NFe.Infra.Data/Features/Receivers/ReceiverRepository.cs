using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Projeto_NFe.Infra.Data.Features.Receivers
{
    public class ReceiverRepository : IReceiverRepository
    {
		private ProjetoNFeContext _context;
		private long _affectedRows = 0;


		public ReceiverRepository(ProjetoNFeContext context)
		{
			this._context = context;
		}

		public bool CheckDependency(Receiver receiver)
		{
			int count = _context.InvoicesInProcess.Where( n => n.ReceiverId == receiver.Id ).Count();

			return count > _affectedRows;
		}

		public bool Delete(long receiverId)
		{
			var receiver = Get( receiverId );

			if (receiver == null)
				throw new NotFoundException();

			_context.Entry( receiver ).State = EntityState.Deleted;
			return _context.SaveChanges() > _affectedRows;
		}

		public Receiver Get(long id)
		{
			return _context.Receivers.Where( c => c.Id == id ).FirstOrDefault();
		}

		public IQueryable<Receiver> GetAll(int size)
		{
			return this._context.Receivers.Take( size );
		}

		public IQueryable<Receiver> GetAll()
		{
			return this._context.Receivers;
		}

		public Receiver Save(Receiver receiver)
		{
			_context.Receivers.Add( receiver );
			_context.SaveChanges();

			return receiver;
		}

		public bool Update(Receiver receiver)
		{
			_context.Entry( receiver ).State = EntityState.Modified;
			return _context.SaveChanges() > _affectedRows;
		}
	}
}
