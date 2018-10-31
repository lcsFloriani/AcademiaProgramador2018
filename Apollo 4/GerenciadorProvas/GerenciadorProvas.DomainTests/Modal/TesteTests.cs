using Microsoft.VisualStudio.TestTools.UnitTesting;
using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorProvas.Dominio.Exceptions;

namespace GerenciadorProvas.Dominio.Modal.Tests
{
    [TestClass()]
    public class TesteTests
    {
        [TestMethod()]
        public void teste_titulo_null()
        {
            var t = new Teste();
            t.Titulo = null;

            Assert.ThrowsException<ValidacoesExcepection>(() => t.Validacoes());
        }

        [TestMethod()]
        public void teste_titulo_menor_5_caracteres()
        {
            var t = new Teste();
            t.Titulo = "kkkkk";

            Assert.ThrowsException<ValidacoesExcepection>(() => t.Validacoes());
        }
        [TestMethod()]
        public void teste_titulo_maior_50_caracteres()
        {
            var t = new Teste();
            t.Titulo = "kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk";

            Assert.ThrowsException<ValidacoesExcepection>(() => t.Validacoes());
        }

        [TestMethod()]
        public void teste_lista_questao_maior_30_questoes()
        {
            var t = new Teste();
            for (int i = 0; i == 30; i++)
            {

                t.Questoes.Add(new Questao());
            }

            Assert.ThrowsException<ValidacoesExcepection>(() => t.Validacoes());
        }

        [TestMethod()]
        public void teste_lista_questao_menor_1_questao()
        {
            var t = new Teste();
                        
            Assert.ThrowsException<ValidacoesExcepection>(() => t.Validacoes());
        }

        [TestMethod()]
        public void teste_materia_null()
        {
            var t = new Teste();
            t.Cadeira = null;

            Assert.ThrowsException<ValidacoesExcepection>(() => t.Validacoes());
        }


    }
}