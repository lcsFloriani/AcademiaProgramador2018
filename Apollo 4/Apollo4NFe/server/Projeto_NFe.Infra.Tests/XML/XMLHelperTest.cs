using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Tests.XML
{
    [TestFixture]
    public class XMLHelperTest
    {

        [Test]
        public void XML_Infra_Serialize_ShouldSerializeWithSuccess()
        {
            //Cenario
            Product p = ObjectMother.GetProduct();
            XMLHelper<Product> _xmlHelper = new XMLHelper<Product>();
            //Ação
            string xml = _xmlHelper.Serialize(p);
            //Saída
            xml.Should().NotBeEmpty();
        }


        [Test]
        public void XML_Infra_Deserialize_ShouldDeserializeWithSuccess()
        {
            //Cenario
            Product p = ObjectMother.GetProduct();
            XMLHelper<Product> _xmlHelper = new XMLHelper<Product>();
            string xml = _xmlHelper.Serialize(p);
            //Ação
            Product result = _xmlHelper.Deserialize(xml); ;
            //Saída
            result.Should().NotBeNull();
        }
    }
}
