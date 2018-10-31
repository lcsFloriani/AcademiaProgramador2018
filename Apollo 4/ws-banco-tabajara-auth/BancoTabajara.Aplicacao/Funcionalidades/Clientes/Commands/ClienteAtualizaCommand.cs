using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands
{
    public class ClienteAtualizaCommand
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }

        public virtual ValidationResult Validar()
        {
            return new Validador().Validate(this);
        }

        class Validador : AbstractValidator<ClienteAtualizaCommand>
        {
            private long _menorQue = 0;
            public Validador()
            {
                RuleFor(x => x.Id).GreaterThan(_menorQue).WithMessage("O id do cliente não pode ser menor que zero!");
                RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O nome do cliente não pode ser nulo ou vazio!");
                RuleFor(x => x.CPF).NotNull().NotEmpty().WithMessage("O CPF do cliente não pode ser nulo ou vazio!");
                RuleFor(x => x.RG).NotNull().NotEmpty().WithMessage("O RG do cliente não pode ser nulo ou vazio!");
            }
        }
    }
}
