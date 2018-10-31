﻿using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Conveyors
{
    public class ConveyorWithDependencyException : BusinessException
    {
        public ConveyorWithDependencyException() : base("A transportadora não pode ser excluída, pois esta sendo usada como dependência!")
        {
        }
    }
}
