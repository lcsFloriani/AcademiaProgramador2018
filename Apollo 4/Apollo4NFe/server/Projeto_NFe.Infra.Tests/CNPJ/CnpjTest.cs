using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Infra.CNPJ;

namespace Projeto_NFe.Infra.Tests.CNPJ
{
	[TestFixture]
	public class CnpjTest
	{
		[Test]
		public void Cnpj_Infra_Validate_ShouldValidateWithSuccess()
		{
			//Cenario
			string cnpj = "43927867000108";

			//Ação
			bool cnpjValid = Cnpj.ValidateCNPJ( cnpj );

			//Sáida
			cnpjValid.Should().BeTrue();
		}

		[Test]
		public void Cnpj_Infra_Validate_ShoulFail()
		{
			//Cenario
			string cnpj = "11127867000108";

			//Ação
			bool cnpjValid = Cnpj.ValidateCNPJ( cnpj );

			//Sáida
			cnpjValid.Should().BeFalse();
		}

	}
}
