using Floriani.ORM.Dominio.Funcionalidades.Funcionarios;
using System.Data.Entity.ModelConfiguration;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Funcionarios
{
    public class FuncionarioConfiguracao : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguracao()
        {
            ToTable("TBFuncionarios");

            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("Id");

            Property(d => d.Nome).HasColumnName("Nome").HasMaxLength(500).IsRequired();
           
        }
    }
}
