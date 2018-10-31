using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceIssuedDateSmallerThanEntryDateException : BusinessException
    {
        public InvoiceIssuedDateSmallerThanEntryDateException() : base("A data de emissão não pode ser menor que a data de entrada!")
        {
        }
    }
}
