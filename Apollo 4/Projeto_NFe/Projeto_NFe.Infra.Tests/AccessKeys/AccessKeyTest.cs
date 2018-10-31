using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Infra.AccessKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Tests.AccessKeys
{
    [TestFixture]
    public class AccessKeyTest
    {
        [Test]
        public void AccessKeys_Infra_Validate_ShouldValidateSuccess()
        {
            //Cenario
            AccessKey accessKey = ObjectMother.GetAccessKey();

            //Ação
            Action actionExecute = accessKey.Validate;

            //Sáida
            actionExecute.Should().NotThrow<Exception>();
        }

        [Test]
        public void AccessKeys_Infra_Validate_ShouldThrowNumberLessThanFortyFourCharactersException()
        {
            //Cenario
            AccessKey accessKey = ObjectMother.GetAccessKeyNumberLessThanFortyFourCharacters();

            //Ação
            Action actionExecute = accessKey.Validate;

            //Sáida
            actionExecute.Should().Throw<AccessKeyNumberLessThanFortyFourCharactersException>();
        }

        [Test]
        public void AccessKeys_Infra_CreateNumberKey_ShouldCreateNumberKeyWithSuccess()
        {
            //Cenario
            AccessKey accessKey = new AccessKey();

            //Ação
            accessKey.CreateNumberKey();

            //Sáida
            accessKey.NumberAccessKey.Count().Should().Be(44);
        }
    }
}
