using NDDResearch.Application.Features.Addresses.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace NDDResearch.Application.Features.Sites.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessário) para atualizar um site.
    ///  
    /// </summary>
    public class SiteUpdateCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string NationalIdNumber { get; set; }
        public AddressUpdateCommand Address { get; set; }

        public ValidationResult Validate(int siteId)
        {
            return new Validator(siteId).Validate(this);
        }

        private class Validator : AbstractValidator<SiteUpdateCommand>
        {
            public Validator(int siteId)
            {
                RuleFor(s => s.Id).NotNull().NotEqual(0).Equal(siteId);
                RuleFor(s => s.Name).NotNull().NotEmpty().Length(1, 50);
                RuleFor(s => s.Address.Id).NotNull().NotEqual(0);
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
