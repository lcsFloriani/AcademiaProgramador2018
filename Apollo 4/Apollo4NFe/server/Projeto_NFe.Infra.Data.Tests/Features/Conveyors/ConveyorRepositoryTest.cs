using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Infra.Data.Features.Conveyors;
using Projeto_NFe.Infra.ORM.Tests.Inicialize;
using System;
using System.Linq;

namespace Projeto_NFe.Infra.ORM.Tests.Features.Conveyours
{
    [TestFixture]
    public class ConveyorRepositoryTest : EffortBaseTest
    {
        private IConveyorRepository _repository;

        [SetUp]
        public void Initialization()
        {
            _repository = new ConveyorsRepository(this.context);
        }

        [Test]
        public void Conveyors_InfraORM_ConveyorPhysical_Save_ShouldSaveWithSuccess()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
            int expectedId = 3;

            //Ação
            var result = _repository.Save(conveyor);

            //Saída
            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void Conveyors_InfraORM_ConveyorLegal_Save_ShouldSaveWithSuccess()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetLegalConveyor(ObjectMother.GetAddress());

            int expectedId = 3;

            //Ação
            var result = _repository.Save(conveyor);

            //Saída
            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void Conveyors_InfraORM_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
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
        public void Conveyors_InfraORM_ConveyorPhysical_Get_ShouldGetWithSuccess()
        {
            //Cenario
            long idSearch = 2;
            PersonType expectedType = PersonType.PHYSICAL;

            //Execução
            var result = _repository.Get(idSearch);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(idSearch);
            result.NameCompanyName.Should().NotBeEmpty();
            result.CpfCnpj.Should().NotBeNull();
            result.PersonType.Should().Be(expectedType);
            result.Address.Should().NotBeNull();
        }

        [Test]
        public void Conveyors_InfraORM_ConveyorLegal_Get_ShouldGetWithSuccess()
        {
            //Cenario
            PersonType expectedType = PersonType.LEGAL;
            long idSearch = 1;

            //Execução
            var result = _repository.Get(idSearch);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(idSearch);
            result.NameCompanyName.Should().NotBeEmpty();
            result.CpfCnpj.Should().NotBeNull();
            result.PersonType.Should().Be(expectedType);
            result.Address.Should().NotBeNull();
        }

        [Test]
        public void Conveyors_InfraORM_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
            int size = 2;

            //Execução
            var result = _repository.GetAll();

            //Saída
            result.Should().NotBeNull();
            result.Count().Should().Be(size);
        }

        [Test]
        public void Conveyors_InfraORM_GetAllWithSize_ShouldGetAllWithSuccess()
        {
            //Cenario
            int size = 2;

            //Execução
            var result = _repository.GetAll(size);

            //Saída
            result.Should().NotBeNull();
            result.Count().Should().Be(size);
        }

        [Test]
        public void Conveyors_InfraORM_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            long searchId = 2;

            //Ação
            _repository.Delete(searchId);

            //Saída
            var result = _repository.Get(searchId);
            result.Should().BeNull();
        }

        [Test]
        public void Conveyors_InfraORM_Delete_ShouldThrowNotFoundException()
        {
            //Cenario
            int id = 1000;

            //Ação
            Action action = () => _repository.Delete(id);

            //Saída
            action.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Conveyors_InfraORM_CheckDependency_ShouldCheckDependencyWithSuccess()
        {
            //Cenário
            long searchId = 1;
            Conveyor conveyor = _repository.Get(searchId);

            //Ação
            var result = _repository.CheckDependency(conveyor);

            //Saída
            result.Should().BeTrue(); //Tem dependência
        }
    }
}
