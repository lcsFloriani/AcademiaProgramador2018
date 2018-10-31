using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands
{
    public class ClienteDeletaCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validar()
        {
            return new Validador().Validate(this);
        }

        class Validador : AbstractValidator<ClienteDeletaCommand>
        {
            private long _menorQue = 0;

            public Validador()
            {
                RuleFor(x => x.Id).GreaterThan(_menorQue).WithMessage("O id do cliente não pode ser menor que zero!");
            }
        }
    }
}
