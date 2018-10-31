using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Conveyors.Commands
{
    public class ConveyorUpdateCommand
    {
        public long Id { get; set; }
        public PersonType PersonType { get; set; }
        public string NameCompanyName { get; set; }
        public FreightResponsibility FreightResponsibility { get; set; }
        public string CpfCnpj { get; set; }
        public Address Address { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validador().Validate(this);
        }

        class Validador : AbstractValidator<ConveyorUpdateCommand>
        {
            private int _greaterThan = 0;

            public Validador()
            {
                RuleFor(x => x.Id).GreaterThan(_greaterThan).WithMessage("O Id não pode ser menor que 1");
                RuleFor(x => x.NameCompanyName).NotNull().NotEmpty().WithMessage("O nome não pode ser nulo ou vazio!");
                RuleFor(x => x.CpfCnpj).NotNull().NotEmpty().WithMessage("O CPF/CNPJ não pode ser nulo ou vazio!");
                RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("O endereço não pode ser nulo ou vazio!");
            }
        }
    }
}

