using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Conveyors.Commands
{
    public class ConveyorDeleteCommand
    {
        public virtual long[] ConveyorsIds { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validador().Validate(this);
        }

        class Validador : AbstractValidator<ConveyorDeleteCommand>
        {
            private int _greaterThan = 0;

            public Validador()
            {
                RuleFor(c => c.ConveyorsIds).NotNull();
                RuleFor(c => c.ConveyorsIds.Length).GreaterThan(_greaterThan);
            }
        }
    }
}