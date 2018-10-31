using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Receivers;

namespace Projeto_NFe.Infra.ORM.Features.Receivers
{
	public class ReceiverConfiguration : EntityTypeConfiguration<Receiver>
	{
		public ReceiverConfiguration()
		{
			ToTable( "TBReceiver" );
			Property( r => r.Id ).HasColumnName( "IdReceiver" );
			Property( r => r.Type ).IsRequired();
			Property( r => r.StateRegistration ).IsOptional();
			Property( r => r.NameCompanyName ).IsRequired();
			Property( r => r.Address.Street ).IsRequired();
			Property( r => r.Address.Number ).IsRequired();
			Property( r => r.Address.Neighbourhood ).IsRequired();
			Property( r => r.Address.City ).IsRequired();
			Property( r => r.Address.State ).IsRequired();
		}
	}
}
