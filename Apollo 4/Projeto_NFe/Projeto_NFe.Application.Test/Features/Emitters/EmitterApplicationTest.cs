using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Emitters;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Test.Features.Emitters
{
    [TestFixture]
    public class EmitterApplicationTest
    {
        private Mock<IEmitterRepository> _mockEmitterRepository;
        private IEmitterService _service;

        [SetUp]
        public void Initialize()
        {
            _mockEmitterRepository = new Mock<IEmitterRepository>();
            _service = new EmitterService(_mockEmitterRepository.Object);
        }

        [Test]
        public void Emitters_Application_Add_ShouldAddWithSuccess()
        {
            //Cenário
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            
            long id = 1;
            _mockEmitterRepository.Setup(x => x.Save(It.IsAny<Emitter>())).Returns(new Emitter { Id = id });
           
            //Ação
            var result = _service.Add(emitter);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
            _mockEmitterRepository.Verify(x => x.Save(It.IsAny<Emitter>()));
        }

        [Test]
        public void Emitters_Application_Add_ShouldThrowCompanyNameNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidCompanyName(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            //Ação
            Action emitterAdd = () => _service.Add(emitter);

            //Saída
            emitterAdd.Should().Throw<EmitterCompanyNameNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Application_Update_ShouldUpdateWithSuccess()
        {
            //Cenário
            long id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = id;
            string oldFantasyName = emitter.FantasyName;
            emitter.FantasyName =  "Avon";
            _mockEmitterRepository.Setup(x => x.Update(emitter)).Returns(emitter);

            //Ação
            var emitterUpdate = _service.Update(emitter);

            //Saída
            emitterUpdate.FantasyName.Should().NotBe(oldFantasyName);
            _mockEmitterRepository.Verify(x => x.Update(emitter));
        }

        [Test]
        public void Emitters_Application_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 0;

            //Ação
            Action emitterUpdate = () => _service.Update(emitter);

            //Saída
            emitterUpdate.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emitters_Application_Update_ShouldThrowCompanyNameNullOrEmptyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.getEmitterInvalidCompanyName(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;

            //Ação
            Action emitterUpdate = () => _service.Update(emitter);

            //Saída
            emitterUpdate.Should().Throw<EmitterCompanyNameNullOrEmptyException>();
        }

        [Test]
        public void Emitters_Application_Get_ShouldGetWithSuccess()
        {
            //Cenário
            long id = 1;
            _mockEmitterRepository.Setup(x => x.Get(id)).Returns(new Emitter { Id = id });

            //Ação
            var getEmitter = _service.Get(id);

            //Saída
            getEmitter.Should().NotBeNull();
            _mockEmitterRepository.Verify(x => x.Get(It.IsAny<long>()));
        }

        [Test]
        public void Emitters_Application_Get_ShoudThrowIdentifierUndefinedException()
        {
            //Cenário
            long id = 0;

            //Ação
            Action getEmitter = () => _service.Get(id);

            //Saída
            getEmitter.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emitters_Application_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenário
            int listSize = 1;

            _mockEmitterRepository.Setup(x => x.GetAll()).Returns(new List<Emitter>()
            {
                new Emitter() {Id = 1}
            });

            //Ação
            var list = _service.GetAll();

            //Saída
            list.Count().Should().BeGreaterOrEqualTo(listSize);
        }

        [Test]
        public void Emitters_Application_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            emitter.Id = id;

            _mockEmitterRepository.Setup(x => x.Delete(It.IsAny<Emitter>()));

            //Ação
            _service.Delete(emitter);

            //Saída
            _mockEmitterRepository.Verify(x => x.Delete(It.IsAny<Emitter>()));

        }

        [Test]
        public void Emitters_Service_Delete_ShouldThrowProductWithDependencyException()
        {
            //Cenário
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(),ObjectMother.GetCnpj());
            emitter.Id = 1;
            bool exist = true;

            _mockEmitterRepository.Setup(x => x.CheckDependency(emitter)).Returns(exist);

            //Ação
            Action action = () => _service.Delete(emitter);

            //Saída
            action.Should().Throw<EmitterWithDependencyException>();
            _mockEmitterRepository.Verify(m => m.CheckDependency(emitter));
        }

        [Test]
        public void Emitters_Application_Delete_ShoulThrowIdentifierUndefinedException()
        {
            //Cenário
            long id = 0;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());

            emitter.Id = id;

            //Ação
            Action deleteEmitter = () => _service.Delete(emitter);

            //Saída
            deleteEmitter.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
