using Floriani.ORM.Dominio.Funcionalidades.Dependentes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Dependentes
{
    public class DependenteConfiguracao : EntityTypeConfiguration<Dependente>
    {
        public DependenteConfiguracao()
        {
            ToTable("TBDependentes");

            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("Id");


            Property(d => d.Nome).HasColumnName("Nome").HasMaxLength(500).IsRequired();
            Property(d => d.Idade).HasColumnName("Idade").IsRequired();
        }
    }
}
