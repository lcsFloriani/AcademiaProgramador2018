using FluentAssertions;
using NUnit.Framework;
using Projeto_loterica.Domain.Features.Resultados;
using Projeto_loterica.Domain.Tests.Features.Fack;

namespace Projeto_loterica.Domain.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoTest
    {
        [Test]
        public void GerarResultado_Should_BeOk() {
            Resultado resultado;
            resultado = new Resultado(new FakeRandom());
            resultado.numeros[0].Should().NotBe(resultado.numeros[1]);
        }
        [Test]
        public void GerarResultado_Convert_to_string_Should_BeOk()
        {
            Resultado resultado = (Resultado)"1,2,3,4,5,6";
            resultado.numeros[0].Valor.Should().Be(1);
        }
        [Test]
        public void Convert_string_EmptyString_to_GerarResultado_Should_BeOk()
        {
            Resultado resultado = (Resultado)"";
            for (int s = 0; s < resultado.numeros.Length; s++)
            {
                resultado.numeros[s].Should().BeNull();
            }
        }
        [Test]
        public void Convert_string_to_GerarResultado_Should_BeOk()
        {
            string numeros = "1,2,3,4,5,6";
            Resultado resultado = (Resultado)numeros;
            string DevolveResultado = (string)resultado;
            DevolveResultado.Should().Be(numeros);
        }

        [Test]
        public void Resultado_ToString()
        {
            Resultado resultado;
            resultado = new Resultado(new FakeRandom());
            resultado.numeros[0].Should().NotBe(resultado.numeros[1]);
            string stringResultado = resultado.ToString();
            stringResultado.Should().Be((string)resultado);
        }
    }
}