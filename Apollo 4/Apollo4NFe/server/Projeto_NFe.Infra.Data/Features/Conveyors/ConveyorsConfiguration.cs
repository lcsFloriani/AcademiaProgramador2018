using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Conveyors;

namespace Projeto_NFe.Infra.ORM.Features.Conveyors
{
    public class ConveyorsConfiguration : EntityTypeConfiguration<Conveyor>
    {
        public ConveyorsConfiguration()
        {
            ToTable("TBConveyor");
            Property(c => c.Id).HasColumnName("IdConveyor");
            Property(c => c.FreightResponsibility).IsRequired();
            Property(c => c.PersonType).IsRequired();
            Property(c => c.CpfCnpj).IsRequired();
            Property(c => c.NameCompanyName).IsRequired();
            Property(c => c.Address.Street).IsRequired();
            Property(c => c.Address.Number).IsRequired();
            Property(c => c.Address.Neighbourhood).IsRequired();
            Property(c => c.Address.City).IsRequired();
            Property(c => c.Address.State).IsRequired();
        }
    }
}
