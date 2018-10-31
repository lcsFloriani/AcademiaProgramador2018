using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products.Commands
{
    public class ProductCommandDelete
    {
        public long[] Ids { get; set; }
        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductCommandDelete>
        {
            public Validator()
            {
                RuleFor(p => p.Ids).NotNull();
                RuleFor(p => p.Ids.Length).GreaterThan(0);
            }
        }
    }
}
