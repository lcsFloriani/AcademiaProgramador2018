using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;

namespace Projeto_NFe.Application.Features.Invoices
{
    public class InvoiceInProcessService : IInvoiceInProcessService
    {
        private IInvoiceInProcessRepository _invoiceInProcessRepository;
        private IItemInvoiceRepository _itemInvoiceRepository;

        private readonly long _lessThan = 1;

        public InvoiceInProcessService(IInvoiceInProcessRepository invoiceInProcessRepository, IItemInvoiceRepository itemInvoiceRepository)
        {
            _invoiceInProcessRepository = invoiceInProcessRepository;
            _itemInvoiceRepository = itemInvoiceRepository;
        }

        public InvoiceInProcess Add(InvoiceInProcess invoiceInProcess)
        {
            invoiceInProcess.Validate();

            invoiceInProcess = _invoiceInProcessRepository.Save(invoiceInProcess);

            for (int i = 0; i < invoiceInProcess.Items.Count; i++)
            {
                invoiceInProcess.Items[i].Invoice = invoiceInProcess;
                invoiceInProcess.Items[i] = _itemInvoiceRepository.Save(invoiceInProcess.Items[i]);
            }

            return invoiceInProcess;
        }

        public void Delete(InvoiceInProcess invoiceInProcess)
        {
            if (invoiceInProcess.Id < _lessThan)
                throw new IdentifierUndefinedException();

            _invoiceInProcessRepository.Delete(invoiceInProcess);
        }

        public InvoiceInProcess Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            InvoiceInProcess invoice = _invoiceInProcessRepository.Get(id);

            if (invoice != null)
                invoice.Items = _itemInvoiceRepository.GetByInvoice(invoice) as List<ItemInvoice>;

            return invoice;
        }

        public IEnumerable<InvoiceInProcess> GetAll()
        {
            var lista = _invoiceInProcessRepository.GetAll() as List<InvoiceInProcess>;

            for (int i = 0; i < lista.Count(); i++)
            {
                lista[i].Items = _itemInvoiceRepository.GetByInvoice(lista[i]) as List<ItemInvoice>;
            }

            return lista;
        }

        public InvoiceInProcess Update(InvoiceInProcess invoiceInProcess)
        {
            if (invoiceInProcess.Id < _lessThan)
                throw new IdentifierUndefinedException();

            invoiceInProcess.Validate();

            _invoiceInProcessRepository.Update(invoiceInProcess);

            for (int i = 0; i < invoiceInProcess.Items.Count; i++)
            {
                if (invoiceInProcess.Items[i].Id < _lessThan)
                {
                    invoiceInProcess.Items[i].Invoice = invoiceInProcess;
                    invoiceInProcess.Items[i] = _itemInvoiceRepository.Save(invoiceInProcess.Items[i]);
                }
                else
                {
                    invoiceInProcess.Items[i] = _itemInvoiceRepository.Update(invoiceInProcess.Items[i]);
                }
            }

            return invoiceInProcess;
        }
    }
}
