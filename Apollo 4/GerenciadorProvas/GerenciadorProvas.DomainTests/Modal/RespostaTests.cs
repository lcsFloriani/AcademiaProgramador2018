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
    public class RespostaTests
    {
        [TestMethod()]
        public void validacoes_Respostas()
        {
            var r = new Resposta();

            Assert.ThrowsException<ValidacoesExcepection>(() => r.Validacoes());
        }

        [TestMethod()]
        public void valida_resposta_maior_1_caracteres_test()
        {
            var r = new Resposta();
            r.Descricao = "u";

            Assert.ThrowsException<ValidacoesExcepection>(() => r.Validacoes());
        }

        [TestMethod()]
        public void valida_resposta_menor_100_caracteres_test()
        {
            var r = new Resposta();
            r.Descricao = "uqwertyuiopasdfghjklzxcvbnm,";

            Assert.ThrowsException<ValidacoesExcepection>(() => r.Validacoes());
        }

        [TestMethod()]
        public void valida_resposta_nao_pode_ser_igual_null()
        {
            var r = new Resposta();
            r.Descricao = null;

            Assert.ThrowsException<ValidacoesExcepection>(() => r.Validacoes());
        }

        
    }
}