using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Sacar
{
    public class ContaSaqueCommand
    {
        public long Id { get; set; }
        public double ValorSaque { get; set; }

        public ValidationResult Validar()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ContaSaqueCommand>
        {
            public Validator()
            {
                RuleFor(x => x.Id).GreaterThan(0).WithMessage("O id da conta não pode ser menor que zero!");
            }
        }
    }
}
