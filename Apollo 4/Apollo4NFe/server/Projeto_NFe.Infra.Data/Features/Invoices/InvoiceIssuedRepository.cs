//using Projeto_NFe.Domain.Enums;
//using Projeto_NFe.Domain.Exceptions;
//using Projeto_NFe.Domain.Features.Invoices;
//using Projeto_NFe.Infra.AccessKeys;
//using Projeto_NFe.Infra.ORM.Context;
//using Projeto_NFe.Infra.XML;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Projeto_NFe.Infra.Data.Features.Invoices
//{
//    public class InvoiceIssuedRepository : IInvoiceIssuedRepository
//    {
//        private ProjetoNFeContext _context;

//        public InvoiceIssuedRepository(ProjetoNFeContext context)
//        {
//            this._context = context;
//        }

//        public bool Delete(long Id)
//        {
//            var invoice = Get(Id);
//            var _affectedRows = 0;
//            if (invoice == null)
//                throw new NotFoundException();

//            _context.InvoicesIssued.Remove(invoice);
//            return _context.SaveChanges() > _affectedRows;
//        }

//        public InvoiceIssued Get(long id)
//        {
//            return _context.InvoicesIssued.Where(c => c.Id == id).FirstOrDefault();
//        }
//        public InvoiceIssued GetByAccessKey(string key)
//        {
//            return _context.InvoicesIssued.Where(i => i.Key.Equals(key)).FirstOrDefault();
//        }

//        public IQueryable<InvoiceIssued> GetAll(int size)
//        {
//            return this._context.InvoicesIssued.Take(size);
//        }

//        public IQueryable<InvoiceIssued> GetAll()
//        {
//            return this._context.InvoicesIssued;
//        }

//        public InvoiceIssued Save(InvoiceIssued invoice)
//        {
//            invoice.Emitter = _context.Emitters.Where(i => i.Id == invoice.EmitterId).FirstOrDefault();
//            invoice.Receiver = _context.Receivers.Where(i => i.Id == invoice.ReceiverId).FirstOrDefault();
//            if (invoice.ConveyorId != null)
//                invoice.Conveyor = _context.Conveyors.Where(i => i.Id == invoice.ConveyorId).FirstOrDefault();

//            return _context.InvoicesIssued.Add(invoice);
//        }

//        public bool Update(InvoiceIssued invoice)
//        {
//            invoice.Emitter = _context.Emitters.Where(i => i.Id == invoice.EmitterId).FirstOrDefault();
//            invoice.Receiver = _context.Receivers.Where(i => i.Id == invoice.ReceiverId).FirstOrDefault();

//            if (invoice.ConveyorId != 0)
//                invoice.Conveyor = _context.Conveyors.Where(i => i.Id == invoice.ConveyorId).FirstOrDefault();

//            _context.Entry(invoice).State = EntityState.Modified;
//            return _context.SaveChanges() > 0;
//        }
//    }
//}
