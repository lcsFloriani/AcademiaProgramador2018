using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Emitters;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Infra.Data.Features.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Features.Emitters
{
    [TestFixture]
    public class EmitterSQLIntegrationTest
    {
        private IEmitterRepository _emitterRepository;
        private IEmitterService _service;

        [SetUp]
        public void Initialize()
        {
            _emitterRepository = new EmitterSqlRepository();

            _service = new EmitterService(_emitterRepository);
        }

        [Test]
        public void Emitters_Integration_Add_ShouldAddWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithoutEmitter();

            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            int expectedId = 1;

            //Ação
            var addEmitter = _service.Add(emitter);

            //Saída
            addEmitter.Should().NotBeNull();
            addEmitter.Id.Should().Be(expectedId);

        }

        [Test]
        public void Emitters_Integration_Add_Validate_ShouldThrowFantasyNameNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidFantasyName(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            //Ação
            Action addEmitter = () => _service.Add(emitter);

            //Saída
            addEmitter.Should().Throw<EmitterFantasyNameNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Integration_Add_Validate_ShouldThrowCompanyNameNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidCompanyName(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            //Ação
            Action addEmitter = () => _service.Add(emitter);

            //Saída
            addEmitter.Should().Throw<EmitterCompanyNameNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Integration_Add_Validate_ShouldThrowCnpjNullException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidCnpj(ObjectMother.GetAddress(), null);

            //Ação
            Action addEmitter = () => _service.Add(emitter);

            //Saída
            addEmitter.Should().Throw<EmitterCnpjNullException>();
        }

        [Test]
        public void Emitters_Integration_Add_Validate_ShouldThrowStateRegistrationNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidStateRegistration(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            //Ação
            Action addEmitter = () => _service.Add(emitter);

            //Saída
            addEmitter.Should().Throw<EmitterStateRegistrationNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Integration_Add_Validate_ShouldThrowMunicipalRegistrationNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidMunicipalRegistration(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            //Ação
            Action addEmitter = () => _service.Add(emitter);

            //Saída
            addEmitter.Should().Throw<EmitterMunicipalRegistrationNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Integration_Update_ShouldUpdateWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithEmitter();

            long searchId = 1;
            string newCompanyName = "Terra";
            Emitter emitter = _service.Get(searchId);
            emitter.CompanyName = newCompanyName;

            //Ação
            var updateEmitter = _service.Update(emitter);

            //Saída
            updateEmitter.CompanyName.Should().Be(newCompanyName);
        }

        [Test]
        public void Emitters_Integration_Update_Validate_ShouldUpdateWithSuccess()
        {
            //Cenário
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 0;

            //Ação
            Action updateEmitter = () => _service.Update(emitter);

            //Saída
            updateEmitter.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emitters_Integration_Get_ShouldGetWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithEmitter();

            long searchId = 1;

            //Ação
            Emitter e = _service.Get(searchId);

            //Saída
            e.Should().NotBeNull();
        }

        [Test]
        public void Emitters_Integration_Get_ShouldBeFail()
        {
            //Cenario
            long searchId = 13;

            //Ação
            Emitter e = _service.Get(searchId);

            //Saída
            e.Should().BeNull();
        }

        [Test]
        public void Emitters_Integration_Get_Validate_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long searchId = 0;

            //Ação
            Action action = () => _service.Get(searchId);
            
            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }


        [Test]
        public void Emitters_Integration_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithEmitter();

            int biggerThan = 0;
            int size = 1;
            long id = 1;
            
            //Ação
            List<Emitter> list = _service.GetAll() as List<Emitter>;
            
            //Saída
            list.Should().NotBeNull();
            list.Count.Should().BeGreaterThan(biggerThan);
            list.Count.Should().Be(size);
            list.First().Id.Should().Be(id);
        }

        [Test]
        public void Emitters_Integration_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithEmitter();

            long searchId = 1;
            Emitter e = _service.Get(searchId);
            
            //Ação
            _service.Delete(e);
            
            //Saída
            var result = _service.Get(searchId);
            result.Should().BeNull();
        }

        [Test]
        public void Emitters_Integration_Delete_ShouldBeFail()
        {
            //Cenario
            long searchId = 13;
            Emitter e = new Emitter { Id = searchId };
            
            //Ação
            _service.Delete(e);
            
            //Saída
            var result = _service.Get(searchId);
            result.Should().BeNull();
        }

        [Test]
        public void Emitters_Integration_Delete_Validate_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long searchId = 0;
            Emitter e = new Emitter { Id = searchId };
            
            //Ação
            Action action = () => _service.Delete(e);
            
            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
