using FluentValidation;
using FluentValidation.Results;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Commands
{
    public class InvoiceProcessCommandUpdate
    {
        public long Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string NatureOperation { get; set; }
        public double ValueFreight { get; set; }

        public long ConveyorId { get; set; }
        public virtual Conveyor Conveyor { get; set; }
        public long EmitterId { get; set; }
        public virtual Emitter Emitter { get; set; }
        public long ReceiverId { get; set; }
        public virtual Receiver Receiver { get; set; }
        public List<ItemInvoice> Items { get; set; }
        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<InvoiceProcessCommandUpdate>
        {
            public Validator()
            {
                RuleFor(p => p.Id).NotNull().GreaterThan(0);
                
                RuleFor(p => p.EmitterId).GreaterThan(0).NotNull();
				RuleFor(p => p.ReceiverId).GreaterThan(0).NotNull();
				RuleFor(p => p.ConveyorId).GreaterThan(0).NotNull();
				RuleFor(p => p.ValueFreight).GreaterThan(0).NotNull();
                RuleFor(p => p.NatureOperation).NotEmpty().MaximumLength(50).MinimumLength(5);
                RuleFor(p => p.EntryDate).NotNull();
            }
        }
    }
}
