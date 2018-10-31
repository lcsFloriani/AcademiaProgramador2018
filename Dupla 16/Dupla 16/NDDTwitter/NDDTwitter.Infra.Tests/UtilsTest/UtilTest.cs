using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;


namespace NDDTwitter.Infra.Tests.UtilsTest
{
    [TestFixture]
    public class UtilTest
    {
        DateTime time;
        [SetUp]
        public void setTime()
        {
            time = DateTime.Now;
        }
        [Test]
        public void DeveRetornar1minuto()
        {
            time = time.AddMinutes(-1);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("1 Minuto atrás");
        }

        [Test]
        public void DeverRetornar2minuto()
        {
            time = time.AddMinutes(-2);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("2 Minutos atrás");
        }
        [Test]
        public void DeverRetornar30minuto()
        {
            time = time.AddMinutes(-30);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("30 Minutos atrás");
        }
        [Test]
        public void DeverRetornar1Hora()
        {
            time = time.AddHours(-1);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("1 Hora atrás");
        }
        [Test]
        public void DeverRetornar2Hora()
        {
            time = time.AddHours(-2);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("2 Horas atrás");
        }

        [Test]
        public void DeverRetornar1Dia()
        {
            time = time.AddDays(-1);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("1 Dia atrás");
        }

        [Test]
        public void DeverRetornar2Dias()
        {
            time = time.AddDays(-2);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("2 Dias atrás");
        }
        [Test]
        public void DeverRetornar1Semana()
        {
            time = time.AddDays(-7);
            time = time.AddHours(-1);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("1 Semana atrás");
        }

        [Test]
        public void DeverRetornar2Semanas()
        {
            time = time.AddDays(-14);
            time = time.AddHours(-2);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("2 Semanas atrás");
        }

        [Test]
        public void DeverRetornar1Mes()
        {
            time = time.AddDays(-30);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("1 Mês atrás");
        }

        [Test]
        public void DeverRetornar2Mes()
        {
            time = time.AddDays(-60);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("2 Meses atrás");
        }

        [Test]
        public void DeverRetornar1Ano()
        {
            time = time.AddYears(-1);
            time = time.AddHours(-4);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("1 Ano atrás");
        }

        [Test]
        public void DeverRetornar2Anos()
        {
            time = time.AddYears(-2);
            time = time.AddHours(-4);
            string expectedResult = time.DiferencaDeTempo();
            expectedResult.Should().Be("2 Anos atrás");
        }

    }
}
