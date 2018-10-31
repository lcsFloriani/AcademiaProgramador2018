using Floriani.ORM.Dominio.Funcionalidades.Projetos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Projetos
{
    public class ProjetoConfiguracao : EntityTypeConfiguration<Projeto>
    {
        public ProjetoConfiguracao()
        {
            ToTable("TBProjetos");

            HasKey(p => p.Id);
            Property(d => d.Nome).HasColumnName("Nome").HasMaxLength(500).IsRequired();
            Property(d => d.DataInicio).HasColumnType("datetime").IsRequired();
        }
    }
}
