using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Infra.CPF;
using System;

namespace Projeto_NFe.Infra.Tests.CPF
{
	[TestFixture]
	public class CpfTest
	{
		[Test]
		public void Cpf_Infra_Validate_ShouldValidateWithSuccess()
		{
			//Cenario
			string cpf = "52123495085";

			//Ação
			bool cpfValid = Cpf.ValidateCPF(cpf);

			//Sáida
			cpfValid.Should().BeTrue();
		}

		[Test]
		public void Cpf_Infra_Validate_ShouldFail()
		{
			//Cenario
			string cpf = "52123495000";

			//Ação
			bool cpfValid = Cpf.ValidateCPF( cpf );

			//Sáida
			cpfValid.Should().BeFalse();
		}
	}
}
