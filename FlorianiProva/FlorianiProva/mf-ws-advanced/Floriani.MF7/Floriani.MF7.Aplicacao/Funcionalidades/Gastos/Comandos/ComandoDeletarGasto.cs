using FluentValidation;
using FluentValidation.Results;

namespace Floriani.MF7.Aplicacao.Funcionalidades.Gastos.Comandos
{
	public class ComandoDeletarGasto
	{
		public int Id { get; set; }

		public virtual ValidationResult Validate()
		{
			return new Validator().Validate( this );
		}

		class Validator : AbstractValidator<ComandoDeletarGasto>
		{
			public Validator()
			{
				RuleFor( c => c.Id )
					  .NotNull().NotEmpty().WithMessage( "O id não pode ser vazio" )
					  .GreaterThan( 0 ).WithMessage( "O id deve ser maior que 0" );
			}
		}
	}
}
