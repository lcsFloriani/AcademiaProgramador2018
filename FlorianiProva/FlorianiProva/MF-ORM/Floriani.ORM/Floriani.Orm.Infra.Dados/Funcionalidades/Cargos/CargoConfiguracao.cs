using Floriani.ORM.Dominio.Funcionalidades.Cargos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Cargos
{
    public class CargoConfiguracao : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguracao()
        {
            ToTable("TBCargos");

            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");

            Property(c => c.Descricao).HasColumnName("Cargo").HasMaxLength(200).IsRequired();
        }
    }
}
