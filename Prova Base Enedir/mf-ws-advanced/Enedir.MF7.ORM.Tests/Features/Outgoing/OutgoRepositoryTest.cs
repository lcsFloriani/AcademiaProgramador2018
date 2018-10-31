using Enedir.MF7.Common.Tests.Features;
using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Domain.Features.Outgoing;
using Enedir.MF7.Infra.ORM.Features.Functionaries;
using Enedir.MF7.Infra.ORM.Features.Outgoing;
using Enedir.MF7.ORM.Tests.Initializer;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Enedir.MF7.ORM.Tests.Features.Outgoing
{
    [TestFixture]
    public class OutgoRepositoryTest : EffortTestBase
    {
        private IOutgoRepository _repository;
        private string outgoNameDefault = "Viagem";
        private long outgoIdDefault = 1;

        [SetUp]
        public void Initialize()
        {
            _repository = new OutgoRepository(context);
        }

        [Test]
        public void Functionaries_InfraORM_Save_ShouldBeOk() {
            // Arrange
            Outgo outgo = ObjectMother.GetOutgoDefault();
            long expectedId = 2;

            // Act
            var newOutgo = _repository.Save(outgo);

            // Assert
            newOutgo.Should().NotBeNull();
            newOutgo.Id.Should().Be(expectedId);
            var searchOutgo = _repository.GetById(expectedId);
            searchOutgo.Should().NotBeNull();
        }

   
        [Test]
        public void Functionaries_InfraORM_GetById_ShouldBeOk()
        {
            // Arrange
            long searchId = 1;

            // Act
            var searchOutgo = _repository.GetById(searchId);

            // Assert
            searchOutgo.Should().NotBeNull();
            searchOutgo.Id.Should().Be(searchId);
            searchOutgo.Description.Should().Be(outgoNameDefault);
        }

        [Test]
        public void Functionaries_InfraORM_GetAll_ShouldBeOk()
        {
            // Arrange
            int quantity = 1;

            // Act
            var outgos = _repository.GetAll(quantity);

            // Assert
            outgos.Should().NotBeNull();
            outgos.Count().Should().Be(quantity);
            outgos.First().Id.Should().Be(outgoIdDefault);
            outgos.First().Description.Should().Be(outgoNameDefault);
        }

        [Test]
        public void Functionaries_InfraORM_Delete_ShouldBeOk()
        {
            // Arrange
            long searchId = 1;
            var outgo = _repository.GetById(searchId);

            // Act
            bool operationResult = _repository.Delete(outgo);

            // Assert
            operationResult.Should().BeTrue();
            var deleteOutgo = _repository.GetById(searchId);
            deleteOutgo.Should().BeNull();
        }

    }
}
