using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class InvoiceInProcessValueFreightLessThanZeroException : BusinessException
    {
        public InvoiceInProcessValueFreightLessThanZeroException( ) : base("O valor de frete deve ser maior que zero!")
        {
        }
    }
}
