using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Infra.Extension_Methods;
using System;

namespace Projeto_NFe.Infra.Tests.Extension_Methods
{
    [TestFixture]
    public class DateHelperTest
    {
        [Test]
        public void DateHelper_Infra_CompareDateSmallerCurrent_ShouldCompareDateSmallerCurrentWithSuccess()
        {
            //Cenario
            DateTime date = DateTime.Now.AddDays(2);

            //Ação
            bool response = date.CompareDateSmallerCurrent();

            //Saída
            response.Should().BeFalse();
        }

        [Test]
        public void DateHelper_Infra_CompareDateSmallerCurrent_ShouldBeFail()
        {
            //Cenario
            DateTime date = DateTime.Now.AddDays(-2);

            //Ação
            bool response = date.CompareDateSmallerCurrent();

            //Saída
            response.Should().BeTrue();
        }

        [Test]
        public void DateHelper_Infra_CompareDateSmallerThan_ShouldCompareDateSmallerThanWithSuccess()
        {
            //Cenario
            DateTime date = DateTime.Now.AddDays(-2);
            DateTime date2 = DateTime.Now;

            //Ação
            bool response = date.CompareDateSmallerThan(date2);

            //Saída
            response.Should().BeFalse();
        }

        [Test]
        public void DateHelper_Infra_CompareDateSmallerThan_ShouldBeFail()
        {
            //Cenario
            DateTime date = DateTime.Now;
            DateTime date2 = DateTime.Now.AddDays(-2);

            //Ação
            bool response = date.CompareDateSmallerThan(date2);

            //Saída
            response.Should().BeTrue();
        }
    }
}
