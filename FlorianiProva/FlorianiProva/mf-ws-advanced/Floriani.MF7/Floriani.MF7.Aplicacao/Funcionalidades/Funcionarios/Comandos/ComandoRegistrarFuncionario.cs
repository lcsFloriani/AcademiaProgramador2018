using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;

using FluentValidation;
using FluentValidation.Results;

namespace Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios.Comandos
{
	public class ComandoRegistrarFuncionario
	{
		public string PrimeiroNome { get; set; }
		public string Sobrenome { get; set; }
		public string Usuario { get; set; }
		public string Senha { get; set; }
		public CargoEnum Cargo { get; set; }
		public bool Status { get; set; }
		public virtual ValidationResult Validate()
		{
			return new Validator().Validate( this );
		}
		class Validator : AbstractValidator<ComandoRegistrarFuncionario>
		{
			public Validator()
			{
				RuleFor( f => f.PrimeiroNome )
					.NotNull().NotEmpty().WithMessage("O primeiro nome não pode ser vazio")
					.MaximumLength( 100 ).WithMessage("O Nome deve ter no maximo 100 caracteres");
					
				RuleFor(f=> f.Sobrenome)
					.NotNull().NotEmpty().WithMessage("O sobrenome não pode ser vazio")
					.MaximumLength( 100 ).WithMessage("O sobrenome deve ter no maximo 100 caracteres");

				RuleFor(f=> f.Usuario)
					.NotNull().NotEmpty().WithMessage("O usuario não pode ser vazio" )
					.MaximumLength( 100 ).WithMessage("O usuario deve ter no maximo 100 caracteres");

				RuleFor(f=> f.Senha)
					.NotNull().NotEmpty().WithMessage("A senha não pode ser em vazio" )
					.MaximumLength( 100 ).WithMessage("A senha deve ter no maximo 100 caracteres");
			}
		}
	}
}
