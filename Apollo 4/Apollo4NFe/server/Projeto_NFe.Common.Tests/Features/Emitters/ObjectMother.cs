using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Infra.CNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
	public partial class ObjectMother
	{
		public static Emitter GetEmitter(Address address)
		{
			return new Emitter() {
				FantasyName = "asd",
				CompanyName = "Jequiti",
				MunicipalRegistration = "2039102",
				StateRegistration = "3123123",
				Address = address,
				Cnpj = "74252150000129"
			};
		}
	}
}
