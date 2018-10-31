using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.ItemInvoices
{
    public class ItemInvoiceQuantityLessThanOneException : BusinessException
    {
        public ItemInvoiceQuantityLessThanOneException() : base("A quantidade não pode ser menor que 1!")
        {
        }
    }
}
