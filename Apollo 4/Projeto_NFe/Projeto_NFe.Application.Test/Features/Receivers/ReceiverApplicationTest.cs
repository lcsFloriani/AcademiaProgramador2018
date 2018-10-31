using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Receivers;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.CNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Test.Features.Receivers
{
    [TestFixture]
    public class ReceiverApplicationTest
    {
        private Mock<IReceiverRepository> _mockRepository;
        private IReceiverService _service;
        private Address _address;
        private Cnpj _cnpj;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IReceiverRepository>();
            _service = new ReceiverService(_mockRepository.Object);

            _address = ObjectMother.GetAddress();
            _cnpj = ObjectMother.GetCnpj();
        }

        [Test]
        public void Receivers_Service_Add_ShouldAddWithSuccess()
        {
            // Cenario
            Receiver receiver = ObjectMother.GetReceiverLegalWithCnpj(_address,_cnpj);
            _mockRepository.Setup(m => m.Save(receiver)).Returns(new Receiver { Id = 1 });

            int biggerThan = 0;

            // Executa
            Receiver receivered = _service.Add(receiver);

            // Saida
            receivered.Id.Should().BeGreaterThan(biggerThan);
            _mockRepository.Verify(m => m.Save(receiver));
        }

        [Test]
        public void Receivers_Service_Add_ShouldThrowNameNullOrEmptyException()
        {
            // Cenário
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithNameEmpty(_address);

            // Inválido
            _mockRepository.Setup(m => m.Save(receiver)).Returns(new Receiver { Id = 1 });

            // Executa
            Action executeAction = () => _service.Add(receiver);

            //Saída
            executeAction.Should().Throw<ReceiverNameNullOrEmptyException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Receivers_Service_Update_ShouldUpdateWithSuccess()
        {
            // Cenario
            Receiver receiver = ObjectMother.GetReceiverLegalWithCnpj(_address,_cnpj);
            receiver.Id = 1;

            _mockRepository.Setup(m => m.Update(receiver)).Returns(new Receiver { Id = 1 });

            int biggerThan = 0;

            // Executa
            Receiver receivered = _service.Update(receiver);

            // Saida
            _mockRepository.Verify(m => m.Update(receiver));
            receivered.Id.Should().BeGreaterThan(biggerThan);
        }

        [Test]
        public void Receivers_Service_Update_ShouldThrowReceiverCpfNullException()
        {
            // Cenário
            Receiver receiver = ObjectMother.GetReceiverPhysical(_address);
            receiver.Id = 1;

            // Executa
            Action executeAction = () => _service.Update(receiver);

            //Saída
            executeAction.Should().Throw<ReceiverCpfNullException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Receivers_Service_Update_ShouldThrowIdentifierUndefinedException()
        {
            // Cenário
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(_address);
            // Executa
            Action executeAction = () => _service.Update(receiver);

            //Saída
            executeAction.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Receivers_Service_Get_ShouldGetWithSuccess()
        {
            // Inválido
            int id = 10;
            _mockRepository.Setup(m => m.Get(id)).Returns(It.IsAny<Receiver>());

            // Executa
            Receiver receiver = _service.Get(id);

            // Saída
            _mockRepository.Verify(m => m.Get(id));
        }

        [Test]
        public void Receivers_Service_Get_ShouldThrowIdentifierUndefinedException()
        {
            // Inválido
            int id = -1;
            _mockRepository.Setup(m => m.Get(id)).Returns(new Receiver { Id = 1 });

            // Executa
            Action executeAction = () => _service.Get(id);

            //Saída
            executeAction.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Receivers_Service_GetAll_ShouldGettAllWithSuccess()
        {
            // Inválido
            _mockRepository
                .Setup(x => x.GetAll())
                .Returns(
                    new List<Receiver>()
                        {
                            new Receiver { Id = 1 },
                            new Receiver { Id = 2 },
                            new Receiver { Id = 3 }
                        });

            int size = 3;

            // Executa
            IEnumerable<Receiver> receivers = _service.GetAll();

            // Saída
            _mockRepository.Verify(m => m.GetAll());
            receivers.Count().Should().Equals(size);
        }

        [Test]
        public void Receivers_Service_Delete_ShouldDeleteWithSuccess()
        {
            // Inválido
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(_address);
            receiver.Id = 10;
            _mockRepository
                .Setup(m => m.Delete(receiver));

            // Executa
            _service.Delete(receiver);

            // Saída
            _mockRepository.Verify(m => m.Delete(receiver));
        }

        [Test]
        public void Receivers_Service_Delete_ShouldThrowProductWithDependencyException()
        {
            //Cenário
            Receiver receiver = ObjectMother.GetReceiver(_address);
            receiver.Id = 1;
            bool exist = true;

            _mockRepository.Setup(x => x.CheckDependency(receiver)).Returns(exist);

            //Ação
            Action action = () => _service.Delete(receiver);

            //Saída
            action.Should().Throw<ReceiverWithDependencyException>();
            _mockRepository.Verify(m => m.CheckDependency(receiver));
        }

        [Test]
        public void Receivers_Service_Delete_ShouldThrowIdentifierUndefinedException()
        {
            // Cenário
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(_address);

            // Inválido
            _mockRepository
                .Setup(m => m.Delete(receiver));

            // Executa
            Action executeAction = () => _service.Delete(receiver);

            //Saída
            executeAction.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
