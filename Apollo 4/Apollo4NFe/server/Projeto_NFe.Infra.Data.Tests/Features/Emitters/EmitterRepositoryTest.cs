using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Infra.Data.Features.Emitters;
using Projeto_NFe.Infra.ORM.Tests.Inicialize;
using System;
using System.Linq;

namespace Projeto_NFe.Infra.ORM.Tests.Features.Emitters
{
    [TestFixture]
    public class EmitterRepositoryTest : EffortBaseTest
    {
        private IEmitterRepository _repository;

        [SetUp]
        public void Initialize()
        {
            _repository = new EmitterRepository(context);
        }

        [Test]
        public void Emitters_InfraORM_Save_ShouldSaveWithSuccess()
        {
            //Cenário
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
            int idExpected = 3;

            //Executa
            emitter = _repository.Save(emitter);

            //Saída
            emitter.Should().NotBeNull();
            emitter.Id.Should().Be(idExpected);
        }

        [Test]
        public void Emitters_InfraORM_Update_ShouldUpdateWithSuccess()
        {
            //Cenário
            long searchId = 1;
            string newName = "Novo";
            Emitter emitter = _repository.Get(searchId);
            emitter.CompanyName = newName;

            //Executa
            _repository.Update(emitter);

            //Saída
            Emitter result = _repository.Get(searchId);
            result.CompanyName.Should().Be(emitter.CompanyName);
        }

        [Test]
        public void Emitters_InfraORM_Get_ShouldGetWithSuccess()
        {
            //Cenário
            long searchId = 1;

            //Executa
            Emitter result = _repository.Get(searchId);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
        }

        [Test]
        public void Emitters_InfraORM_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenário
            int biggerThan = 0;

            //Executa
            IQueryable<Emitter> emitters = _repository.GetAll();

            //Saída
            emitters.Count().Should().BeGreaterThan(biggerThan);
        }

        [Test]
        public void Products_InfraORM_GetAllWithSize_ShouldGetAllWithSuccess()
        {
            //Cenario
            int amountItems = 1;

            //Execução
            var result = _repository.GetAll(amountItems);

            //Saída
            result.Count().Should().Be(amountItems);
        }

        [Test]
        public void Emitters_InfraORM_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long searchId = 2;

            //Executa
            _repository.Delete(searchId);

            //Saida
            Emitter result = _repository.Get(searchId);
            result.Should().BeNull();
        }

        [Test]
        public void Emitters_InfraORM_Delete_ShouldThrowNotFoundException()
        {
            //Cenario
            int id = 1000;

            //Ação
            Action action = () => _repository.Delete(id);

            //Saída
            action.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Emitters_InfraORM_CheckDependency_ShouldCheckDependencyWithSuccess()
        {
            //Cenario
            long searchId = 1;
            Emitter emitter = _repository.Get(searchId);

            //Ação
            bool result = _repository.CheckDependency(emitter);

            //Saída
            result.Should().BeTrue();
        }
    }
}
