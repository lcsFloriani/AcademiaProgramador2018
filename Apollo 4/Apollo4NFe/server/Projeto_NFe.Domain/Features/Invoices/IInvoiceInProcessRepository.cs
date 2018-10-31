using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public interface IInvoiceInProcessRepository
    {
        InvoiceInProcess Save(InvoiceInProcess invoiceInProcess);
        bool Update(InvoiceInProcess invoiceInProcess);
        bool Delete(long invoiceInProcessId);
        bool DeleteItem(long itemId);
        InvoiceInProcess Get(long id);
		InvoiceInProcess GetWithOutDependecyList(long id);
		IQueryable<InvoiceInProcess> GetAll();
		IQueryable<InvoiceInProcess> GetAll(int size);
	}
}
