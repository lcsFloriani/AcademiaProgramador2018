using FluentAssertions;
using NUnit.Framework;
using Projeto_loterica.Domain.Features.Exceptions;
using Projeto_loterica.Domain.Features.Numeros;
using System;

namespace Projeto_loterica.Domain.Tests.Features.Numeros
{
    [TestFixture]
    public class NumeroTest
    {
        Numero TestNumero;
        [SetUp]
        public void set() {
            TestNumero = 1;
        }
        [Test]
        public void Numero_implicit_Operation_int_to_Numero_ShouldBe_Ok() {
            Numero numero = 1;
            numero.Valor.Should().Be(1);
        }
        [Test]
        public void Numero_implicit_Operation_Numero_to_int_ShouldBe_Ok()
        {
            int inteiro = TestNumero;
            inteiro.Should().Be(TestNumero.Valor);
        }
        [Test]
        public void Numero_implicit_Operation_intInvalid_Fewer_Than_0_to__Number_ShouldBe_Fail()
        {
            Numero numero;
            Action alvo = () => numero = 0;
            alvo.Should().Throw<NumeroInvalidoException>();

        }
        [Test]
        public void Numero_implicit_Operation_intInvalid_More_Than_60_to__Number_ShouldBe_Fail()
        {
            Numero numero;
            Action alvo = () =>  numero = 61;
            alvo.Should().Throw<NumeroInvalidoException>();

        }

        [Test]
        public void Numero_ToString()
        {
            string numero = TestNumero.ToString();
            numero.Should().Be(TestNumero.ToString());
        }
    }
}
