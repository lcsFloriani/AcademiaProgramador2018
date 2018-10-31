using Enedir.MF7.Application.Mappers;
using NUnit.Framework;
using System;
using System.Net.Http;

namespace Enedir.MF7.Controller.Tests.Initializer
{
    [TestFixture]
    public class TestControllerBase
    {

        [OneTimeSetUp]
        public void InitializeOnceTime()
        {
            AutoMapperConfig.Reset();
            AutoMapperConfig.RegisterMappings();
        }

        public HttpRequestMessage GetUri(string Uri)
        {
            return new HttpRequestMessage()
            {
                RequestUri = new Uri(Uri)
            };
        }
    }
}
