using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using Projeto_NFe.Infra.Data.Features.Conveyors;
using System;
using System.Linq;

namespace Projeto_NFe.Infra.Data.Tests.Features.Conveyours
{
    [TestFixture]
    public class ConveyorSQLRepositoryTest
    {
        private IConveyorRepository _repository;

        [SetUp]
        public void Initialization()
        {
            _repository = new ConveyorSQLRepository();
        }

        [Test]
        public void Conveyors_InfraData_ConveyorPhysical_Save_ShouldSaveWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutConveyor();

            Address address = ObjectMother.GetAddress();
            Cpf cpf = ObjectMother.GetCpf();
            Conveyor conveyor = ObjectMother.GetPhysicalConveyor(address, cpf);

            int expectedId = 1;

            //Ação
            var result = _repository.Save(conveyor);

            //Saída
            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void Conveyors_InfraData_ConveyorPhysical_Save_ShouldThrowCpfNullException()
        {
            //Cenario
            Address address = ObjectMother.GetAddress();
            Conveyor conveyor = ObjectMother.GetPhysicalConveyorWithoutCpf(address);

            //Ação
            Action action = () => _repository.Save(conveyor);
            //Saída
            action.Should().Throw<ConveyorCpfNullException>();
        }

        [Test]
        public void Conveyors_InfraData_ConveyorLegal_Save_ShouldSaveWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutConveyor();

            Address address = ObjectMother.GetAddress();
            Cnpj cnpj = ObjectMother.GetCnpj();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(address, cnpj);

            int expectedId = 1;

            //Ação
            var result = _repository.Save(conveyor);

            //Saída
            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void Conveyors_InfraData_ConveyorLegal_Save_ShouldThrowCnpjNullException()
        {
            //Cenario
            Address address = ObjectMother.GetAddress();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithoutCnpj(address);

            //Ação
            Action action = () => _repository.Save(conveyor);

            //Saída
            action.Should().Throw<ConveyorCnpjNullException>();
        }

        [Test]
        public void Conveyors_InfraData_ConveyorPhysical_Get_ShouldGetWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithConveyor();

            long idSearch = 1;
            PersonType expectedType = PersonType.PHYSICAL;

            //Execução
            var result = _repository.Get(idSearch);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(idSearch);
            result.NameCompanyName.Should().NotBeEmpty();
            result.Cpf.Should().NotBeNull();
            result.Type.Should().Be(expectedType);
            result.Address.Should().NotBeNull();
        }

        [Test]
        public void Conveyors_InfraData_ConveyorLegal_Get_ShouldGetWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithConveyor();

            long idSearch = 2;
            PersonType expectedType = PersonType.LEGAL;

            //Execução
            var result = _repository.Get(idSearch);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(idSearch);
            result.NameCompanyName.Should().NotBeEmpty();
            result.Cnpj.Should().NotBeNull();
            result.Type.Should().Be(expectedType);
            result.Address.Should().NotBeNull();
        }

        [Test]
        public void Conveyors_InfraData_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long idSearch = 0;

            //Execução
            Action action = () => _repository.Get(idSearch);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }


        [Test]
        public void Conveyors_InfraData_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithConveyor();

            long idSearch = 1;
            string name = "Ana Paula";
            Conveyor conveyor = _repository.Get(idSearch);
            conveyor.NameCompanyName = name;

            //Ação
            _repository.Update(conveyor);

            //Saída
            var result = _repository.Get(idSearch);
            result.NameCompanyName.Should().Be(name);
        }

        [Test]
        public void Conveyors_InfraData_Update_ShouldThrowdentifierUndefinedException()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetConveyor(ObjectMother.GetAddress());

            //Ação
            Action action = () => _repository.Update(conveyor);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }


        [Test]
        public void Conveyors_InfraData_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithConveyor();

            int size = 2;

            //Execução
            var result = _repository.GetAll();

            //Saída
            result.Should().NotBeNull();
            result.Count().Should().Be(size);
        }

        [Test]
        public void Conveyors_InfraData_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithConveyor();

            long searchId = 1;
            Conveyor conveyor = _repository.Get(searchId);

            //Ação
            _repository.Delete(conveyor);

            //Saída
            var result = _repository.Get(searchId);
            result.Should().BeNull();
        }

        [Test]
        public void Conveyors_InfraData_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long idSearch = 0;
            Conveyor conveyor = ObjectMother.GetConveyorWithoutAddress();
            conveyor.Id = idSearch;

            //Ação
            Action action = () => _repository.Delete(conveyor);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Conveyors_InfraData_CheckDependency_ShouldCheckDependencyWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithConveyorWithDependency();

            long searchId = 1;
            Conveyor conveyor = _repository.Get(searchId);

            //Ação
            var result = _repository.CheckDependency(conveyor);

            //Saída
            result.Should().BeTrue(); //Tem dependência
        }
    }
}
