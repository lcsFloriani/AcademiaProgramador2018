using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Atualizar
{
    public class ContaAtualizaCommand
    {
        public long Id { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; set; }
        public bool Estado { get; set; }
        public double Limite { get; set; }
        public long ClienteId { get; set; }
        
        public ValidationResult Validar()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ContaAtualizaCommand>
        {
            public Validator()
            {
                RuleFor(x => x.Id).GreaterThan(0).WithMessage("O id da conta não pode ser menor que zero!");
                RuleFor(x => x.ClienteId).GreaterThan(0).WithMessage("O id do cliente não pode ser menor que zero!");
                RuleFor(x => x.NumeroConta).GreaterThan(0).WithMessage("O número da conta não pode ser negativo!");
            }
        }
    }
}
