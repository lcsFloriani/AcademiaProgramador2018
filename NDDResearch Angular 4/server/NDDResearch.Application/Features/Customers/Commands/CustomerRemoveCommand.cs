using FluentValidation;
using FluentValidation.Results;

namespace NDDResearch.Application.Features.Customers.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessários) para remover um customer da base de dados
    ///  
    /// </summary>
    public class CustomerRemoveCommand
    {
        public int[] CustomerIds { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<CustomerRemoveCommand>
        {
            public Validator()
            {
                RuleFor(c => c.CustomerIds).NotNull().Must(c => c.Length > 0);
            }
        }
    }
}
