using Enedir.MF7.Domain.Features.Functionaries;
using System.Data.Entity.ModelConfiguration;
using System.Linq;


namespace Enedir.MF7.Infra.ORM.Features.Functionaries
{
    class FunctionaryConfiguration : EntityTypeConfiguration<Functionary>
    {
        public FunctionaryConfiguration()
        {
            ToTable("TBFunctionary");

            Property(f => f.Id).HasColumnName("IdFunctionary");
            Property(f => f.FirstName).HasColumnType("VARCHAR").HasMaxLength(30);
            Property(f => f.LastName).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(f => f.User).HasColumnType("VARCHAR").HasMaxLength(15);
            Property(f => f.Password).HasColumnType("VARCHAR").HasMaxLength(25);
            Property(f => f.Status).HasColumnType("BIT");
            Property(f => f.Office).HasColumnType("INT");
        }
    }
}
