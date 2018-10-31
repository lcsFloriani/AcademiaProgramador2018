using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios.Comandos
{
	public class ComandoDeletarFuncionario
	{
		public int Id { get; set; }

		public virtual ValidationResult Validate()
		{
			return new Validator().Validate( this );
		}

		class Validator : AbstractValidator<ComandoDeletarFuncionario>
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
