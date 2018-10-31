using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Invoices
{
	public class InvoiceInProcessRepository : IInvoiceInProcessRepository
	{
		private ProjetoNFeContext _context;

		public InvoiceInProcessRepository(ProjetoNFeContext context)
		{
			_context = context;
		}


		public bool Delete(long invoiceInProcessId)
		{
			var invoice = Get(invoiceInProcessId);

			if (invoice == null)
				throw new NotFoundException();

			_context.InvoicesInProcess.Remove(invoice);
			_context.Entry(invoice).State = EntityState.Deleted;

			return _context.SaveChanges() > 0;
		}

		public bool DeleteItem(long itemId)
		{
			var item = _context.ItemInvoices.Where(c => c.Id == itemId).FirstOrDefault();

			if (item == null)
				throw new NotFoundException();

			_context.ItemInvoices.Remove(item);
			_context.Entry(item).State = EntityState.Deleted;

			return _context.SaveChanges() > 0;
		}

		public InvoiceInProcess Get(long id)
		{
			var invoice = _context.InvoicesInProcess
				.Include(c => c.Conveyor)
				.Include(c => c.Emitter)
				.Include(c => c.Receiver).Where(c => c.Id == id).FirstOrDefault();

			_context.ItemInvoices.Include(p => p.Product).Where(x => x.InvoiceInProcessId == invoice.Id).Load();

			return invoice;
		}

		public IQueryable<InvoiceInProcess> GetAll(int size)
		{
			return this._context.InvoicesInProcess
				.Include(c => c.Conveyor)
				.Include(c => c.Emitter)
				.Include(c => c.Receiver)
				.Take(size);
		}

		public IQueryable<InvoiceInProcess> GetAll()
		{
			return this._context.InvoicesInProcess
				.Include(c => c.Conveyor)
				.Include(c => c.Emitter)
				.Include(c => c.Receiver);
		}

		public InvoiceInProcess GetWithOutDependecyList(long id)
		{
			var invoice = _context.InvoicesInProcess
				.Include(c => c.Conveyor)
				.Include(c => c.Emitter)
				.Include(c => c.Receiver).Where(c => c.Id == id).FirstOrDefault();

			return invoice;
		}

		public InvoiceInProcess Save(InvoiceInProcess invoiceInProcess)
		{
			_context.InvoicesInProcess.Add(invoiceInProcess);
			_context.SaveChanges();

			return invoiceInProcess;
		}

		public bool Update(InvoiceInProcess invoiceInProcess)
		{

			_context.InvoicesInProcess.Attach(invoiceInProcess);
			_context.Entry(invoiceInProcess).State = EntityState.Modified;

			return _context.SaveChanges() > 0;
		}
	}
}

