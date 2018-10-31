using Effort.Provider;
using MPSPortal.Application.Mapping;
using NUnit.Framework;

namespace nddResearch.Infra.Data.Tests.Initializer
{
    [TestFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public void InitializeOneTime()
        {
            EffortProviderConfiguration.RegisterProvider();
        }

        [SetUp]
        public void Initialize()
        {
            EffortProviderFactory.ResetDb();
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }
    }
}
