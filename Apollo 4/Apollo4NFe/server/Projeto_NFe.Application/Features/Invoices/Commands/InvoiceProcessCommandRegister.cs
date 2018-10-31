using FluentValidation;
using FluentValidation.Results;
using System;

namespace Projeto_NFe.Application.Features.Invoices.Commands
{
    public class InvoiceProcessCommandRegister
    {
        public DateTime EntryDate { get; set; }
        public string NatureOperation { get; set; }
        public double ValueFreight { get; set; }
        public long ConveyorId { get; set; }
        public long EmitterId { get; set; }
        public long ReceiverId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<InvoiceProcessCommandRegister>
        {
            public Validator()
            {
                RuleFor(p => p.EmitterId).NotNull();
                RuleFor(p => p.ReceiverId).NotNull();
                RuleFor(p => p.ValueFreight).GreaterThan(0)
                                               .NotNull();
                RuleFor(p => p.NatureOperation).NotEmpty()
                                               .MaximumLength(50)
                                               .MinimumLength(5);
                RuleFor(p => p.EntryDate).NotNull();
            }
        }
    }

}
