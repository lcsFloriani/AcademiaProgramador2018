using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceInProcessNatureOperationNullOrEmptyException : BusinessException
    {
        public InvoiceInProcessNatureOperationNullOrEmptyException() : base("A natureza da operação é um campo obrigatório!")
        {
        }
    }
}
