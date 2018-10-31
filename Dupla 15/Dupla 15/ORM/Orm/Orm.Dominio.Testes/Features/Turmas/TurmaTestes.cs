using FluentAssertions;
using NUnit.Framework;
using Orm.Comum.Testes.Features;
using Orm.Dominio.Exceptions;
using Orm.Dominio.Features.Turmas;
using System;

namespace Orm.Dominio.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaTestes
    {
        private Turma _turma;
        [SetUp]
        public void SetUp()
        {
            _turma = new Turma();
        }
        [Test]
        public void Turma_Dominio_Validar_DescricaoEmBranco_DeveFalhar()
        {
            _turma = ObjectMother.TurmaComDescricaoEmBranco();
            Action action = () => _turma.Validar();
            action.Should().Throw<TurmaDescricaoVaziaException>();
        }
        [Test]
        public void Turma_Dominio_DevePassar()
        {
            _turma = ObjectMother.TurmaValida();
            Action action = () => _turma.Validar();
            action.Should().NotThrow<BusinessException>();
        }
    }
}
