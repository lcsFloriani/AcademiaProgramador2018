//using System;
//using System.Collections.Generic;
//using System.Data.Entity.ModelConfiguration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Projeto_NFe.Domain.Features.Invoices;

//namespace Projeto_NFe.Infra.ORM.Features.Invoices
//{
//    public class InvoiceIssuedConfiguration : EntityTypeConfiguration<InvoiceIssued>
//    {
//        public InvoiceIssuedConfiguration()
//        {
//            ToTable("TBInvoiceIssued");
//            Property(e => e.Id).HasColumnName("IdInvoiceIssued");
//            Property(i => i.EntryDate).IsRequired();
//            Property(i => i.IssuanceDate).IsRequired();
//            Property(i => i.NatureOperation).IsRequired();
//            Property(i => i.ValueFreight).IsRequired();
//        }
//    }
//}
