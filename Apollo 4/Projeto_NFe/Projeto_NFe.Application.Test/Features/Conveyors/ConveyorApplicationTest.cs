using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Conveyors;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Infra.CPF;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Application.Test.Features.Conveyors
{
    [TestFixture]
    public class ConveyorApplicationTest
    {
        private Mock<IConveyorRepository> _mockConveyorRepository;
        private IConveyorService _service;

        private Conveyor _firstConveyor;
        private Conveyor _secondConveyor;
        private Conveyor _thirdConveyor;

        [SetUp]
        public void Initialize()
        {
            _mockConveyorRepository = new Mock<IConveyorRepository>();

            _service = new ConveyorService(_mockConveyorRepository.Object);

            _firstConveyor = new Conveyor { Id = 1 };
            _secondConveyor = new Conveyor { Id = 2 };
            _thirdConveyor = new Conveyor { Id = 3 };
        }

        [Test]
        public void Conveyors_Application_Add_ShouldAddWithSuccess()
        {
            //Cenario
            long id = 1;

            Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf());

            _mockConveyorRepository.Setup(x => x.Save(It.IsAny<Conveyor>())).Returns(new Conveyor { Id = id });

            //Ação
            var result = _service.Add(conveyor);
            
            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
            _mockConveyorRepository.Verify(x => x.Save(It.IsAny<Conveyor>()));
        }


        [Test]
        public void Conveyors_Application_Add_ShouldThrowAddressNullException()
        {
            //Cenario
            Conveyor conveyor = ObjectMother.GetConveyorWithoutAddress();

            //Ação
            Action action = () => _service.Add(conveyor);

            //Saída
            action.Should().Throw<ConveyorAddressNullException>();
            _mockConveyorRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Conveyors_Application_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            string newName = "Teste XYZ";
            long id = 1;

            _mockConveyorRepository.Setup(x => x.Update(It.IsAny<Conveyor>())).Returns(new Conveyor { NameCompanyName = newName });

            Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            conveyor.Id = id;

            //Ação
            var result = _service.Update(conveyor);

            //Saída
            result.NameCompanyName.Should().Be(newName);
            _mockConveyorRepository.Verify(x => x.Update(It.IsAny<Conveyor>()));
        }

        [Test]
        public void Conveyors_Application_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long id = 0;

            Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            conveyor.Id = id;

            //Ação
            Action action = () => _service.Update(conveyor);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
            _mockConveyorRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Conveyors_Application_Update_ShouldThrowAddressNullException()
        {
            //Cenario
            long id = 1;

            Conveyor conveyor = ObjectMother.GetConveyorWithoutAddress();
            conveyor.Id = id;

            //Ação
            Action action = () => _service.Update(conveyor);

            //Saída
            action.Should().Throw<ConveyorAddressNullException>();
            _mockConveyorRepository.VerifyNoOtherCalls();
        }


        [Test]
        public void Conveyors_Application_Get_ShouldGetWithSuccess()
        {
            //Cenario
            long id = 1;

            _mockConveyorRepository.Setup(x => x.Get(id)).Returns(new Conveyor { Id = id });

            //Ação
            Conveyor conveyor = _service.Get(id);

            //Saída
            conveyor.Should().NotBeNull();
            _mockConveyorRepository.Verify(x => x.Get(It.IsAny<long>()));
        }

        [Test]
        public void Conveyors_Application_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long id = 0;
            _mockConveyorRepository.Setup(x => x.Get(id)).Returns(new Conveyor { Id = id });

            //Ação
            Action action = () =>  _service.Get(id);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
            _mockConveyorRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Conveyors_Application_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
            int size = 3;

            _mockConveyorRepository.Setup(x => x.GetAll()).Returns(new List<Conveyor>()
            {
                _firstConveyor,
                _secondConveyor,
                _thirdConveyor
            });

            //Ação
            List<Conveyor> list = _service.GetAll() as List<Conveyor>;

            //Saída
            list.Should().NotBeNull();
            list.Count.Should().Be(size);
            _mockConveyorRepository.Verify(x => x.GetAll());
        }

        [Test]
        public void Conveyors_Application_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            long id = 1;

            Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            conveyor.Id = id;

            _mockConveyorRepository.Setup(x => x.Delete(It.IsAny<Conveyor>()));

            //Ação
            _service.Delete(conveyor);

            //Saída
            _mockConveyorRepository.Verify(x => x.Delete(It.IsAny<Conveyor>()));
        }

        [Test]
        public void Conveyors_Application_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long id = 0;

            Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            conveyor.Id = id;

            _mockConveyorRepository.Setup(x => x.Delete(It.IsAny<Conveyor>()));

            //Ação
            Action action = () => _service.Delete(conveyor);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
            _mockConveyorRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Conveyor_Service_Delete_ShouldThrowConveyorWithDependencyException()
        {
            //Cenário
            Conveyor conveyor = ObjectMother.GetConveyor(ObjectMother.GetAddress());
            conveyor.Id = 1;
            bool exist = true;

            _mockConveyorRepository.Setup(x => x.CheckDependency(conveyor)).Returns(exist);

            //Ação
            Action action = () => _service.Delete(conveyor);

            //Saída
            action.Should().Throw<ConveyorWithDependencyException>();
            _mockConveyorRepository.Verify(m => m.CheckDependency(conveyor));
        }
    }
}
