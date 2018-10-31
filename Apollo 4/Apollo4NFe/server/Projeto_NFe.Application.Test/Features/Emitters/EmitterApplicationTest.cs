using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Emitters;
using Projeto_NFe.Application.Features.Emitters.Commands;
using Projeto_NFe.Application.Features.Emitters.Queries;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_NFe.Application.Test.Features.Emitters
{
    [TestFixture]
    public class EmitterApplicationTest
    {
        private Mock<IEmitterRepository> _mockRepository;
        private Mock<EmitterRegisterCommand> _mockRegisterCommand;
        private Mock<EmitterUpdateCommand> _mockUpdateCommand;
        private EmitterDeleteCommand _removeCommand;

        private IEmitterService _service;
        private List<Emitter> _emitters;
        private Emitter _emitter;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IEmitterRepository>();
            _mockRegisterCommand = new Mock<EmitterRegisterCommand>();
            _mockUpdateCommand = new Mock<EmitterUpdateCommand>();
            _removeCommand = new EmitterDeleteCommand();

            _service = new EmitterService(_mockRepository.Object);
            _emitter = new Emitter { Id = 1 };

            _emitters = new List<Emitter>();
            _emitters.Add(new Mock<Emitter>().Object);
            _emitters.Add(new Mock<Emitter>().Object);
            _emitters.Add(new Mock<Emitter>().Object);
        }

        [Test]
        public void Emitters_Service_Add_ShouldAddWithSuccess()
        {
            //Cenario
            _mockRepository.Setup(m => m.Save(It.IsAny<Emitter>())).Returns(_emitter);

            long biggerThan = 0;
            long expectedId = 1;

            //Executa
            long emitterId = _service.Add(_mockRegisterCommand.Object);

            //Saida
            emitterId.Should().BeGreaterThan(biggerThan);
            emitterId.Should().Be(expectedId);
            _mockRepository.Verify(m => m.Save(It.IsAny<Emitter>()));
        }

        [Test]
        public void Emitters_Service_Update_ShouldUpdateWithSuccess()
        {
            // Cenario
            _mockRepository.Setup(m => m.Update(It.IsAny<Emitter>())).Returns(true);
            _mockRepository.Setup(m => m.Get(It.IsAny<long>())).Returns(_emitter);

            //Executa
            bool updated = _service.Update(_mockUpdateCommand.Object);

            //Saida
            _mockRepository.Verify(m => m.Update(It.IsAny<Emitter>()));
            _mockRepository.Verify(m => m.Get(It.IsAny<long>()));
            updated.Should().BeTrue();
        }

        [Test]
        public void Emitters_Service_Update_ShouldThrowNotFoundException()
        {
            // Cenario Executa
            Action action = () => _service.Update(_mockUpdateCommand.Object);

            //Saida
            action.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Emitters_Service_Get_ShouldGetWithSuccess()
        {
            // Cenario
            int searchId = 1;
            _mockRepository.Setup(m => m.Get(searchId)).Returns(_emitter);

            // Executa
            Emitter result = _service.Get(searchId);

            // Saída	
            result.Should().NotBeNull();
            _mockRepository.Verify(m => m.Get(searchId));

        }

        [Test]
        public void Emitters_Service_Get_ShouldThrowNotFoundException()
        {
            // Cenario
            int searchId = 2000;
            _mockRepository.Setup(m => m.Get(searchId)).Returns(It.IsAny<Emitter>());

            // Executa
            Action action = () => _service.Get(searchId);

            // Saída	
            action.Should().Throw<NotFoundException>();
            _mockRepository.Verify(m => m.Get(searchId));
        }

        [Test]
        public void Emitters_Service_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenario
            _mockRepository.Setup(x => x.GetAll()).Returns(_emitters.AsQueryable());
            int size = 3;

            //	Executa
            IQueryable<Emitter> results = _service.GetAll();

            // Saída
            results.Count().Should().Equals(size);
            _mockRepository.Verify(m => m.GetAll());
        }

        [Test]
        public void Emitters_Service_GetAllWithSize_ShouldGetAllWithSuccess()
        {
            // Cenario
            _mockRepository.Setup(x => x.GetAll(It.IsAny<int>())).Returns(_emitters.AsQueryable());

            int size = 3;
            EmitterQuery query = new EmitterQuery(size);

            //	Executa
            IQueryable<Emitter> results = _service.GetAll(query);

            // Saída
            results.Count().Should().Equals(size);
            _mockRepository.Verify(m => m.GetAll(It.IsAny<int>()));
        }

        [Test]
        public void Emitters_Service_Delete_ShouldDeleteWithSuccess()
        {
            // Cenario
            long id = 1;
            var emitterIds = new long[] { id };
            _mockRepository.Setup(m => m.Delete(It.IsAny<long>())).Returns(true);
            _removeCommand.EmitterIds = emitterIds;

            //	Executa
            bool result = _service.Delete(_removeCommand);

            // Saída
            result.Should().BeTrue();
            _mockRepository.Verify(m => m.Delete(It.IsAny<long>()));
        }

        [Test]
        public void Emitters_Service_Delete_ShouldNotDeleteWithSuccess()
        {
            // Cenario
            long id = 1;
            var emitterIds = new long[] { id };
            _mockRepository.Setup(m => m.Delete(It.IsAny<long>())).Returns(false);
            _removeCommand.EmitterIds = emitterIds;

            //	Executa
            bool result = _service.Delete(_removeCommand);

            // Saída
            result.Should().BeFalse();
            _mockRepository.Verify(m => m.Delete(It.IsAny<long>()));
        }
    }
}
