using Enedir.MF7.Common.Tests.Features;
using Enedir.MF7.Domain.Features.Functionaries;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Enedir.MF7.Domain.Tests.Features.Functionaries
{
    [TestFixture]
    public class FunctionaryTest
    {
      
        [Test]
        public void Functionaries_Domain_ValidateEmail_ShouldBeOK()
        {
            // Arrange
            Functionary functionary = ObjectMother.GetFunctionaryDefault();
            bool newStatus = false;

            // Act
            functionary.ChangeStatus(newStatus);

            // Assert
            functionary.Status.Should().BeFalse();
        }

        [Test]
        public void Functionaries_Domain_GetFullName_ShouldBeOK()
        {
            // Arrange
            Functionary functionary = ObjectMother.GetFunctionaryDefault();
            string fullName = "Galise da Silva";

            // Act
            var result = functionary.GetFullName();

            // Assert
            result.Should().Be(fullName);
        }

    }
}
