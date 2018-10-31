using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Projeto_NFe.Application.Features.Receivers.Commands
{
	[ExcludeFromCodeCoverage]
	public class ReceiverDeleteCommand
	{
		public virtual long[] ReceiverIds { get; set; }

		public virtual ValidationResult Validate()
		{
			return new Validator().Validate( this );
		}

		class Validator : AbstractValidator<ReceiverDeleteCommand>
		{
			public Validator()
			{
				RuleFor( c => c.ReceiverIds ).NotNull();
				RuleFor( c => c.ReceiverIds.Length ).GreaterThan( 0 );
			}
		}
	}
}

