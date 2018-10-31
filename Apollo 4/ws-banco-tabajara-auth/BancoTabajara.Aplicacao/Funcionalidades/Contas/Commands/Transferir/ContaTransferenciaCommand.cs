using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Transferir
{
    public class ContaTransferenciaCommand
    {
        public long IdContaOrigem { get; set; }
        public long IdContaDestino { get; set; }
        public double ValorTransferencia { get; set; }

        public ValidationResult Validar()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ContaTransferenciaCommand>
        {
            public Validator()
            {
                RuleFor(x => x.IdContaOrigem).GreaterThan(0).WithMessage("O id da conta de origem não pode ser menor que zero!");
                RuleFor(x => x.IdContaDestino).GreaterThan(0).WithMessage("O id da conta de destino não pode ser menor que zero!");
            }
        }
    }
}
