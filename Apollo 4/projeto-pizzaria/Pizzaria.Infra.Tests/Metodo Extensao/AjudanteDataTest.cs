using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Infra.Metodo_Extensao;
using System;

namespace Pizzaria.Infra.Tests.Metodo_Extensao
{
    [TestFixture]
    public class AjudanteDataTest
    {
        [Test]
        public void Metodo_Extensao_AjudanteData_Deve_comparar_data_menor_que_atual_passando_uma_data_maior_que_a_atual()
        {
            //Cenario
            DateTime data = DateTime.Now;
            //Ação
            bool response = data.CompararDataMenorQueAtual();
            //Saída
            response.Should().BeFalse();
        }

        [Test]
        public void Metodo_Extensao_AjudanteData_Deve_comparar_data_menor_que_atual_falhando_com_uma_data_menor_que_a_atual()
        {
            //Cenario
            DateTime data = DateTime.Now.AddDays(-2);
            //Ação
            bool response = data.CompararDataMenorQueAtual();
            //Saída
            response.Should().BeTrue();
        }

        [Test]
        public void Metodo_Extensao_AjudanteData_Deve_compara_data_com_data_atual_retorna_diferenca()
        {
            //Cenario
            DateTime data = DateTime.Now.AddDays(-2);
            int maiorQue = 0;
            //Ação
            DateTime time = data.CompararDataComDataAtualRetornarDiferenca();
            //Saída
            time.Minute.Should().Be(maiorQue);
        }
    }
}
