using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Registrar
{
    public class ContaRegistroCommand
    {
        public int NumeroConta { get; set; }
        public double Saldo { get; set; }
        public bool Estado { get; set; }
        public double Limite { get; set; }
        public long ClienteId { get; set; }

        public virtual ValidationResult Validar()
        {
           return new Validador().Validate(this);
        }

        class Validador : AbstractValidator<ContaRegistroCommand>
        {
            public Validador()
            {
                RuleFor(x => x.NumeroConta).GreaterThan(0).WithMessage("O número da conta não pode ser negativo!");
                RuleFor(x => x.ClienteId).GreaterThan(0).WithMessage("O id do cliente não pode ser inválido!");
            }
        }
    }
}
