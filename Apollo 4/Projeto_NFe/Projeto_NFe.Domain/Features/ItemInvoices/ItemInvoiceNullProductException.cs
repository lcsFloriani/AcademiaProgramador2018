using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.ItemInvoices
{
    public class ItemInvoiceNullProductException : BusinessException
    {
        public ItemInvoiceNullProductException() : base("O produto não pode ser nulo!")
        {
        }
    }
}
