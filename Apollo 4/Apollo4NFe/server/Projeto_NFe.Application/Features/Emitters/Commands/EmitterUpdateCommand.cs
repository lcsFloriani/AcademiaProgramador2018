using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Infra.Extension_Methods;

namespace Projeto_NFe.Application.Features.Emitters.Commands
{
    public class EmitterUpdateCommand
    {
        public long Id { get; set; }
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string StateRegistration { get; set; }
        public string MunicipalRegistration { get; set; }
        public AddressCommand Address { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validador().Validate(this);
        }

        class Validador : AbstractValidator<EmitterUpdateCommand>
        {
            private int _greaterThan = 0;

            public Validador()
            {
                RuleFor(x => x.Id).GreaterThan(_greaterThan).WithMessage("O Id não pode ser menor que 1");

                RuleFor(x => x.FantasyName).NotNull().NotEmpty().WithMessage("O nome fantasia não pode ser nulo ou vazio!");

                RuleFor(x => x.CompanyName).NotNull().NotEmpty().WithMessage("A razão social não pode ser nula ou vazia!");

                RuleFor(x => x.Cnpj).NotNull().NotEmpty().WithMessage("O CNPJ não pode ser nulo ou em branco!").CpfCnpjValid().WithMessage("O CNPJ não pode ser invalido!");

                RuleFor(x => x.StateRegistration).NotNull().NotEmpty().WithMessage("A inscrição estadual não pode ser nula ou vazia!");

                RuleFor(x => x.MunicipalRegistration).NotNull().NotEmpty().WithMessage("A inscrição municipal não pode ser nula ou vazia!");
            }
        }
    }
}
