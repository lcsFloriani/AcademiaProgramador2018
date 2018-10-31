using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceIssuedAccessKeyIsRepeatException : BusinessException
    {
        public InvoiceIssuedAccessKeyIsRepeatException() : base("Essa chave de acesso já existe!")
        {

        }
    }
}
