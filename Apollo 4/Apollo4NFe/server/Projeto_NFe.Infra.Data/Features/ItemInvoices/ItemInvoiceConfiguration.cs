using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.ItemInvoices;

namespace Projeto_NFe.Infra.ORM.Features.ItemInvoices
{
	public class ItemInvoiceConfiguration : EntityTypeConfiguration<ItemInvoice>
	{
		public ItemInvoiceConfiguration()
		{
            ToTable("TBItemInvoice");
            Property(i => i.Id).HasColumnName("IdItem");
            Property(i => i.Quantity).IsRequired();

            //HasRequired(o => o.Product)
            // .WithMany()
            // .HasForeignKey(o => o.ProductId);

            //HasRequired(o => o.InvoiceInProcess)
            //     .WithMany()
            //     .HasForeignKey(o => o.InvoiceInProcessId);
        }
    }
}
