using BancoTabajara.Aplicacao.Mappers;
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
