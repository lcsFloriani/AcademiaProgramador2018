using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
namespace NDDTwitter.Infra.Tests
{
    [TestFixture]
    public class ConvertTest
    {
        [Test]

        public void ShouldConvertToTwoMinutesAgo()
        {
            string resultado = DateTime.Now.AddMinutes(-2).DateTimeToString();
            resultado.Should().Be("2 minutos atrás");
        }

        [Test]
        public void ShouldConvertToTwoHoursAgo()
        {
            string resultado = DateTime.Now.AddHours(-2).DateTimeToString();
            resultado.Should().Be("2 horas atrás");
        }

        [Test]
        public void ShouldConvertToTwoDaysAgo()
        {
            string resultado = DateTime.Now.AddDays(-2).DateTimeToString();
            resultado.Should().Be("2 dias atrás");
        }

        [Test]
        public void ShouldConvertToTwoWeeksAgo()
        {
            string resultado = DateTime.Now.AddDays(-14).DateTimeToString();
            resultado.Should().Be("2 semanas atrás");
        }

        [Test]
        public void ShouldConvertToTwoMonthsAgo()
        {
            string resultado = DateTime.Now.AddMonths(-3).DateTimeToString();
            resultado.Should().Be("3 meses atrás");
        }

        [Test]
        public void ShouldConvertToTwoYearsAgo()
        {
            string resultado = DateTime.Now.AddYears(-2).DateTimeToString();
            resultado.Should().Be("2 anos atrás");
        }
    }
}
