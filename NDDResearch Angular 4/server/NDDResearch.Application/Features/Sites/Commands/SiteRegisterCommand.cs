using NDDResearch.Application.Features.Addresses.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace NDDResearch.Application.Features.Sites.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessário) para registrar um novo site.
    ///  
    /// </summary>
    public class SiteRegisterCommand
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string NationalIdNumber { get; set; }
        public int CustomerId { get; set; }
        public AddressRegisterCommand Address { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<SiteRegisterCommand>
        {
            public Validator()
            {
                RuleFor(s => s.CustomerId).NotNull().NotEqual(0);
                RuleFor(s => s.Name).NotNull().NotEmpty().Length(1, 50);
                RuleFor(s => s.Address.Country).NotNull().NotEmpty().Length(1, 50);
                RuleFor(s => s.Address.City).NotNull().NotEmpty().Length(1, 50);
                RuleFor(s => s.Address.PostalCode).NotNull().NotEmpty().Length(1, 50);
                RuleFor(s => s.Address.State).NotNull().NotEmpty().Length(1, 50);
                RuleFor(s => s.Address.Street).NotNull().NotEmpty().Length(1, 100);
                RuleFor(s => s.Address.AdditionalInfo).Length(0, 200);
            }
        }
    }
}
