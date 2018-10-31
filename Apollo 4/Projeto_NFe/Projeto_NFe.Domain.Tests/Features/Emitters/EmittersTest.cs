using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Projeto_NFe.Domain.Features.Addresses;
using NUnit.Framework;
using Moq;
using Projeto_NFe.Infra.CNPJ;

namespace Projeto_NFe.Domain.Tests.Features.Emitters
{
    [TestFixture]
    public class EmittersTest
    {
        private Mock<Address> fakeAdress;
        private Mock<Cnpj> fakeCnpj;
        [SetUp]
        public void Initialize()
        {
            fakeAdress = new Mock<Address>();
            fakeCnpj = new Mock<Cnpj>();
            fakeAdress.Setup(x => x.Validate());
            fakeCnpj.Setup(x => x.Validate());
        }

        [Test]
        public void Emitters_Domain_Validate_ShouldValidateWithSuccess()
        {
            //Cenário
            Emitter emitter = ObjectMother.GetEmitter(fakeAdress.Object, fakeCnpj.Object);

            //Ação
            Action validate = () => emitter.Validate();

            //Saída
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Emitters_Domain_Validate_ShouldThrowFantasyNameNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidFantasyName(fakeAdress.Object, fakeCnpj.Object);

            //Ação
            Action validate = () => emitter.Validate();

            //Saída
            validate.Should().Throw<EmitterFantasyNameNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Domain_Validate_ShouldThrowCnpjNullException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidCnpj(fakeAdress.Object,null);

            //Ação
            Action validate = () => emitter.Validate();

            //Saída
            validate.Should().Throw<EmitterCnpjNullException>();
        }

        [Test]
        public void Emitters_Domain_Validate_ShouldThrowCompanyNameNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidCompanyName(fakeAdress.Object, fakeCnpj.Object);

            //Ação
            Action validate = () => emitter.Validate();

            //Saída
            validate.Should().Throw<EmitterCompanyNameNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Domain_Validate_InvalidMunicipalRegistration_ShouldThrowMunicipalRegistrationNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidMunicipalRegistration(fakeAdress.Object, fakeCnpj.Object);

            //Ação
            Action validate = () => emitter.Validate();

            //Saída
            validate.Should().Throw<EmitterMunicipalRegistrationNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Domain_Validate_InvalidStateRegistration_ShouldThrowStateRegistrationNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidStateRegistration(fakeAdress.Object, fakeCnpj.Object);

            //Ação
            Action validate = () => emitter.Validate();

            //Saída
            validate.Should().Throw<EmitterStateRegistrationNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Domain_Validate_InvalidAddress_ShouldThrowAddressNullException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidAddress(fakeCnpj.Object);

            //Ação
            Action validate = () => emitter.Validate();

            //Saída
            validate.Should().Throw<EmitterAddressNullException>();
        }

        [Test]
        public void Emitters_Domain_SetCnpj_ShouldSetCnpjWithSuccess()
        {
            //Cenario
            string cnpj = "23.744.495/0001-69";
            Emitter emitter = ObjectMother.GetEmitter(fakeAdress.Object, fakeCnpj.Object);

            //Ação
            Action action = () => emitter.SetCnpj(cnpj);

            //Sáida
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Emitters_Domain_SetCnpj_ShouldThrowValueLessThanFourteenException()
        {
            //Cenario
            string invalidCnpj = "00.000.000/0000";
            Emitter emitter = ObjectMother.GetEmitter(fakeAdress.Object, fakeCnpj.Object);

            //Ação
            Action action = () => emitter.SetCnpj(invalidCnpj);

            //Sáida
            action.Should().Throw<CnpjValueLessThanFourteenException>();
        }
    }
}