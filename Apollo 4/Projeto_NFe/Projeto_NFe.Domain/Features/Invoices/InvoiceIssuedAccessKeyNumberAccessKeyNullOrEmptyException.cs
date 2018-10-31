using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceIssuedAccessKeyNumberAccessKeyNullOrEmptyException : BusinessException
    {
        public InvoiceIssuedAccessKeyNumberAccessKeyNullOrEmptyException() : base("O valor da chave de acesso não pode ser nulo ou vazio!")
        {

        }
    }
}
