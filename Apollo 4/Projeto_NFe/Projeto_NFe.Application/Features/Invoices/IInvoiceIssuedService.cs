using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices
{
    public interface IInvoiceIssuedService
    {
        InvoiceIssued IssuedNote(InvoiceInProcess invoiceInProcess);
        InvoiceIssued Get(long id);
        InvoiceIssued GetByAccessKey(string key);
        IEnumerable<InvoiceIssued> GetAll();
        void Delete(InvoiceIssued invoiceIssued);
        void ExportToXML(string key, string path);
        void ExportToPDF(string key, string path);
    }
}
