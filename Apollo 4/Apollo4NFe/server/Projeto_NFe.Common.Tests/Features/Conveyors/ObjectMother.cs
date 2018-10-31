using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
	public partial class ObjectMother
	{

		public static Conveyor GetPhysicalConveyor(Address address)
		{
			return new Conveyor {
				NameCompanyName = "José da Silva",
				Address = address,
                PersonType = PersonType.PHYSICAL,
				FreightResponsibility = FreightResponsibility.EMITTER,
				CpfCnpj = "94570617999",
			};
		}

		public static Conveyor GetLegalConveyor(Address address)
		{
			return new Conveyor {
				NameCompanyName = "NDD",
                PersonType = PersonType.LEGAL,
				CpfCnpj = "20396756000109",
				Address = address,
				FreightResponsibility = FreightResponsibility.RECEIVER
			};
		}
	}
}
