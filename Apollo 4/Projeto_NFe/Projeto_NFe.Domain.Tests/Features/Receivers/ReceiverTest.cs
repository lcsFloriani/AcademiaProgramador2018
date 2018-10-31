using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Receivers
{
    [TestFixture]
    public class ReceiverTest
    {
        private Mock<Address> _mockAddress;

        [SetUp]
        public void Initialize()
        {
            _mockAddress = new Mock<Address>();
            _mockAddress.Setup(x => x.Validate());
        }

        [Test]
        public void Receivers_Domain_PhysicalType_Validate_ShouldValidateWithSuccess()
        {
            //Cenário
            string cpf = "822.919.010-01";
            Receiver r = ObjectMother.GetReceiverPhysical(_mockAddress.Object);
            r.SetCpf(cpf);

            //Executa
            Action executeAction = r.Validate;

            //Saída
            executeAction.Should().NotThrow<Exception>();
        }

        [Test]
        public void Receivers_Domain_LegalType_Validate_ShouldValidateWithSuccess()
        {
            //Cenário
            string cnpj = "23.744.495/0001-69";
            Receiver r = ObjectMother.GetReceiverLegalWithoutCnpj(_mockAddress.Object);
            r.SetCnpj(cnpj);

            //Executa
            Action executeAction = r.Validate;

            //Saída
            executeAction.Should().NotThrow<Exception>();
        }

        [Test]
        public void Receivers_Domain_Validate_ShouldThrowTypeDefaultException()
        {
            //Cenario
            Receiver receiver = ObjectMother.GetReceiver(ObjectMother.GetAddress());

            //Ação
            Action action = receiver.Validate;

            //Sáida
            action.Should().Throw<ReceiverTypeDefaultException>();
        }

        [Test]
        public void Receivers_Domain_Validate_ShouldStateRegistrationNullOrEmptyException()
        {
            //Cenário
            Receiver r = ObjectMother.GetReceiverWithStateRegistrationEmpty(_mockAddress.Object);

            //Executa
            Action execteAction = r.Validate;

            //Saída
            execteAction.Should().Throw<ReceiverStateRegistrationNullOrEmptyException>();
        }

        [Test]
        public void Receivers_Domain_Validate_ShouldThrowAddressNullException()
        {
            //Cenário
            Receiver r = ObjectMother.GetReceiverWithoutAddress();

            //Executa
            Action execteAction = r.Validate;

            //Saída
            execteAction.Should().Throw<ReceiverAddressNullException>();
        }

        [Test]
        public void Receivers_Domain_Validate_ShouldThrowNameNullOrEmptyException()
        {
            //Cenário
            Receiver r = ObjectMother.GetReceiverPhysicalWithNameEmpty(_mockAddress.Object);

            //Executa
            Action execteAction = r.Validate;

            //Saída
            execteAction.Should().Throw<ReceiverNameNullOrEmptyException>();
        }

        [Test]
        public void Receivers_Domain_Validate_ShouldThrowCompanyNameNullOrEmptyException()
        {
            //Cenário
            Receiver r = ObjectMother.GetReceiverLegalWithCompanyNameEmpty(_mockAddress.Object);

            //Executa
            Action execteAction = r.Validate;

            //Saída
            execteAction.Should().Throw<ReceiverNameNullOrEmptyException>();
        }

        [Test]
        public void Receivers_Domain_SetCnpj_ShouldSetCnpjWithSuccess()
        {
            //Cenario
            string cnpj = "23.744.495/0001-69";
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(ObjectMother.GetAddress());

            //Ação
            Action action = () => receiver.SetCnpj(cnpj);
            
            //Sáida
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Receivers_Domain_SetCnpj_ShouldThrowValueLessThanFourteenException()
        {
            //Cenario
            string invalidCnpj = "00.000.000/0000";
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(ObjectMother.GetAddress());
            
            //Ação
            Action action = () => receiver.SetCnpj(invalidCnpj);
            
            //Sáida
            action.Should().Throw<CnpjValueLessThanFourteenException>();
        }

        [Test]
        public void Receivers_Domain_Validate_ShouldCnpjNullException()
        {
            //Cenario
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(ObjectMother.GetAddress());

            //Ação
            Action action = receiver.Validate;

            //Sáida
            action.Should().Throw<ReceiverCnpjNullException>();
        }

        [Test]
        public void Receivers_Domain_SetCpf_ShouldSetCpfWithSuccess()
        {
            //Cenario
            string cpf = "822.919.010-01";
            Receiver receiver = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());

            //Ação
            Action action = () => receiver.SetCpf(cpf);
            
            //Sáida
            action.Should().NotThrow<Exception>();
            receiver.Cpf.Should().NotBeNull();
            receiver.Type.Should().Be(PersonType.PHYSICAL);
        }

        [Test]
        public void Receivers_Domain_SetCpf_ShouldThrowInvalidValueException()
        {
            //Cenario
            string invalidCpf = "12345678909";
            Receiver receiver = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());
            
            //Ação
            Action action = () => receiver.SetCpf(invalidCpf);
            
            //Sáida
            action.Should().Throw<CpfInvalidValueException>();
        }

        [Test]
        public void Receivers_Domain_Validate_ShouldThrowCpfNullException()
        {
            //Cenario
            Receiver receiver = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());

            //Ação
            Action action = receiver.Validate;

            //Sáida
            action.Should().Throw<ReceiverCpfNullException>();
        }
    }
}
