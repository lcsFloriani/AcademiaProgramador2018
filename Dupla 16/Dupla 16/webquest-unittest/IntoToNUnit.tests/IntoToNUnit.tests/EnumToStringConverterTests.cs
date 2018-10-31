using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace IntoToNUnit.tests
{
    public enum TestTypes
    {
        None,
        UnitTesting,
        IntegrationTesting,
        FlyByTheSeatOfYourPantsTesting
    }
    public enum algumaCoisa{
        Asd,
        www
    }
    [TestFixture]
    public class EnumToStringConverterTests
    {
        [Test]
        public void CanConvertEnumIntoMultipleWords()
        {
            // Arrange/Act
            var actual = TestTypes.UnitTesting.ToFriendlyString();

            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual("Unit Testing", actual);
        }
    }
}
