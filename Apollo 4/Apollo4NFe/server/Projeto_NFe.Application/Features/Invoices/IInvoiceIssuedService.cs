using Projeto_NFe.Application.Features.Invoices.Commands;
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
        InvoiceIssued Add(InvoiceProcessCommandRegister cmd);
        InvoiceIssued Get(long id);
        bool Update(InvoiceProcessCommandUpdate invoice); 
        InvoiceIssued GetByAccessKey(string key);
        IQueryable<InvoiceIssued> GetAll();
        bool Delete(InvoiceInProcessCommandDelete cmd);
    }
}
