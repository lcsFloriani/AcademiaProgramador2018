﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Exceptions
{
    public class OperacaoNaoDefinidaExcecao : Exception
    {
        public OperacaoNaoDefinidaExcecao() : base("Operação não suportada!")
        {

        }
    }
}
