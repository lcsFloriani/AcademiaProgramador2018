using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Enedir.MF7.Application.Features.Functionaries.Commands
{
    public class FunctionaryChangeStatusCommand
    {
        public long Id { set; get; }
        public bool Status { set; get; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<FunctionaryChangeStatusCommand>
        {
            private long _lessThan = 0;

            public Validator()
            {
                RuleFor(x => x.Id).GreaterThan(_lessThan).WithMessage("O id não pode ser menor que zero!");
                RuleFor(x => x.Status).NotNull().WithMessage("O status não pode ser nulo!");
            }
        }
    }
}
