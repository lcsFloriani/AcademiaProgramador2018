using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.Data.Features.Receivers;
using Projeto_NFe.Infra.ORM.Tests.Inicialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Tests.Features.Receivers
{
    [TestFixture]
    public class ReceiverRepositoryTest : EffortBaseTest
	{
        private IReceiverRepository _repository;

        [SetUp]
        public void Initialization()
        {
            _repository = new ReceiverRepository(this.context);
        }

        [Test]
        public void Receivers_InfraData_ReceiverPhysical_Save_ShouldSaveWithSuccess()
        {
            //Cenario
            Receiver receiver = ObjectMother.GetReceiverPhysical( ObjectMother.GetAddress() );
            
            int idExpected = 3;

            //Ação
            var result = _repository.Save(receiver);

            //Saída
            result.Id.Should().Be(idExpected);
        }

      
        [Test]
        public void Receivers_InfraData_ReceiverLegal_Save_ShouldSaveWithSuccess()
        {
			//Cenario
			Address address = ObjectMother.GetAddress();
            Receiver receiver = ObjectMother.GetReceiverLegal(address);

            int idExpected = 3;

            //Ação
            var result = _repository.Save(receiver);

            //Saída
            result.Id.Should().Be(idExpected);
        }

        [Test]
        public void Receivers_InfraData_ReceiverPhysical_Get_ShouldGetWithSuccess()
        {
         
            int id = 1;
            
            //Ação
            Receiver receiver = _repository.Get(id);

            //Saída
            receiver.Should().NotBeNull();
            receiver.Id.Should().Be(id);
            receiver.NameCompanyName.Should().NotBeEmpty();
            receiver.CpfCnpj.Should().NotBeEmpty();
            receiver.Type.Should().Be(PersonType.LEGAL);
            receiver.Address.Should().NotBeNull();
        }

        [Test]
        public void Receivers_InfraData_ReceiverLegal_Get_ShouldGetWithSuccess()
        {
            int id = 2;

            //Ação
            Receiver receiver = _repository.Get(id);

            //Saída
            receiver.Should().NotBeNull();
            receiver.Id.Should().Be(id);
            receiver.NameCompanyName.Should().NotBeEmpty();
            receiver.CpfCnpj.Should().NotBeEmpty();
            receiver.Type.Should().Be(PersonType.PHYSICAL);
            receiver.Address.Should().NotBeNull();
        }
       
        
        [Test]
        public void Receivers_InfraData_Update_ShouldUpdateWithSuccess()
        {
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
        public void Receivers_InfraData_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
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
            int id = 2;

            //Ação
            _repository.Delete(id);

            //Saída
            Receiver result = _repository.Get(id);
			result.Should().BeNull();
        }


		[Test]
		public void Receivers_InfraData_Delete_ShouldThrowNotFoundException()
		{
			//Cenario
			int id = 1000;

			//Ação
			Action action = () => _repository.Delete(id);

			//Saída
			action.Should().Throw<NotFoundException>();
		}

		[Test]
        public void Receivers_InfraData_CheckDependency_ShouldCheckDependencyWithSuccess()
        {
            //Cenario
            long searchId = 1;
            Receiver receiver = _repository.Get(searchId);

            //Ação
            var result = _repository.CheckDependency(receiver);

            //Saída
            result.Should().BeTrue();
        }
    }
}
