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
        InvoiceIssued Update(InvoiceIssued invoiceIssued);
        void Delete(InvoiceIssued invoiceIssued);
        string Get(long id);
        string GetByAccessKey(string key);
        bool CheckAccessKeyIsRepeat(InvoiceIssued invoiceIssued);
        IEnumerable<string> GetAll();
    }
}
