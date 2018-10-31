using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Taxes;
using Projeto_NFe.Infra.XML;
using Projeto_NFe.Domain.Exceptions;

namespace Projeto_NFe.Application.Features.Invoices
{
    public class InvoiceIssuedService : IInvoiceIssuedService
    {
        private readonly long _lessThan = 1;

        private IInvoiceIssuedRepository _invoiceIssuedRepository;
        private IInvoiceInProcessRepository _invoiceInProcessRepository;
        private IInvoiceIssuedXMLRepository _invoiceIssuedXMLRepository;
        private XMLHelper<InvoiceIssued> _xmlHelper;

        public InvoiceIssuedService(IInvoiceIssuedRepository invoiceIssuedRepository, IInvoiceInProcessRepository invoiceInProcessRepository, IInvoiceIssuedXMLRepository invoiceIssuedXMLRepository)
        {
            _invoiceIssuedRepository = invoiceIssuedRepository;
            _invoiceInProcessRepository = invoiceInProcessRepository;
            _invoiceIssuedXMLRepository = invoiceIssuedXMLRepository;

            _xmlHelper = new XMLHelper<InvoiceIssued>();
        }

        public InvoiceIssued IssuedNote(InvoiceInProcess invoiceInProcess)
        {
            invoiceInProcess.Validate();

            InvoiceIssued invoiceIssued = new InvoiceIssued(invoiceInProcess);
            invoiceIssued.IssuanceDate = DateTime.Now;

            if (_invoiceIssuedRepository.CheckAccessKeyIsRepeat(invoiceIssued))
                throw new InvoiceIssuedAccessKeyIsRepeatException();

            invoiceIssued = _invoiceIssuedRepository.Save(invoiceIssued);
            _invoiceInProcessRepository.Delete(invoiceInProcess);

            return invoiceIssued;
        }

        public void ExportToPDF(string key, string path)
        {
            throw new UnsupportedOperationException();
        }

        public void ExportToXML(string key, string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new InvalidPathException();

            InvoiceIssued invoice = GetByAccessKey(key);

            _invoiceIssuedXMLRepository.Export(invoice, path);
        }

        public InvoiceIssued Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            string xml = _invoiceIssuedRepository.Get(id);

            if (string.IsNullOrEmpty(xml))
                return null;

            InvoiceIssued invoice = _xmlHelper.Deserialize(xml);
            invoice.Tax.invoice = invoice;

            return invoice;
        }

        public IEnumerable<InvoiceIssued> GetAll()
        {
            var xmls = _invoiceIssuedRepository.GetAll();

            List<InvoiceIssued> invoices = new List<InvoiceIssued>();

            foreach (string xml in xmls)
            {
                if (!string.IsNullOrEmpty(xml))
                {
                    InvoiceIssued invoice = _xmlHelper.Deserialize(xml);
                    invoice.Tax.invoice = invoice;

                    invoices.Add(invoice);
                }
            }

            return invoices;
        }

        public InvoiceIssued GetByAccessKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new InvoiceIssuedAccessKeyNumberAccessKeyNullOrEmptyException();

            string xml = _invoiceIssuedRepository.GetByAccessKey(key);

            if (string.IsNullOrEmpty(xml))
                return null;

            InvoiceIssued invoice = _xmlHelper.Deserialize(xml);
            invoice.Tax.invoice = invoice;

            return invoice;
        }

        public void Delete(InvoiceIssued invoiceIssued)
        {
            if (invoiceIssued.Id < _lessThan)
                throw new IdentifierUndefinedException();

            _invoiceIssuedRepository.Delete(invoiceIssued);
        }
    }
}
