using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Emitters;

namespace Projeto_NFe.Infra.ORM.Features.Emitters
{
    public class EmittersConfiguration : EntityTypeConfiguration<Emitter>
    {
        public EmittersConfiguration()
        {
            ToTable("TBEmitter");
            Property(e => e.Id).HasColumnName("IdEmitter");
            Property(e => e.Cnpj).IsRequired();
            Property(e => e.CompanyName).IsRequired();
            Property(e => e.FantasyName).IsRequired();
            Property(e => e.MunicipalRegistration).IsRequired();
            Property(e => e.StateRegistration).IsRequired();
            Property(e => e.Address.Street).IsRequired();
            Property(e => e.Address.Number).IsRequired();
            Property(e => e.Address.Neighbourhood).IsRequired();
            Property(e => e.Address.City).IsRequired();
            Property(e => e.Address.State).IsRequired();
        }
    }
}
