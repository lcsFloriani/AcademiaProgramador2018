using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Invoices;

namespace Projeto_NFe.Infra.ORM.Features.Invoices
{
    public class InvoiceInProcessConfiguration : EntityTypeConfiguration<InvoiceInProcess>
    {
        public InvoiceInProcessConfiguration()
        {
            ToTable("TBInvoiceProcessing");
            Property(i => i.Id).HasColumnName("idInvoiceProcessing");
            Property(i => i.EntryDate).IsRequired();
            Property(i => i.NatureOperation).IsRequired();
            Property(i => i.ValueFreight).IsRequired();

            HasRequired(i => i.Conveyor).WithMany().HasForeignKey(i => i.ConveyorId);
            HasRequired(i => i.Emitter).WithMany().HasForeignKey(i => i.EmitterId);
            HasRequired(i => i.Receiver).WithMany().HasForeignKey(i => i.ReceiverId);
        }
    }
}
