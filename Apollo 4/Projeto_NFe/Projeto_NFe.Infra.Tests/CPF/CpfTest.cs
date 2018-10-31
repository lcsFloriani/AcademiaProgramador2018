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
            Cpf cpf = ObjectMother.GetCpf();

            //Ação
            Action actionExecute = cpf.Validate;

            //Sáida
            actionExecute.Should().NotThrow<Exception>();
        }

        [Test]
        public void Cpf_Infra_FormattedValue_ShouldFormattedValueWithSuccess()
        {
            //Cenario
            Cpf cpf = ObjectMother.GetCpf();
            string cnpjEsperado = "329.999.590-10";

            //Ação
            string res = cpf.FormattedValue;

            //Sáida
            res.Should().Be(cnpjEsperado);
        }

        [Test]
        public void Cpf_Infra_Validate_ShouldThrowValueNullOrEmptyException()
        {
            //Cenario
            Cpf cpf = ObjectMother.GetCpfWithValueEmpty();

            //Ação
            Action actionExecute = cpf.Validate;

            //Sáida
            actionExecute.Should().Throw<CpfValueNullOrEmptyException>();
        }

        [Test]
        public void Cpf_Infra_Validate_ShouldThrowValueLessThanElevenException()
        {
            //Cenario
            Cpf cpf = ObjectMother.GetCpfLessThanEleven();

            //Ação
            Action actionExecute = cpf.Validate;

            //Sáida
            actionExecute.Should().Throw<CpfValueLessThanElevenException>();
        }

        [Test]
        public void Cpf_Infra_Validate_ShouldThrowValueOverFlowException()
        {
            //Cenario
            Cpf cpf = ObjectMother.GetCpfOverFlow();

            //Ação
            Action actionExecute = cpf.Validate;

            //Sáida
            actionExecute.Should().Throw<CpfValueOverFlowException>();
        }

        [Test]
        public void Cpf_Infra_Validate_ShouldThrowValueEqualToZeroException()
        {
            //Cenario
            Cpf cpf = ObjectMother.GetCpfEqualToZero();

            //Ação
            Action actionExecute = cpf.Validate;

            //Sáida
            actionExecute.Should().Throw<CpfValueEqualToZeroException>();
        }

        [Test]
        public void Cpf_Infra_Validate_ShouldThrowInvalidValueException()
        {
            //Cenario
            Cpf cpf = ObjectMother.GetCpfInvalidValue();

            //Ação
            Action actionExecute = cpf.Validate;

            //Sáida
            actionExecute.Should().Throw<CpfInvalidValueException>();
        }

        [Test]
        public void Cpf_Infra_Validate_ShouldThrowIncorrectValueException()
        {
            //Cenario
            Cpf cpf = ObjectMother.GetCpfIncorrectValue();

            //Ação
            Action actionExecute = cpf.Validate;

            //Sáida
            actionExecute.Should().Throw<CpfIncorrectValueException>();
        }
    }
}
