using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Application.Features.Functionaries.Commands
{
    public class FunctionaryDeleteCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<FunctionaryDeleteCommand>
        {
            private long _GreaterThan = 0;

            public Validator()
            {
                RuleFor(x => x.Id).GreaterThan(_GreaterThan).WithMessage("O id não pode ser menor que zero!");
            }
        }
    }
}
