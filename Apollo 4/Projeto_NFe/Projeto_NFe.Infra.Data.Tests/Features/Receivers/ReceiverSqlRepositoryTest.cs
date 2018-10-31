using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Enums;
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

namespace Projeto_NFe.Infra.Data.Tests.Features.Receivers
{
    [TestFixture]
    public class ReceiverSQLRepositoryTest
    {
        private IReceiverRepository _repository;

        [SetUp]
        public void Initialization()
        {
            _repository = new ReceiverSQLRepository();
        }

        [Test]
        public void Receivers_InfraData_ReceiverPhysical_Save_ShouldSaveWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithOutReceiver();

            Address address = ObjectMother.GetAddress();
            Cpf cpf = ObjectMother.GetCpf();
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(address,cpf);
            
            int idExpected = 1;

            //Ação
            var result = _repository.Save(receiver);

            //Saída
            result.Id.Should().Be(idExpected);
        }

        [Test]
        public void Receivers_InfraData_ReceiverPhysical_Save_ShouldThrowCpfNullException()
        {
            //Cenario
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverPhysical(address);

            //Ação
            Action action = () => _repository.Save(receiver);

            //Saída
            action.Should().Throw<ReceiverCpfNullException>();
        }

        [Test]
        public void Receivers_InfraData_ReceiverLegal_Save_ShouldSaveWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithOutReceiver();

            Address address = ObjectMother.GetAddress();
            Cnpj cnpj = ObjectMother.GetCnpj();
            Receiver receiver = ObjectMother.GetReceiverLegalWithCnpj(address,cnpj);

            int idExpected = 1;

            //Ação
            var result = _repository.Save(receiver);

            //Saída
            result.Id.Should().Be(idExpected);
        }

        [Test]
        public void Receivers_InfraData_ReceiversLegal_Save_ShouldThrowCnpjNullException()
        {
            //Cenario
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(address);

            //Ação
            Action action = () => _repository.Save(receiver);

            //Saída
            action.Should().Throw<ReceiverCnpjNullException>();
        }

        [Test]
        public void Receivers_InfraData_ReceiverPhysical_Get_ShouldGetWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithReceivers();

            int id = 1;
            
            //Ação
            Receiver receiver = _repository.Get(id);

            //Saída
            receiver.Should().NotBeNull();
            receiver.Id.Should().Be(id);
            receiver.NameCompanyName.Should().NotBeEmpty();
            receiver.Cpf.Should().NotBeNull();
            receiver.Type.Should().Be(PersonType.PHYSICAL);
            receiver.Address.Should().NotBeNull();
        }

        [Test]
        public void Receivers_InfraData_ReceiverLegal_Get_ShouldGetWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithReceivers();

            int id = 2;

            //Ação
            Receiver receiver = _repository.Get(id);

            //Saída
            receiver.Should().NotBeNull();
            receiver.Id.Should().Be(id);
            receiver.NameCompanyName.Should().NotBeEmpty();
            receiver.Cnpj.Should().NotBeNull();
            receiver.Type.Should().Be(PersonType.LEGAL);
            receiver.Address.Should().NotBeNull();
        }
       
        [Test]
        public void Receivers_InfraData_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long id = 0;

            //Execução
            Action action = () => _repository.Get(id);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Receivers_InfraData_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithReceivers();

            long id = 1;
            string name = "Test";
            Receiver receiver = _repository.Get(id);
            receiver.NameCompanyName = name;

            //Execução
            _repository.Update(receiver);

            //Saída
            var result = _repository.Get(id);
            result.NameCompanyName.Should().Be(name);
        }

        [Test]
        public void Receivers_InfraData_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverLegalWithoutCnpj(address);

            //Execução
            Action action = () => _repository.Update(receiver);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Receivers_InfraData_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithReceivers();

            int amountItems = 2;

            //Execução
            var result = _repository.GetAll();

            //Saída
            result.Should().NotBeNull();
            result.Count().Should().Be(amountItems);
        }

        [Test]
        public void Receivers_InfraData_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithReceivers();

            int id = 1;
            Receiver receiver = _repository.Get(id);

            //Ação
            _repository.Delete(receiver);

            //Saída
            Receiver result = _repository.Get(id);
            result.Should().BeNull();
        }

        [Test]
        public void Receivers_InfraData_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            int id = 0;
            Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverWithoutAddress();
            receiver.Id = id;

            //Ação
            Action action = () =>_repository.Delete(receiver);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Receivers_InfraData_CheckDependency_ShouldCheckDependencyWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithReceiverWithDependency();

            long searchId = 1;
            Receiver receiver = _repository.Get(searchId);

            //Ação
            var result = _repository.CheckDependency(receiver);

            //Saída
            result.Should().BeTrue();//tem dependencias
        }
    }
}
