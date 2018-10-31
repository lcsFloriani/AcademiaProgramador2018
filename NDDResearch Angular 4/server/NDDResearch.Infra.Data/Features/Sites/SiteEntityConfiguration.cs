using NDDResearch.Domain.Features.Sites;
using System.Data.Entity.ModelConfiguration;

namespace NDDResearch.Infra.Data.Features.Sites
{
    /// <summary>
    /// Configuração do banco para a entidade Site
    /// </summary>
    public class SiteEntityConfiguration : EntityTypeConfiguration<Site>
    {
        public SiteEntityConfiguration()
        {
            this.HasKey(s => s.Id);
            this.HasRequired(s => s.Address).WithMany().HasForeignKey(s => s.AddressId).WillCascadeOnDelete(false);
            this.HasRequired(s => s.Customer).WithMany().HasForeignKey(s => s.CustomerId).WillCascadeOnDelete(true);
            this.Property(s => s.Name).HasMaxLength(50);
            this.Property(s => s.NationalIdNumber).HasMaxLength(50);
        }
    }
}
