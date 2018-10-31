using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.Items_invoice.Commands;
using Projeto_NFe.Application.Features.Invoices.Items_Invoice.Commands;
using Projeto_NFe.Application.Features.Invoices.Queries;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Receivers;

namespace Projeto_NFe.Application.Features.Invoices
{
    public class InvoiceInProcessService : IInvoiceInProcessService
    {
        private IInvoiceInProcessRepository _invoiceInProcessRepository;
        private readonly IProductRepository _productRepository;
		private readonly IConveyorRepository _conveyorRepository;
		private readonly IEmitterRepository _emitterRepository;
		private readonly IReceiverRepository _receiverRepository;


		private readonly long _lessThan = 1;

        public InvoiceInProcessService(IInvoiceInProcessRepository invoiceInProcessRepository, IProductRepository productRepository, IConveyorRepository conveyorRepository, IEmitterRepository emitterRepository, IReceiverRepository receiverRepository)
        {
            _invoiceInProcessRepository = invoiceInProcessRepository;
            _productRepository = productRepository;
			_conveyorRepository = conveyorRepository;
		    _emitterRepository = emitterRepository;
		    _receiverRepository = receiverRepository;
	}

        public long Add(InvoiceProcessCommandRegister commandRegister)
        {
            InvoiceInProcess invoice = Mapper.Map<InvoiceProcessCommandRegister, InvoiceInProcess>(commandRegister);

            InvoiceInProcess newInvoice = _invoiceInProcessRepository.Save(invoice);

            return newInvoice.Id;
        }

        public bool AddItem(ItemInvoiceRegisterCommand cmdItem)
        {
            var invoice = _invoiceInProcessRepository.Get(cmdItem.InvoiceId) ?? throw new NotFoundException();

            var product = _productRepository.Get(cmdItem.ItemInvoice);
            var itemInvoice = new ItemInvoice();
            itemInvoice.InvoiceInProcessId = invoice.Id;
            itemInvoice.ProductId = product.Id;

            itemInvoice.InvoiceInProcess = invoice;
            itemInvoice.Product = product;

            itemInvoice.Quantity = cmdItem.Quantity;
            invoice.AddItem(itemInvoice);

            return _invoiceInProcessRepository.Update(invoice);
        }
        public bool RemoveItem(ItemInvoiceDeleteCommand cmdItem)
        {
            var isRemovedAll = true;
            foreach (var itemId in cmdItem.ItemsInvoiceId)
            {
                var isRemoved = _invoiceInProcessRepository.DeleteItem(itemId);
                isRemovedAll = isRemoved ? isRemovedAll : false;
            }

            return isRemovedAll;
        }
        public bool Update(InvoiceProcessCommandUpdate commandUpdate)
        {
            InvoiceInProcess invoice = _invoiceInProcessRepository.GetWithOutDependecyList(commandUpdate.Id) ?? throw new NotFoundException();

			Mapper.Map(commandUpdate, invoice);

			invoice.Conveyor = _conveyorRepository.Get(invoice.ConveyorId);
			invoice.Emitter = _emitterRepository.Get(invoice.EmitterId);
			invoice.Receiver = _receiverRepository.Get(invoice.ReceiverId);

			return _invoiceInProcessRepository.Update(invoice);
        }

        public InvoiceInProcess Get(long id)
        {
            InvoiceInProcess invoice = _invoiceInProcessRepository.Get(id);

            if (invoice == null)
                throw new NotFoundException();

            return invoice;
        }

        public IQueryable<InvoiceInProcess> GetAll(InvoiceIInProcessQuery query)
        {
            return _invoiceInProcessRepository.GetAll(query.Size);
        }

        public IQueryable<InvoiceInProcess> GetAll()
        {
            return _invoiceInProcessRepository.GetAll();
        }

        public bool Delete(InvoiceInProcessCommandDelete commandDelete)
        {
            var isRemovedAll = true;
            foreach (var invoiceId in commandDelete.InvoiceIds)
            {
                var isRemoved = _invoiceInProcessRepository.Delete(invoiceId);
                isRemovedAll = isRemoved ? isRemovedAll : false;
            }
            return isRemovedAll;
        }
    }
}
