using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Receivers;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using Projeto_NFe.Infra.Data.Features.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Features.Receivers
{
    [TestFixture]
    public class ReceiverSQLIntegrationTest
    {
        private IReceiverRepository _receiverRepository;
        private IReceiverService _service;

        [SetUp]
        public void Initialize()
        {
            _receiverRepository = new ReceiverSQLRepository();
            _service = new ReceiverService(_receiverRepository);
        }

        [Test]
        public void Receivers_Integration_TypePhysical_Add_ShouldAddWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithOutReceiver();

            Address address = ObjectMother.GetAddress();
            Cpf cpf = ObjectMother.GetCpf();
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(address, cpf);
       
            int expectedId = 1;

            //Ação
            Receiver result = _service.Add(receiver);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void Receivers_Integration_TypeLegal_Add_ShouldAddWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithOutReceiver();

            Address address = ObjectMother.GetAddress();
            Cnpj cnpj = ObjectMother.GetCnpj();
            Receiver receiver = ObjectMother.GetReceiverLegalWithCnpj(address, cnpj);

            int expectedId = 1;

            //Ação
            Receiver result = _service.Add(receiver);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void Receivers_Integration_Add_ShouldThrowStateRegistrationNullOrEmptyException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverWithStateRegistrationEmpty(address);

            //Ação
            Action action = () => _service.Add(receiver);

            //Saída
            action.Should().Throw<ReceiverStateRegistrationNullOrEmptyException>();
        }

        [Test]
        public void Receivers_Integration_ReceiverPhysical_Add_ShouldThrowNameNullOrEmptyException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithNameEmpty(address);

            //Ação
            Action action = () => _service.Add(receiver);

            //Saída
            action.Should().Throw<ReceiverNameNullOrEmptyException>();
        }

        [Test]
        public void Receivers_Integration_ReceiverLegal_Add_ShouldThrowNameNullOrEmptyException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverLegalWithCompanyNameEmpty(address);

            //Ação
            Action action = () => _service.Add(receiver);

            //Saída
            action.Should().Throw<ReceiverNameNullOrEmptyException>();
        }

        [Test]
        public void Receivers_Integration_Add_ShouldThrowAddressNullException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverWithoutAddress();

            //Ação
            Action action = () => _service.Add(receiver);

            //Saída
            action.Should().Throw<ReceiverAddressNullException>();
        }

        [Test]
        public void Receivers_Integration_Add_ShouldThrowCnpjNullException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(address);

            //Ação
            Action action = () => _service.Add(receiver);

            //Saída
            action.Should().Throw<ReceiverCnpjNullException>();
        }

        [Test]
        public void Receivers_Integration_Add_ShouldThrowCpfNullException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverPhysical(address);

            //Ação
            Action action = () => _service.Add(receiver);

            //Saída
            action.Should().Throw<ReceiverCpfNullException>();
        }

        [Test]
        public void Receivers_Integration_Add_ShouldThrowTypeDefaultException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiver(address);

            //Ação
            Action action = () => _service.Add(receiver);

            //Saída
            action.Should().Throw<ReceiverTypeDefaultException>();
        }

        [Test]
        public void Receivers_Integration_Update_ShouldUpdateWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithReceivers();

            int id = 1;
            string newName = "Teste";
            Receiver receiver = _service.Get(id);
            receiver.NameCompanyName = newName;

            //Ação
            Receiver result = _service.Update(receiver);

            //Saída
            result.Should().NotBeNull();
            Receiver search = _service.Get(id);
            search.NameCompanyName.Should().Be(newName);
        }

        [Test]
        public void Receivers_Integration_Update_ShouldThrowStateRegistrationNullOrEmptyException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverWithStateRegistrationEmpty(address);
            receiver.Id = 1;

            //Ação
            Action action = () => _service.Update(receiver);

            //Saída
            action.Should().Throw<ReceiverStateRegistrationNullOrEmptyException>();
        }

        [Test]
        public void Receivers_Integration_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(address);

            //Ação
            Action action = () => _service.Update(receiver);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Receivers_Integration_Get_ShouldGetWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithReceivers();

            int idExpected = 1;

            //Ação
            Receiver result = _service.Get(idExpected);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(idExpected);
        }

        [Test]
        public void Receivers_Integration_Get_ShouldBeFail()
        {
            //Cenário
            int idExpected = 10;

            //Ação
            Receiver result = _service.Get(idExpected);

            //Saída
            result.Should().BeNull();
        }

        [Test]
        public void Receivers_Integration_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            int idExpected = 0;

            //Ação
            Action action = () => _service.Get(idExpected);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Receivers_Integration_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithReceivers();

            int biggerThan = 0;
            int size = 2;
            long id = 1;

            //Ação
            List<Receiver> result = _service.GetAll() as List<Receiver>;

            //Saída
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(biggerThan);
            result.Count.Should().Be(size);
            result.First().Id.Should().Be(id);
        }

        [Test]
        public void Receivers_Integration_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithReceivers();

            int id = 1;
            Receiver receiver = _service.Get(id);

            //Ação
            _service.Delete(receiver);

            //Saída
            Receiver search = _service.Get(id);
            search.Should().BeNull();
        }

        [Test]
        public void Receivers_Integration_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiver(address);

            //Ação
            Action action = () => _service.Delete(receiver);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
