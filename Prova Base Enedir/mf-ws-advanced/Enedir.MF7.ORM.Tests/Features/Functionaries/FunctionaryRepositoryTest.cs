using Enedir.MF7.Common.Tests.Features;
using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Infra.ORM.Features.Functionaries;
using Enedir.MF7.ORM.Tests.Initializer;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Enedir.MF7.ORM.Tests.Features.Functionaries
{
    [TestFixture]
    public class FunctionaryRepositoryTest : EffortTestBase
    {
        private IFunctionaryRepository _repository;
        private long functionaryIdDefault = 1;

        [SetUp]
        public void Initialize()
        {
            _repository = new FunctionaryRepository(context);
        }

        [Test]
        public void Functionaries_InfraORM_Save_ShouldBeOk() {
            // Arrange
            Functionary functionary = ObjectMother.GetFunctionaryDefault();
            long expectedId = 3;

            // Act
            var newFunctionary = _repository.Save(functionary);

            // Assert
            newFunctionary.Should().NotBeNull();
            newFunctionary.Id.Should().Be(expectedId);
            var searchFunctionary = _repository.GetById(expectedId);
            searchFunctionary.Should().NotBeNull();
        }

        [Test]
        public void Functionaries_InfraORM_Update_ShouldBeOk()
        {
            // Arrange
            long searchId = 1;
            var functionary = _repository.GetById(searchId);
            string oldName = functionary.FirstName;
            functionary.FirstName = "Míguel";

            // Act
            bool operationResult = _repository.Update(functionary);

            // Assert
            operationResult.Should().BeTrue();
            var searchFunctionary = _repository.GetById(searchId);
            searchFunctionary.Should().NotBeNull();
            searchFunctionary.FirstName.Should().NotBe(oldName);
        }

        [Test]
        public void Functionaries_InfraORM_GetById_ShouldBeOk()
        {
            // Arrange
            long searchId = 1;

            // Act
            var searchFunctionary = _repository.GetById(searchId);

            // Assert
            searchFunctionary.Should().NotBeNull();
            searchFunctionary.Id.Should().Be(searchId);
        }

        [Test]
        public void Functionaries_InfraORM_GetAll_ShouldBeOk()
        {
            // Arrange
            int quantity = 1;

            // Act
            var functionarys = _repository.GetAll(quantity);

            // Assert
            functionarys.Should().NotBeNull();
            functionarys.Count().Should().Be(quantity);
            functionarys.First().Id.Should().Be(functionaryIdDefault);

        }

        [Test]
        public void Functionaries_InfraORM_Delete_ShouldBeOk()
        {
            // Arrange
            long searchId = 1;
            var functionary = _repository.GetById(searchId);

            // Act
            bool operationResult = _repository.Delete(functionary);

            // Assert
            operationResult.Should().BeTrue();
            var deleteFunctionary = _repository.GetById(searchId);
            deleteFunctionary.Should().BeNull();
        }

        [Test]
        public void Functionaries_InfraORM_HasDependency_ShouldBeTrue()
        {
            // Arrange
            long searchId = 1;
            var functionary = _repository.GetById(searchId);

            // Act
            bool operationResult = _repository.HasDependency(functionary);

            // Assert
            operationResult.Should().BeTrue();
        }

        [Test]
        public void Functionaries_InfraORM_HasDependency_ShouldBeFalse()
        {
            // Arrange
            long searchId = 2;
            var functionary = _repository.GetById(searchId);

            // Act
            bool operationResult = _repository.HasDependency(functionary);

            // Assert
            operationResult.Should().BeFalse();
        }



        [Test]
        public void Functionaries_InfraORM_CheckCredential_ShouldBeTrue()
        {
            // Arrange
            string user = "r16";
            string password = "12345";

            // Act
            bool operationResult = _repository.CheckCredential(user,password);

            // Assert
            operationResult.Should().BeTrue();
        }

        [Test]
        public void Functionaries_InfraORM_CheckCredential_ShouldBeFalse()
        {
            // Arrange
            string user = "adasdas";
            string password = "12";

            // Act
            bool operationResult = _repository.CheckCredential(user, password);

            // Assert
            operationResult.Should().BeFalse();
        }

    }
}
