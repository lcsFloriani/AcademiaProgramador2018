using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products.Commands
{
    public class ProductCommandUpdate
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitaryValue { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductCommandUpdate>
        {
            public Validator()
            {
                RuleFor(p => p.Id)
                              .GreaterThan(0)
                              .NotNull();
                RuleFor(p => p.Code).NotEmpty();
                RuleFor(p => p.Description)
                              .NotEmpty()
                              .MinimumLength(4)
                              .MaximumLength(100);
                RuleFor(p => p.UnitaryValue).GreaterThan(0);
            }
        }
    }
}
