using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Conveyors;
using Projeto_NFe.Application.Features.Conveyors.Commands;
using Projeto_NFe.Application.Features.Conveyors.Queries;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Conveyors;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Projeto_NFe.Application.Test.Features.Conveyors
{
    [TestFixture]
    public class ConveyorApplicationTest
    {
        private Mock<IConveyorRepository> _mockRepository;
        private Mock<ConveyorRegisterCommand> _mockRegisterCommand;
        private Mock<ConveyorUpdateCommand> _mockUpdateCommand;
        private ConveyorDeleteCommand _removeCommand;

        private IConveyorService _service;
        private List<Conveyor> _conveyors;
        private Conveyor _conveyor;

        [OneTimeSetUp]
        public void InitializeOnce()
        {
            AutoMapperInitializer.Initialize();
        }

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IConveyorRepository>();
            _mockRegisterCommand = new Mock<ConveyorRegisterCommand>();
            _mockUpdateCommand = new Mock<ConveyorUpdateCommand>();
            _removeCommand = new ConveyorDeleteCommand();

            _service = new ConveyorService(_mockRepository.Object);
            _conveyor = new Conveyor { Id = 1 };

            _conveyors = new List<Conveyor>();
            _conveyors.Add(new Mock<Conveyor>().Object);
            _conveyors.Add(new Mock<Conveyor>().Object);
            _conveyors.Add(new Mock<Conveyor>().Object);
        }

        [Test]
        public void Conveyors_Service_Add_ShouldAddWithSuccess()
        {
            //Cenario
            _mockRepository.Setup(m => m.Save(It.IsAny<Conveyor>())).Returns(_conveyor);

            long biggerThan = 0;
            long expectedId = 1;

            //Executa
            long conveyorId = _service.Add(_mockRegisterCommand.Object);

            //Saida
            conveyorId.Should().BeGreaterThan(biggerThan);
            conveyorId.Should().Be(expectedId);
            _mockRepository.Verify(m => m.Save(It.IsAny<Conveyor>()));
        }

        [Test]
        public void Conveyors_Service_Update_ShouldUpdateWithSuccess()
        {
            // Cenario
            _mockRepository.Setup(m => m.Update(It.IsAny<Conveyor>())).Returns(true);
            _mockRepository.Setup(m => m.Get(It.IsAny<long>())).Returns(_conveyor);

            //Executa
            bool updated = _service.Update(_mockUpdateCommand.Object);

            //Saida
            _mockRepository.Verify(m => m.Update(It.IsAny<Conveyor>()));
            _mockRepository.Verify(m => m.Get(It.IsAny<long>()));
            updated.Should().BeTrue();
        }

        [Test]
        public void Conveyors_Service_Update_ShouldThrowNotFoundException()
        {
            // Cenario Executa
            Action action = () => _service.Update(_mockUpdateCommand.Object);

            //Saida
            action.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Conveyors_Service_Get_ShouldGetWithSuccess()
        {
            // Cenario
            int searchId = 1;
            _mockRepository.Setup(m => m.Get(searchId)).Returns(_conveyor);

            // Executa
            Conveyor result = _service.Get(searchId);

            // Saída	
            result.Should().NotBeNull();
            _mockRepository.Verify(m => m.Get(searchId));
        }

        [Test]
        public void Conveyors_Service_Get_ShouldThrowNotFoundException()
        {
            // Cenario
            int searchId = 2000;
            _mockRepository.Setup(m => m.Get(searchId)).Returns(It.IsAny<Conveyor>());

            // Executa
            Action action = () => _service.Get(searchId);

            // Saída	
            action.Should().Throw<NotFoundException>();
            _mockRepository.Verify(m => m.Get(searchId));
        }

        [Test]
        public void Conveyors_Service_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenario
            _mockRepository.Setup(x => x.GetAll()).Returns(_conveyors.AsQueryable());
            int size = 3;

            //	Executa
            IQueryable<Conveyor> results = _service.GetAll();

            // Saída

            results.Count().Should().Equals(size);
            _mockRepository.Verify(m => m.GetAll());
        }

        [Test]
        public void Conveyors_Service_GetAllWithSize_ShouldGetAllWithSuccess()
        {
            // Cenario
            _mockRepository.Setup(x => x.GetAll(It.IsAny<int>())).Returns(_conveyors.AsQueryable());

            int size = 3;
            ConveyorQuery query = new ConveyorQuery(size);

            //	Executa
            IQueryable<Conveyor> results = _service.GetAll(query);

            // Saída
            results.Count().Should().Equals(size);
            _mockRepository.Verify(m => m.GetAll(It.IsAny<int>()));
        }

        [Test]
        public void Conveyors_Service_Delete_ShouldDeleteWithSuccess()
        {
            // Cenario
            long id = 1;
            var conveyorIds = new long[] { id };
            _mockRepository.Setup(m => m.Delete(It.IsAny<long>())).Returns(true);
            _removeCommand.ConveyorsIds = conveyorIds;

            //	Executa
            bool result = _service.Delete(_removeCommand);

            // Saída
            result.Should().BeTrue();
            _mockRepository.Verify(m => m.Delete(It.IsAny<long>()));
        }

        [Test]
        public void Conveyors_Service_Delete_ShouldNotDeleteWithSuccess()
        {
            // Cenario
            long id = 1;
            var conveyorIds = new long[] { id };
            _mockRepository.Setup(m => m.Delete(It.IsAny<long>())).Returns(false);
            _removeCommand.ConveyorsIds = conveyorIds;

            //	Executa
            bool result = _service.Delete(_removeCommand);

            // Saída
            result.Should().BeFalse();
            _mockRepository.Verify(m => m.Delete(It.IsAny<long>()));
        }
    }
}
