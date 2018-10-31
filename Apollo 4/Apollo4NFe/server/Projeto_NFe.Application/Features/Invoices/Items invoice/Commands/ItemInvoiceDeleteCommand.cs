using FluentValidation;
using FluentValidation.Results;

namespace Projeto_NFe.Application.Features.Invoices.Items_invoice.Commands
{
    public class ItemInvoiceDeleteCommand
    {
        public virtual long InvoiceId { get; set; }
        public virtual long[] ItemsInvoiceId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validador().Validate(this);
        }

        class Validador : AbstractValidator<ItemInvoiceDeleteCommand>
        {
            private int _greaterThan = 0;

            public Validador()
            {
                RuleFor(c => c.ItemsInvoiceId).NotNull();
            }
        }
    }
}
