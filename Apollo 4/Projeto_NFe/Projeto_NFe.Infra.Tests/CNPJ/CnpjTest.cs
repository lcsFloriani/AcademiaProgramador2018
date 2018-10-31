using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Infra.CNPJ;
using System;

namespace Projeto_NFe.Infra.Tests.CNPJ
{
    [TestFixture]
    public class CnpjTest
    {
        [Test]
        public void Cnpj_Infra_Validate_ShouldValidateWithSuccess()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.GetCnpj();

            //Ação
            Action actionExecute = cnpj.Validate;

            //Sáida
            actionExecute.Should().NotThrow<Exception>();
        }

        [Test]
        public void Cnpj_Infra_Validate_ShouldThrowValueNullOrEmptyException()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.GetCnpjWithValueEmpty();

            //Ação
            Action actionExecute = cnpj.Validate;

            //Sáida
            actionExecute.Should().Throw<CnpjValueNullOrEmptyException>();
        }


        [Test]
        public void Cnpj_Infra_Validate_ShouldThrowInvalidValueException()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.GetCnpjInvalidValue();

            //Ação
            Action actionExecute = cnpj.Validate;

            //Sáida
            actionExecute.Should().Throw<CnpjInvalidValueException>();
        }

        [Test]
        public void Cnpj_Infra_Validate_ShouldThrowIncorrectValueException()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.GetCnpjIncorrectValue();

            //Ação
            Action actionExecute = cnpj.Validate;

            //Sáida
            actionExecute.Should().Throw<CnpjInvalidValueException>();
        }

        [Test]
        public void Cnpj_Infra_Validate_ShouldThrowValueLessThanFourteenException()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.GetCnpjLessThanFourTeen();

            //Ação
            Action actionExecute = cnpj.Validate;

            //Sáida
            actionExecute.Should().Throw<CnpjValueLessThanFourteenException>();
        }

        [Test]
        public void Cnpj_Infra_Validate_ShouldThrowValueEqualToZeroException()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.GetCnpjEqualToZero();

            //Ação
            Action actionExecute = cnpj.Validate;

            //Sáida
            actionExecute.Should().Throw<CnpjValueEqualToZeroException>();
        }

        [Test]
        public void Cnp_Infra_Validate_ShouldThrowValueOverFlowException()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.GetCnpjOverFlow();

            //Ação
            Action actionExecute = cnpj.Validate;

            //Sáida
            actionExecute.Should().Throw<CnpjValueOverFlowException>();
        }

        [Test]
        public void Cnpj_Infra_RemoveMask_ShouldRemoveMaskWithSuccess()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.GetCnpj();
            string cnpjExpected = "08671696000190";

            //Ação
            cnpj.Validate();

            //Sáida
            cnpj.Value.Should().Be(cnpjExpected);
        }

        [Test]
        public void Cnpj_Infra_FormattedValue_ShouldFormattedValueWithSuccess()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.GetCnpj();
            string cnpjExpected = "08.671.696/0001-90";

            //Ação
            string res = cnpj.FormattedValue;

            //Sáida
            res.Should().Be(cnpjExpected);
        }
    }
}
