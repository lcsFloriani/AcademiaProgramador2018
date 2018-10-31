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
    public class DisciplinaTests
    {

        [TestMethod()]
        public void validacoes_test()
        {
            var d = new Disciplina();

            Assert.ThrowsException<ValidacoesExcepection>(() => d.Validacoes());
        }


        [TestMethod()]
        public void validacoes_nome_null_test()
        {

            Disciplina d = new Disciplina();
            d.Nome = null;

            Assert.ThrowsException<ValidacoesExcepection>(() => d.Validacoes());
        }

        [TestMethod()]
        public void valida_nome_maior_3_caracteres_test()
        {

            Disciplina d = new Disciplina();
            d.Nome = "uio";

            Assert.ThrowsException<ValidacoesExcepection>(() => d.Validacoes());
        }

        [TestMethod()]
        public void valida_nome_menor_25_caracteres_test()
        {

            Disciplina d = new Disciplina();
            d.Nome = "QWERTYUIOPLKJHGFDSAZXCVBN";

            Assert.ThrowsException<ValidacoesExcepection>(() => d.Validacoes());
        }

        [TestMethod()]
        public void nome_nao_pode_conter_caracter_especial_test()
        {

            Disciplina d = new Disciplina();
            d.Nome = "!@#$%¨&*)(";

            Assert.ThrowsException<ValidacoesExcepection>(() => d.Validacoes());

        }
    }
}