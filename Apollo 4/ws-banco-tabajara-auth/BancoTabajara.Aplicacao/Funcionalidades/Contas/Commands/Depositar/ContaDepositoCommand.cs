using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Depositar
{
    public class ContaDepositoCommand
    {
        public long Id { get; set; }
        public double ValorDeposito { get; set; }

        public ValidationResult Validar()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ContaDepositoCommand>
        {
            public Validator()
            {
                RuleFor(x => x.Id).GreaterThan(0).WithMessage("O id da conta não pode ser menor que zero!");
            }
        }
    }
}
