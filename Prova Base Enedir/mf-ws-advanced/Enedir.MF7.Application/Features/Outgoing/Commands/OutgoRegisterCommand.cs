using Enedir.MF7.Domain.Features.Outgoing;
using FluentValidation;
using FluentValidation.Results;
using System;


namespace Enedir.MF7.Application.Features.Outgoing.Commands
{
    public class OutgoRegisterCommand
    {
        public string Description { set; get; }
        public DateTime Date { set; get; }
        public Double Price { set; get; }
        public long FunctionaryId { set; get; }
        public OutgoTypeEnum OutgoType { set; get; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<OutgoRegisterCommand>
        {
            private long _lessThan = 0;
            private int mouths = -6;

            public Validator()
            {
                RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("A descrição não pode ser nulo ou vazio!");
                RuleFor(x => x.Date).GreaterThan(p => DateTime.Now.AddMonths(mouths)).WithMessage("A data não pode ser nulo ou menor que 6 meses!");
                RuleFor(x => x.Price).GreaterThanOrEqualTo(_lessThan).WithMessage("O preco não pode ser negativo!");
                RuleFor(x => x.FunctionaryId).GreaterThan(_lessThan).WithMessage("O id do funcionario não pode ser 0 ou menor!");
                RuleFor(x => x.OutgoType).NotNull().NotEmpty().WithMessage("O tipo não pode ser nulo ou vazio!");
            }
        }
    }
}
