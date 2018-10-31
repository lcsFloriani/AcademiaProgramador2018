using NDDResearch.Domain.Features.Customers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace NDDResearch.Infra.Data.Features.Customers
{
    /// <summary>
    /// Configuração do banco para a entidade Customer
    /// </summary>
    public class CustomerEntityConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerEntityConfiguration()
        {
            this.HasKey(c => c.Id);

            this.HasRequired(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressId)
                .WillCascadeOnDelete(true);

            this.Property(c => c.Name).HasMaxLength(50);
            this.Property(c => c.NationalIdNumber).HasMaxLength(50);
            this.Property(c => c.Phone).HasMaxLength(50);
            this.Property(c => c.WebSite).HasMaxLength(100);
            this.Property(c => c.CreationDate).IsRequired();
            this.Property(c => c.Key).IsRequired().HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName, 
                                                                                        new IndexAnnotation(new IndexAttribute()));
            this.HasMany(c => c.Sites).WithRequired(p => p.Customer);
        }
    }
}
