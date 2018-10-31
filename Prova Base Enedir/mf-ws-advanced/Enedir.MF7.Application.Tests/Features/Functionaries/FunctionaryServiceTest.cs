using Enedir.MF7.Application.Features.Functionaries;
using Enedir.MF7.Application.Features.Functionaries.Commands;
using Enedir.MF7.Application.Features.Functionaries.Querys;
using Enedir.MF7.Application.Tests.Initializer;
using Enedir.MF7.Common.Tests.Features;
using Enedir.MF7.Domain.Exceptions;
using Enedir.MF7.Domain.Features.Functionaries;

using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enedir.MF7.Application.Tests.Features.Functionaries
{
    [TestFixture]
    public class FunctionaryServiceTest : ServiceTestBase
    {
        private Mock<IFunctionaryRepository> _repositoryFake;
        private FunctionaryService _service;
        private List<Functionary> functionaries;

        [SetUp]
        public void Initialize()
        {
            _repositoryFake = new Mock<IFunctionaryRepository>();
            _service = new FunctionaryService(_repositoryFake.Object);

            functionaries = new List<Functionary>()
            {
                new Functionary() { Id = 1 },
                new Functionary() { Id = 2 },
                new Functionary() { Id = 3 }
            };
        }

        [Test]
        public void Functionarys_Application_Add_ShouldBeOk()
        {
            // Arrange
            Functionary customer = ObjectMother.GetFunctionaryDefault();
            long expectedId = 1;

            _repositoryFake.Setup(c => c.Save(It.IsAny<Functionary>())).Returns(ObjectMother.GetFunctionarySeed());

            FunctionaryRegisterCommand command = ObjectMother.GetFunctionaryRegisterCommand();

            // Act
            long receiverId = _service.Add(command);

            // Assert
            expectedId.Should().Be(receiverId);
            _repositoryFake.Verify(repository => repository.Save(It.IsAny<Functionary>()));
        }

        [Test]
        public void Functionarys_Application_Update_ShouldBeOk()
        {
            // Arrange
            Functionary customer = ObjectMother.GetFunctionarySeed();

            var updatedFunctionary = ObjectMother.GetFunctionarySeed();
            updatedFunctionary.FirstName = "Fulano";

            _repositoryFake.Setup(c => c.Update(It.IsAny<Functionary>())).Returns(true);

            FunctionaryUpdateCommand command = ObjectMother.GetFunctionaryUpdateCommand();

            // Act
            bool operatingResult = _service.Update(command);

            // Assert
            operatingResult.Should().BeTrue();
            _repositoryFake.Verify(repository => repository.Update(It.IsAny<Functionary>()));
        }

        [Test]
        public void Functionarys_Application_GetById_ShouldBeOk()
        {
            // Arrange
            Functionary customer = ObjectMother.GetFunctionarySeed();
            long searchId = 1;

            _repositoryFake.Setup(c => c.GetById(It.IsAny<long>())).Returns(customer);


            // Act
            var result = _service.GetById(searchId);

            // Assert
            result.Id.Should().Be(searchId);
            _repositoryFake.Verify(repository => repository.GetById(It.IsAny<long>()));
        }

        [Test]
        public void Functionarys_Application_GetById_ShouldThrowIdentifierUndefinedException()
        {
            // Arrange
            Functionary customer = ObjectMother.GetFunctionarySeed();
            long searchId = 0;

            // Act
            Action action = () => _service.GetById(searchId);

            // Assert
            action.Should().Throw<IdentifierUndefinedException>();
            _repositoryFake.VerifyNoOtherCalls();
        }

        [Test]
        public void Functionarys_Application_GetAll_ShouldBeOk()
        {
            // Arrange
            FunctionaryQuery query = ObjectMother.GetFunctionaryQuery();
            _repositoryFake.Setup(c => c.GetAll(It.IsAny<int>())).Returns(functionaries.AsQueryable);

            int quantity = 3;
            
            // Act
            var results = _service.GetAll(query);

            // Assert
            results.Count().Should().Be(quantity);
            _repositoryFake.Verify(repository => repository.GetAll(It.IsAny<int>()));
        }

        [Test]
        public void Functionarys_Application_Delete_ShouldBeOk()
        {
            // Arrange
            Functionary customer = ObjectMother.GetFunctionarySeed();
            FunctionaryDeleteCommand command = ObjectMother.GetFunctionaryDeleteCommand();

            _repositoryFake.Setup(c => c.Delete(It.IsAny<Functionary>())).Returns(true);

            // Act
            bool operatingResult = _service.Remove(command);

            // Assert
            operatingResult.Should().BeTrue();
            _repositoryFake.Verify(repository => repository.Delete(It.IsAny<Functionary>()));
        }
    }
}
