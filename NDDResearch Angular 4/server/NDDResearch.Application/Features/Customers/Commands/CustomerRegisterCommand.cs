using FluentValidation;
using FluentValidation.Results;
using NDDResearch.Application.Features.Addresses.Commands;

namespace NDDResearch.Application.Features.Customers.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessário) para registrar um novo customer.
    ///  
    /// </summary>
    public class CustomerRegisterCommand
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string NationalIdNumber { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public AddressRegisterCommand Address { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<CustomerRegisterCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Name).NotNull().NotEmpty().Matches(@"^[a-zA-Z0-9\-_]{1,50}$");
                RuleFor(c => c.DisplayName).NotNull().NotEmpty();
                RuleFor(c => c.Phone).NotNull().NotEmpty();
                RuleFor(c => c.Address.Country).NotNull().NotEmpty().Length(1, 50);
                RuleFor(c => c.Address.City).NotNull().NotEmpty().Length(1, 50);
                RuleFor(c => c.Address.PostalCode).NotNull().NotEmpty().Length(1, 50);
                RuleFor(c => c.Address.State).NotNull().NotEmpty().Length(1, 50);
                RuleFor(c => c.Address.Street).NotNull().NotEmpty().Length(1, 100);
                RuleFor(c => c.Address.AdditionalInfo).Length(0, 200);
            }
        }
    }
}
