using Enedir.MF7.Domain.Features.Outgoing;
using System.Data.Entity.ModelConfiguration;


namespace Enedir.MF7.Infra.ORM.Features.Outgoing
{
    class OutgoConfiguration : EntityTypeConfiguration<Outgo>
    {
        public OutgoConfiguration()
        {
            ToTable("TBOutgo");

            Property(o => o.Id).HasColumnName("IdOutgo");
            Property(o => o.Description).HasColumnType("VARCHAR").HasMaxLength(150);
            Property(o => o.Date).HasColumnType("DATETIME");
            Property(o => o.OutgoType).HasColumnType("INT");

            // one to many Gasto - Funcionario
            HasRequired(o => o.Functionary).WithMany().HasForeignKey(o => o.FunctionaryId);

        }
    }
}
