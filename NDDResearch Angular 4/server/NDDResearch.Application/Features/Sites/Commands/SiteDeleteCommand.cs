using FluentValidation;
using FluentValidation.Results;

namespace NDDResearch.Application.Features.Sites.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessários) para remover um site da base de dados
    ///  
    /// </summary>
    public class SiteDeleteCommand
    {
        public int Id { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<SiteDeleteCommand>
        {
            public Validator()
            {
                RuleFor(m => m.Id).NotNull().NotEqual(0);
            }

        }
    }
}
