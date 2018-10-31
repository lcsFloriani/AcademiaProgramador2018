using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.Items_invoice.Commands;
using Projeto_NFe.Application.Features.Invoices.Items_Invoice.Commands;
using Projeto_NFe.Application.Features.Invoices.Queries;
using Projeto_NFe.Domain.Features.Invoices;
using System.Linq;

namespace Projeto_NFe.Application.Features.Invoices
{
    public interface IInvoiceInProcessService
    {
        long Add(InvoiceProcessCommandRegister commandRegister);
        bool AddItem(ItemInvoiceRegisterCommand cmd);
        bool RemoveItem(ItemInvoiceDeleteCommand cmd);
        bool Update(InvoiceProcessCommandUpdate commandUpdate);
        InvoiceInProcess Get(long id);
        IQueryable<InvoiceInProcess> GetAll(InvoiceIInProcessQuery query);
        IQueryable<InvoiceInProcess> GetAll();
        bool Delete(InvoiceInProcessCommandDelete commandDelete);


    }
}
