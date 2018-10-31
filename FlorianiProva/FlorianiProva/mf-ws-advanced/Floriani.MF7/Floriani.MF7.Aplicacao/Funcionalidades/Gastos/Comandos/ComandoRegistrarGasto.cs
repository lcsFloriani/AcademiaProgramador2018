using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;
using Floriani.MF7.Dominio.Funcionalidades.Gastos;
using FluentValidation;
using FluentValidation.Results;

namespace Floriani.MF7.Aplicacao.Funcionalidades.Gastos.Comandos
{
	public class ComandoRegistrarGasto
	{
		public string Descricao { get; set; }
		public DateTime Data { get; set; }
		public double Preco { get; set; }
		public TipoEnum Tipo { get; set; }
		public int FuncionarioId { get; set; }
		public virtual ValidationResult Validate()
		{
			return new Validator().Validate( this );
		}
		class Validator : AbstractValidator<ComandoRegistrarGasto>
		{
			public Validator()
			{
				RuleFor( f => f.Descricao )
					.NotNull().NotEmpty().WithMessage( "A descricao não pode ser vazio" )
					.MaximumLength( 100 ).WithMessage( "A descricao deve ter no maximo 100 caracteres" );

				RuleFor( f => f.Preco )
					.GreaterThan( 0 ).WithMessage( "O preco deve ser maior que 0" );

				RuleFor( f => f.FuncionarioId )
					.GreaterThan(0).WithMessage( "FuncionarioId deve ser maior que 0" );
			}
		}
	}
}
