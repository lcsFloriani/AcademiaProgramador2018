using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceInProcessEmitterNullException : BusinessException
    {
        public InvoiceInProcessEmitterNullException() : base("O emitente é um campo obrigatório!")
        {
        }
    }
}
