using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Emitters
{
    public class EmitterCompanyNameNullOrEmptyException : BusinessException
    {
        public EmitterCompanyNameNullOrEmptyException() : base("A Razão Social não pode ser nula ou vazia!")
        {
        }
    }
}
