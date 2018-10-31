using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Taxes;
using Projeto_NFe.Infra.XML;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Application.Features.Invoices.Commands;
using AutoMapper;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Application.Features.Invoices.Queries;

namespace Projeto_NFe.Application.Features.Invoices
{
    public class InvoiceIssuedService : IInvoiceIssuedService
    {
        private readonly long _lessThan = 1;

        private IInvoiceIssuedRepository _invoiceIssuedRepository;

        public InvoiceIssuedService(IInvoiceIssuedRepository invoiceIssuedRepository)
        {
            _invoiceIssuedRepository = invoiceIssuedRepository;
        }

        public InvoiceIssued Add(InvoiceProcessCommandRegister command)
        {
            var invoice = Mapper.Map<InvoiceProcessCommandRegister, InvoiceIssued>(command);

            return _invoiceIssuedRepository.Save(invoice);;
        }

        public InvoiceIssued Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            InvoiceIssued invoice = _invoiceIssuedRepository.Get(id);
           
            return invoice;
        }

        public IQueryable<InvoiceIssued> GetAll()
        {
            return _invoiceIssuedRepository.GetAll();
        }
        public IQueryable<InvoiceIssued> GetAll(InvoiceIInProcessQuery query)
        {
            return _invoiceIssuedRepository.GetAll(query.Size);
        }

        public InvoiceIssued GetByAccessKey(string key)
        {
            return _invoiceIssuedRepository.GetByAccessKey(key);
        }

        public bool Delete(InvoiceInProcessCommandDelete cmd)
        {
            var isRemovedAll = true;
            foreach (var orderId in cmd.InvoiceIds)
            {
                var isRemoved = _invoiceIssuedRepository.Delete(orderId);
                isRemovedAll = isRemoved ? isRemovedAll : false;
            }
            return isRemovedAll;
        }
        public bool Update(InvoiceProcessCommandUpdate cmd)
        {
            var invoiceIssued = Mapper.Map<InvoiceProcessCommandUpdate, InvoiceIssued>(cmd);

            return _invoiceIssuedRepository.Update(invoiceIssued);
        }
    }
}
