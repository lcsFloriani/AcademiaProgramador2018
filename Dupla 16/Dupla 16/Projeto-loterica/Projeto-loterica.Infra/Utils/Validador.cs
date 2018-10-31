using Projeto_loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Infra.Utils
{
    public static class Validador
    {
        public static void ValidateId(long Id)
        {
            if (Id.Equals(0))
                throw new IdentifierUndefinedException();

        }
    }
}
