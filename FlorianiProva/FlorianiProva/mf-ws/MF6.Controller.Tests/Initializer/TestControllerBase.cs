using NUnit.Framework;
using System.Net.Http;

namespace MF6.Controller.Tests.Initializer
{
    [TestFixture]
    public class TestControllerBase
    {
        [OneTimeSetUp]
        public void InitializeOnceTime()
        {
            // Código que executa quando os testes começam
        }

        public HttpRequestMessage GetUri(string Uri)
        {
            return new HttpRequestMessage()
            {
                RequestUri = new System.Uri(Uri)
            };
        }

    }
}