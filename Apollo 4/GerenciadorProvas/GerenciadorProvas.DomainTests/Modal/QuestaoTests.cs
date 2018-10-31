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
    public class QuestaoTests
    {
        [TestMethod()]
        public void CampoEnunciadoObrigatorio()
        {
            var q = new Questao();

            Assert.ThrowsException<ValidacoesExcepection>(() => q.Validacoes());
        }
        [TestMethod()]
        public void CampoMaiorQue3Caracteres()
        {
            var q = new Questao();
            q.Enunciado = "uio";

            Assert.ThrowsException<ValidacoesExcepection>(() => q.Validacoes());
        }
        [TestMethod()]
        public void CampoMenorQue500Caracteres()
        {
            var q = new Questao();
            q.Enunciado = "12345678901234567890";

            Assert.ThrowsException<ValidacoesExcepection>(() => q.Validacoes());
        }
        [TestMethod()]
        public void MateriaNull()
        {
            var q = new Questao();
            q.Materia = null;

            Assert.ThrowsException<ValidacoesExcepection>(() => q.Validacoes());
        }
        [TestMethod()]
        public void RemocaoEspacosDesnecessarios()
        {
            var q = new Questao();
            q.Enunciado = "          ";

            Assert.ThrowsException<ValidacoesExcepection>(() => q.Validacoes());
        }
        
    }
}