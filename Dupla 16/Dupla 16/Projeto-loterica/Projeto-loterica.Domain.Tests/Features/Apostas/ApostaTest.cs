using FluentAssertions;
using NUnit.Framework;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Concursos;
using Projeto_loterica.Domain.Features.Enums;
using Projeto_loterica.Domain.Features.Exceptions;
using System;

namespace Projeto_loterica.Domain.Tests.Features.Apostas
{
    [TestFixture]
    public class ApostaTest
    {
        Aposta aposta;
        Concurso concurso;
        [SetUp]
        public void setTime()
        {
            aposta = new Aposta();
            concurso = ObjectMother.ConcursoValido;
        }
        [Test]
        public void ApostaValidaSucess()
        {
            for (int i = 0; i < 6; i++)
            {
                aposta.Numeros.Add(i + 1);
            }
            aposta.Resultado = Vencedora.Mega;
            aposta.ValorRecebido = 100.00;
            aposta.Validar();
        }


        [Test]
        public void Test_Aposta_Invalida_Não__BeOk()
        {
            aposta.Numeros.Clear();
            Action comparison = aposta.Validar;
            comparison.Should().Throw<ApostaInvalidaException>();
        }

        [Test]
        public void Test_Aposta_Invalida_BeOk()
        {
            for (int i = 0; i < 6; i++)
            {
                aposta.Numeros.Add(1);
            }
            Action comparison = aposta.Validar;
            comparison.Should().Throw<NumeroRepetidoEmApostaException>();
        }
        [Test]
        public void Test_Aposta_Convert_Number_List_To_String()
        {
            for (int i = 0; i < 6; i++)
            {
                aposta.Numeros.Add(i + 1);
            }

            var resultado = Aposta.ConversaoParaString(aposta.Numeros);
            resultado.Should().Be("1,2,3,4,5,6");
        }

        [Test]
        public void Test_Aposta_Convert_String_List_To_Number()
        {
            var resultado = Aposta.ConversaoParaLista("1,2,3,4,5,6");
            resultado.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_Aposta_Convert_String_List_To_Number_Empty()
        {
            var resultado = Aposta.ConversaoParaLista("");
            resultado.Count.Should().Be(0);
        }
        
       
    }
}
