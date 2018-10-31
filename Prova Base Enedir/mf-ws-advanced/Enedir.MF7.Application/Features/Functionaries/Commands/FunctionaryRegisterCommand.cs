using Enedir.MF7.Domain.Features.Functionaries;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Application.Features.Functionaries.Commands
{
    public class FunctionaryRegisterCommand
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string User { set; get; }
        public string Password { set; get; }
        public bool Status { set; get; }
        public OfficeEnum Office { set; get; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<FunctionaryRegisterCommand>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("O primeiro nome não pode ser nulo ou vazio!");
                RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("O sobrenome não pode ser nulo ou vazio!");
                RuleFor(x => x.User).NotNull().NotEmpty().WithMessage("O nome de usuário não pode ser nulo ou vazio!");
                RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("A senha do funcionario não pode ser nulo ou vazio!");
                RuleFor(x => x.Status).NotNull().WithMessage("O status não pode ser nulo!");
                RuleFor(x => x.Office).NotNull().NotEmpty().WithMessage("O cargo não pode ser nulo ou vazio!");
            }
        }
    }
}
