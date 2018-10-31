using BancoTabajara.Dominio.Funcionalidades.Contas;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Infra.ORM.Funcionalidades.Contas
{
    public class ContaConfiguracao : EntityTypeConfiguration<Conta>
    {
        public ContaConfiguracao()
        {
            ToTable("TBConta");

            Property(c => c.Id).HasColumnName("IdConta");
            Property(c => c.NumeroConta).HasColumnType("INT").IsRequired();
            Property(c => c.Saldo).HasColumnType("FLOAT");
            Property(c => c.Estado).HasColumnType("BIT");
            Property(c => c.Limite).HasColumnType("FLOAT");

            //Cliente
             HasRequired(c => c.Cliente).WithMany().HasForeignKey(c => c.ClienteId).WillCascadeOnDelete(true);
        }
    }
}
