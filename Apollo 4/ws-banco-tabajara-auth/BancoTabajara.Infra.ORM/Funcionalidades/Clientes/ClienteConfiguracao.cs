using BancoTabajara.Dominio;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using System.Data.Entity.ModelConfiguration;

namespace BancoTabajara.Infra.ORM.Funcionalidades.Clientes
{
    public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            ToTable("TBCliente");

            Property(c => c.Id).HasColumnName("IdCliente");
            Property(c => c.Nome).HasColumnName("Nome").IsRequired();
            Property(c => c.CPF).HasColumnName("CPF").IsRequired();
            Property(c => c.RG).HasColumnName("RG").IsRequired();
            Property(c => c.DataNascimento).HasColumnName("DataNascimento").IsRequired();
        }
    }
}
