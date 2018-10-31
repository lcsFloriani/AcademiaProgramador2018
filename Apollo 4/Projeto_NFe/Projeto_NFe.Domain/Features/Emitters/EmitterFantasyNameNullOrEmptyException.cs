using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Emitters
{
    public class EmitterFantasyNameNullOrEmptyException : BusinessException
    {
        public EmitterFantasyNameNullOrEmptyException() : base("O Nome Fantasia não pode ser nulo ou vazio!")
        {
        }
    }
}
