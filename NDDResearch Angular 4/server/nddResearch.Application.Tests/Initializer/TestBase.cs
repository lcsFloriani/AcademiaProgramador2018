using MPSPortal.Application.Mapping;
using NUnit.Framework;

namespace nddResearch.Application.Tests.Initializer
{
    [TestFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public void Initialize()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }
    }
}
