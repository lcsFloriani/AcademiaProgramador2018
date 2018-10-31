using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Infra.CPFs;
using System;

namespace Pizzaria.Infra.Tests.CPF
{
    [TestFixture]
    public class CpfTest
    {
        [Test]
        public void CPFs_Infra_Validar_cpf_com_todos_os_campos_validos()
        {
            //Cenario
            Cpf cpf = ObjectMother.ObterCpf();

            //Ação
            Action action = cpf.Validar;

            //Sáida
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void CPFs_Infra_Formatar_valor_do_cpf()
        {
            //Cenario
            Cpf cpf = ObjectMother.ObterCpf();
            string cnpjEsperado = "329.999.590-10";

            //Ação
            string res = cpf.ValorFormatado;

            //Sáida
            res.Should().Be(cnpjEsperado);
        }

        [Test]
        public void CPFs_Infra_Validar_cpf_com_valor_nulo_ou_vazio()
        {
            //Cenario
            Cpf cpf = ObjectMother.ObterCpfComValorNuloOuVazio();

            //Ação
            Action action = cpf.Validar;

            //Sáida
            action.Should().Throw<CpfValorNuloOuVazioExcecao>();
        }

        [Test]
        public void CPFs_Infra_Validar_cpf_com_valor_menor_que_onze()
        {
            //Cenario
            Cpf cpf = ObjectMother.ObterCpfComValorMenorQueOnze();

            //Ação
            Action action = cpf.Validar;

            //Sáida
            action.Should().Throw<CpfValorMenorQueOnzeExcecao>();
        }

        [Test]
        public void CPFs_Infra_Validar_cpf_com_valor_over_flow()
        {
            //Cenario
            Cpf cpf = ObjectMother.ObterCpfComValorOverFlow();

            //Ação
            Action action = cpf.Validar;

            //Sáida
            action.Should().Throw<CpfValorOverFlowExcecao>();
        }

        [Test]
        public void CPFs_Infra_Validar_cpf_com_valor_igual_zero()
        {
            //Cenario
            Cpf cpf = ObjectMother.ObterCpfComValorIgualZero();

            //Ação
            Action action = cpf.Validar;

            //Sáida
            action.Should().Throw<CpfValorIgualZeroExcecao>();
        }

        [Test]
        public void CPFs_Infra_Validar_cpf_com_valor_invalido()
        {
            //Cenario
            Cpf cpf = ObjectMother.ObterCpfComValorInvalido();

            //Ação
            Action action = cpf.Validar;

            //Sáida
            action.Should().Throw<CpfInvalidValueException>();
        }

        [Test]
        public void CPFs_Infra_Validar_cpf_com_valor_incorreto()
        {
            //Cenario
            Cpf cpf = ObjectMother.ObterCpfComValorIncorreto();

            //Ação
            Action action = cpf.Validar;

            //Sáida
            action.Should().Throw<CpfValorIncorretoExcecao>();
        }
    }
}
