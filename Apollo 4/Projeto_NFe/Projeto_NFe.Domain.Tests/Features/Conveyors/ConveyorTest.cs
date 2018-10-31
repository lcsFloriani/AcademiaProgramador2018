using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using System;


namespace Projeto_NFe.Domain.Tests.Features.Conveyors
{
    [TestFixture]
    public class ConveyorTest
    {
        private Mock<Address> _fakeAddress;
        private Mock<Cpf> _fakeCpf;
        private Mock<Cnpj> _fakeCnpj;


        [SetUp]
        public void Initializer()
        {
            _fakeAddress = new Mock<Address>();
            _fakeCpf = new Mock<Cpf>();
            _fakeCnpj = new Mock<Cnpj>();

            _fakeAddress.Setup(x => x.Validate());
            _fakeCpf.Setup(x => x.Validate());
            _fakeCnpj.Setup(x => x.Validate());
        }

        [Test]
        public void Conveyors_Domain_PhysicalType_Validate_ShouldValidateWithSuccess()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetPhysicalConveyor(_fakeAddress.Object, _fakeCpf.Object);

            //Ação
            Action action = conveyor.Validate;

            //Sáida
            action.Should().NotThrow<Exception>();
            _fakeAddress.Verify(x => x.Validate());
            _fakeCpf.Verify(x => x.Validate());
        }

        [Test]
        public void Conveyors_Domain_SetCpf_ShouldSetCpfWithSuccess()
        {
            //Cenario
            string cpf = "822.919.010-01";
            Conveyor conveyor = ObjectMother.GetPhysicalConveyorWithoutCpf(_fakeAddress.Object);

            //Ação
            Action action = () => conveyor.SetCpf(cpf);

            //Sáida
            action.Should().NotThrow<Exception>();
            conveyor.Cpf.Should().NotBeNull();
            conveyor.Type.Should().Be(PersonType.PHYSICAL);
        }

        [Test]
        public void Conveyors_Domain_Validate_ShouldThrowFreightResponsibilityDefaultException()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetConveyor(_fakeAddress.Object);
            conveyor.FreightResponsibility = FreightResponsibility.DEFAULT;

            //Ação
            Action action = conveyor.Validate;
            
            //Sáida
            action.Should().Throw<ConveyorFreightResponsibilityDefaultException>();

        }


        [Test]
        public void Conveyors_Domain_Validate_ShouldThrowNameNullOrEmptyException()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetPhysicalConveyorWithNameNullOrEmpty(_fakeAddress.Object, _fakeCpf.Object);
            
            //Ação
            Action action = conveyor.Validate;
            
            //Sáida
            action.Should().Throw<ConveyorNameNullOrEmptyException>();
        }

        [Test]
        public void Conveyors_Domain_Validate_ShouldThrowAddressNullException()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetConveyorWithoutAddress();

            //Ação
            Action action = conveyor.Validate;

            //Sáida
            action.Should().Throw<ConveyorAddressNullException>();
            _fakeAddress.VerifyNoOtherCalls();
        }

        [Test]
        public void Conveyors_Domain_Validate_ShouldThrowCpfNullException()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetPhysicalConveyorWithoutCpf(_fakeAddress.Object);
            
            //Ação
            Action action = conveyor.Validate;

            //Sáida
            action.Should().Throw<ConveyorCpfNullException>();
            _fakeAddress.Verify(x => x.Validate());
        }

        [Test]
        public void Conveyors_Domain_SetCpf_ShouldThrowInvalidValueException()
        {
            //Cenario
            string invalidCpf = "12345678909";
            Conveyor conveyor = ObjectMother.GetPhysicalConveyorWithoutCpf(_fakeAddress.Object);

            //Ação
            Action action = () => conveyor.SetCpf(invalidCpf);

            //Sáida
            action.Should().Throw<CpfInvalidValueException>();
        }

        [Test]
        public void Conveyors_Domain_LegalType_Validate_ShouldValidateWithSuccess()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(_fakeAddress.Object, _fakeCnpj.Object);

            //Ação
            Action action = conveyor.Validate;

            //Sáida
            action.Should().NotThrow<Exception>();
            _fakeAddress.Verify(x => x.Validate());
        }

        [Test]
        public void Conveyors_Domain_SetCnpj_ShouldSetCnpjWithSuccess()
        {
            //Cenario
            string cnpj = "23.744.495/0001-69";
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithoutCnpj(_fakeAddress.Object);

            //Ação
            Action action = () => conveyor.SetCnpj(cnpj);

            //Sáida
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Conveyors_Domain_Validate_ShouldThrowCompanyNameNullOrEmptyException()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCompanyNameNullOrEmpty(_fakeAddress.Object, _fakeCnpj.Object);

            //Ação
            Action action = conveyor.Validate;

            //Sáida
            action.Should().Throw<ConveyorCompanyNameNullOrEmptyException>();
            _fakeAddress.Verify(x => x.Validate());
        }

        [Test]
        public void Conveyors_Domain_Validate_ShouldThrowTypeDefaultException()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetConveyor(_fakeAddress.Object);

            //Ação
            Action action = conveyor.Validate;

            //Sáida
            action.Should().Throw<ConveyorTypeDefaultException>();
            _fakeAddress.Verify(x => x.Validate());
        }

        [Test]
        public void Conveyors_Domain_Validate_ShouldThrowCnpjNullException()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithoutCnpj(_fakeAddress.Object);

            //Ação
            Action action = conveyor.Validate;
            
            //Sáida
            action.Should().Throw<ConveyorCnpjNullException>();
            _fakeAddress.Verify(x => x.Validate());
        }
    }
}
