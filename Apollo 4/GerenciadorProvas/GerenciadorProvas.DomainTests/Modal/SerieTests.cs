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
    public class SerieTests
    {
    
 
        [TestMethod()] 
        public void valida_serie_obrigatorio_ter_um_grau_test()
        {

            Serie s = new Serie();
            Assert.ThrowsException<ValidacoesExcepection>(() => s.Validacoes());
        }

        [TestMethod()]
        public void valida_serie_nao_deve_ter_9_caracteres_test()
        {

            Serie s = new Serie();
            s.Grau = 12;
            Assert.ThrowsException<ValidacoesExcepection>(() => s.Validacoes());
        }
    }
}