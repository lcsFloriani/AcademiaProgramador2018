using Projeto_NFe.Infra.AccessKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public interface IInvoiceIssuedRepository
    {
        InvoiceIssued Save(InvoiceIssued invoiceIssued);
        bool Update(InvoiceIssued invoiceIssued);
        bool Delete(long id);
        InvoiceIssued Get(long id);
        InvoiceIssued GetByAccessKey(string key);
        IQueryable<InvoiceIssued> GetAll();
        IQueryable<InvoiceIssued> GetAll(int size);
    }
}
