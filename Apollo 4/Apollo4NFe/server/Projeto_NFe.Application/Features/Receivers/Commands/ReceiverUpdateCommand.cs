using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Application.Features.Addresses;
using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Infra.Extension_Methods;

namespace Projeto_NFe.Application.Features.Receivers.Commands
{
	public class ReceiverUpdateCommand
	{
		public long Id { get; set; }
		public int Type { get; set; }
		public string NameCompanyName { get; set; }
		public string CpfCnpj { get; set; }
		public string StateRegistration { get; set; }
		public AddressCommand Address { get; set; }

		public virtual ValidationResult Validate()
		{
			return new Validator().Validate( this );
		}

		class Validator : AbstractValidator<ReceiverUpdateCommand>
		{
			public Validator()
			{
				RuleFor( r => r.Id ).NotNull().GreaterThan( 0 );
				RuleFor( r => r.NameCompanyName ).NotNull().NotEmpty();
				RuleFor( r => r.CpfCnpj ).NotNull().NotEmpty().CpfCnpjValid();
                RuleFor(r => r.StateRegistration).NotNull().NotEmpty().When(r => r.Type == (int)PersonType.LEGAL);
                RuleFor( r => r.Address.State ).NotNull().NotEmpty();
				RuleFor( r => r.Address.City ).NotNull().NotEmpty();
				RuleFor( r => r.Address.Neighbourhood ).NotNull().NotEmpty();
				RuleFor( r => r.Address.Street ).NotNull().NotEmpty();
				RuleFor( r => r.Address.Number ).NotNull().GreaterThan( 0 );
			}
		}
	}
}
