using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Emitters.Commands
{
    public class EmitterDeleteCommand
    {
        public virtual long[] EmitterIds { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<EmitterDeleteCommand>
        {
            public Validator()
            {
                RuleFor(c => c.EmitterIds).NotNull();
                RuleFor(c => c.EmitterIds.Length).GreaterThan(0);
            }
        }
    }
}
