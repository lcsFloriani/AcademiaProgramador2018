using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Commands
{
    public class InvoiceInProcessCommandDelete
    {
        public long[] InvoiceIds { get; set; }
        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }
        class Validator : AbstractValidator<InvoiceInProcessCommandDelete>
        {
            public Validator()
            {
                RuleFor(p => p.InvoiceIds).NotNull();
                RuleFor(p => p.InvoiceIds.Length).GreaterThan(0);
            }
        }
    }
}
