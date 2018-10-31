using FluentAssertions;
using NUnit.Framework;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Turmas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaTeste
    {
        Turma _turma;

        [SetUp]
        public void SetUpTurmaDominio()
        {
            _turma = ObjectMother.Turma;
        }

        [Test]
        public void Dominio_Turma_DeveSerValido_Ok()
        {
            Action validarCampos = () => _turma.Validar();

            validarCampos.Should().NotThrow<Exception>();
        }

        [Test]
        public void Dominio_Turma_DeveTerDescricaoValida_DeveRetornarExcessao()
        {
            _turma.Descricao = "";

            Action validarDescricao = () => _turma.Validar();

            validarDescricao.Should().Throw<DescricaoInvalidaException>();
        }
    }
}
