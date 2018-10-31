using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Infra.CNPJs;
using System;

namespace Pizzaria.Infra.Tests.CNPJs
{
    [TestFixture]
    public class CnpjTest
    {
        [Test]
        public void CNPJs_Infra_Validar_cnpj_com_todos_os_campos_validos()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.ObterCnpj();

            //Ação
            Action action = cnpj.Validar;

            //Sáida
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void CNPJs_Infra_Validar_cnpj_com_valor_nulo_ou_vazio()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.ObterCnpjComValorNuloOuVazio();

            //Ação
            Action action = cnpj.Validar;

            //Sáida
            action.Should().Throw<CnpjValorNuloOuVazioExcecao>();
        }


        [Test]
        public void CNPJs_Infra_Validar_cnpj_com_valor_invalido()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.ObterCnpjComValorInvalido();

            //Ação
            Action action = cnpj.Validar;

            //Sáida
            action.Should().Throw<CnpjValorInvalidoExcecao>();
        }

        [Test]
        public void CNPJs_Infra_Validar_cnpj_com_valor_incorreto()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.ObterCnpjComValorIncorreto();

            //Ação
            Action action = cnpj.Validar;

            //Sáida
            action.Should().Throw<CnpjValorInvalidoExcecao>();
        }

        [Test]
        public void CNPJs_Infra_Validar_cnpj_com_valor_menor_que_catorze()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.ObterCnpjComValorMenorQueCatorze();

            //Ação
            Action action = cnpj.Validar;

            //Sáida
            action.Should().Throw<CnpjValorMenorQueCatorzeExcecao>();
        }

        [Test]
        public void CNPJs_Infra_Validar_cnpj_com_valor_igual_zero()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.ObterCnjComValorIgualZero();

            //Ação
            Action action = cnpj.Validar;

            //Sáida
            action.Should().Throw<CnpjValorIgualZeroExcecao>();
        }

        [Test]
        public void CNPJs_Infra_Validar_cnpj_com_valor_over_flow()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.ObterCnpjOverFlow();

            //Ação
            Action action = cnpj.Validar;

            //Sáida
            action.Should().Throw<CnpjValorOverFlowExcecao>();
        }

        [Test]
        public void CNPJs_Infra_Remover_mascara_do_cnpj()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.ObterCnpj();
            string cnpjEsperado = "08671696000190";

            //Ação
            cnpj.Validar();

            //Sáida
            cnpj.Valor.Should().Be(cnpjEsperado);
        }

        [Test]
        public void CNPJs_Infra_Formatar_valor_do_cnpj()
        {
            //Cenario
            Cnpj cnpj = ObjectMother.ObterCnpj();
            string cnpjEsperado = "08.671.696/0001-90";

            //Ação
            string res = cnpj.ValorFormatado;

            //Sáida
            res.Should().Be(cnpjEsperado);
        }
    }
}
