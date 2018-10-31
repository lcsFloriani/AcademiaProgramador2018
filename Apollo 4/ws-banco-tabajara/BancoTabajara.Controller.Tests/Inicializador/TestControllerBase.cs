using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Controller.Tests.Inicializador
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
                RequestUri = new Uri(Uri)
            };
        }
    }
}
