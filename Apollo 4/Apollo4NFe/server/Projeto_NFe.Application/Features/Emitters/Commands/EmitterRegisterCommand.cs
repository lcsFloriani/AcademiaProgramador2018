using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.Addresses;
using Projeto_NFe.Infra.Extension_Methods;

namespace Projeto_NFe.Application.Features.Emitters.Commands
{
    public class EmitterRegisterCommand
    {
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

        class Validador : AbstractValidator<EmitterRegisterCommand>
        {
            public Validador()
            {
                RuleFor(x => x.FantasyName).NotNull().NotEmpty().WithMessage("O nome fantasia não pode ser nulo ou vazio!");

                RuleFor(x => x.CompanyName).NotNull().NotEmpty().WithMessage("A razão social não pode ser nula ou vazia!");

                RuleFor(x => x.Cnpj).NotNull().NotEmpty().WithMessage("O CNPJ não pode ser nulo ou em branco!").CpfCnpjValid().WithMessage("O CNPJ não pode ser invalido!");

                RuleFor(x => x.StateRegistration).NotNull().NotEmpty().WithMessage("A inscrição estadual não pode ser nula ou vazia!");

                RuleFor(x => x.MunicipalRegistration).NotNull().NotEmpty().WithMessage("A inscrição municipal não pode ser nula ou vazia!");
                
            }
        }
    }
}
