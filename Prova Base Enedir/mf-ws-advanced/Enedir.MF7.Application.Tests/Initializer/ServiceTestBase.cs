using Enedir.MF7.Application.Mappers;
using NUnit.Framework;

namespace Enedir.MF7.Application.Tests.Initializer
{
    [TestFixture]
    public class ServiceTestBase
    {

        [OneTimeSetUp]
        public void InitializeOneTime()
        {
            AutoMapperConfig.RegisterMappings();
        }
    }
}
