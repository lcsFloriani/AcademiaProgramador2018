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
    public class MateriaTests
    {


        [TestMethod()]
        public void validar_nome_null_test()
        {
            Materia m = new Materia();
            m.Nome = null;

            Assert.ThrowsException<ValidacoesExcepection>(() => m.Validacoes());
        }

        [TestMethod()]
        public void validar_nome_minimo_3_caracteres_test()
        {
            Materia m = new Materia();
            m.Nome = "QWE";
            Assert.ThrowsException<ValidacoesExcepection>(() => m.Validacoes());
        }

        [TestMethod()]
        public void validar_nome_maximo_25_caracteres_test()
        {
            Materia m = new Materia();
            m.Nome = "qwertyuiopasdfghjklçzxcvb";
            Assert.ThrowsException<ValidacoesExcepection>(() => m.Validacoes());
        }

        [TestMethod()]
        public void validar_nome_nao_deve_ter_caracteres_especiais_test()
        {
            Materia m = new Materia();
            m.Nome = "@#$%¨&%¨&&*";
            Assert.ThrowsException<ValidacoesExcepection>(() => m.Validacoes());
        }
        [TestMethod()]
        public void validar_materia_toda_serie_obrigatoria_tests()
        {
            Materia m = new Materia();
            m.Nome = "Marcelo";
            m.Cadeira = new Disciplina();
            m.Serie = null;

            Assert.ThrowsException<ValidacoesExcepection>(() => m.Validacoes());
        }

        public void validar_materia_toda_disciplina_obrigatoria_tests()
        {
            Materia m = new Materia();
            m.Nome = "Marcelo";
            m.Cadeira = null;
            m.Serie = new Serie();

            Assert.ThrowsException<ValidacoesExcepection>(() => m.Validacoes());
        }
    }
}