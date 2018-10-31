using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.AlterarEstado
{
    public class ContaEstadoCommand
    {
        public long Id { get; set; }
        public bool EstadoConta { get; set; }

        public virtual ValidationResult Validar()
        {
            return new Validador().Validate(this);
        }

        class Validador : AbstractValidator<ContaEstadoCommand>
        {
            public Validador()
            {
                RuleFor(x => x.Id).GreaterThan(0).WithMessage("O id da conta não pode ser menor que zero!");
            }
        }
    }
}
