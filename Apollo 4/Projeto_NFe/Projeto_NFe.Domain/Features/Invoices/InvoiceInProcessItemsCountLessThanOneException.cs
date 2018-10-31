using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceInProcessItemsCountLessThanOneException : BusinessException
    {
        public InvoiceInProcessItemsCountLessThanOneException() : base("A lista de itens de nota fiscal deve ter mais de um item!")
        {
        }
    }
}
