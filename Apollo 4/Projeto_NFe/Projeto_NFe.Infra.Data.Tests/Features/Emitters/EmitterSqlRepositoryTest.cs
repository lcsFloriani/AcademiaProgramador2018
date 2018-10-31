using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Infra.Data.Features.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Tests.Features.Emitters
{
    [TestFixture]
    public class EmitterSqlRepositoryTest
    {
        private IEmitterRepository _repository;

        [SetUp]
        public void Initialize()
        {
            _repository = new EmitterSqlRepository();
        }

        [Test]
        public void Emitters_InfraData_Save_ShouldSaveWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithoutEmitter();

            Emitter modelo = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            int idExpected = 1;

            //Executa
            modelo = _repository.Save(modelo);

            //Saída
            modelo.Should().NotBeNull();
            modelo.Id.Should().Be(idExpected);
        }

        [Test]
        public void Emitters_InfraData_Update_ShouldUpdateWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithEmitter();
            Emitter modelo = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            modelo.Id = 1;

            int idExpected = 1;

            //Executa
            modelo = _repository.Update(modelo);

            //Saída
            modelo.Should().NotBeNull();
            modelo.Id.Should().Be(idExpected);
        }

        [Test]
        public void Emitters_InfraData_Get_ShouldGetWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithEmitter();

            long searchId = 1;
            string expectedFantasyName = "Boticario";

            //Executa
            var getModel = _repository.Get(searchId);

            //Saída
            getModel.Should().NotBeNull();
            getModel.Id.Should().Be(searchId);
            getModel.FantasyName.Should().Be(expectedFantasyName);
        }

        [Test]
        public void Emitters_InfraData_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithoutEmitter();

            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;

            //Executa
            _repository.Delete(emitter);
            var getModel = _repository.Get(emitter.Id);

            //Saida
            getModel.Should().BeNull();
        }

        [Test]
        public void Emitters_InfraData_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithEmitter();
            int biggerThan = 0;

            //Executa
            List<Emitter> emitters = (List<Emitter>)_repository.GetAll();

            //Saída
            emitters.Count().Should().BeGreaterThan(biggerThan);
        }

        [Test]
        public void Emitters_InfraData_Save_ShouldThrowEmitterFantasyNameNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidFantasyName(ObjectMother.GetAddress(),ObjectMother.GetCnpj());

            //Executa
            Action executeAction = () => _repository.Save(emitter);

            //Saída
            executeAction.Should().Throw<EmitterFantasyNameNullOrEmptyException>();
        }

        [Test]
        public void Emitters_InfraData_Update_ShouldThrowEmitterFantasyNameNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidFantasyName(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;

            //Executa
            Action executeAction = () => _repository.Update(emitter);

            //Saída
            executeAction.Should().Throw<EmitterFantasyNameNullOrEmptyException>();
        }

        [Test]
        public void Emitters_InfraData_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidFantasyName(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            //Executa
            Action executeAction = () => _repository.Update(emitter);

            //Saída
            executeAction.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emitters_InfraData_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            //Executa
            Action executeAction = () => _repository.Get(emitter.Id);

            //Saída
            executeAction.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emitters_InfraData_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            //Executa
            Action executeAction = () => _repository.Delete(emitter);

            //Saída
            executeAction.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emitters_InfraData_CheckDependency_ShouldCheckDependencyWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithEmitterWithDependency();

            long searchId = 1;
            Emitter emitters = _repository.Get(searchId);

            //Ação
            var result = _repository.CheckDependency(emitters);

            //Saída
            result.Should().BeTrue();//tem dependencias
        }
    }
}
