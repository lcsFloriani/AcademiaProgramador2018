using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Products
{
    [TestFixture]
    public class ProductTest
    {
      
        [Test]
        public void Products_Domain_Aliquot_ShouldAliquotWithSuccess()
        {
            //Cenário
            double icms = 0.04;
            double ipi = 0.1;

            //Ação
            Product p = new Product();

            //Saída
            p.AliquotICMS.Should().Be(icms);
            p.AliquotIPI.Should().Be(ipi);
        }
    }
}
