using Floriani.ORM.Dominio.Funcionalidades.Departamentos;
using System.Data.Entity.ModelConfiguration;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Departamentos
{
    public class DepartamentoConfiguracao : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguracao()
        {
            ToTable("TBDepartamentos");

            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("Id");

            Property(d => d.Descricao).HasColumnName("Departamento").HasMaxLength(200).IsRequired();
        }
    }
}
