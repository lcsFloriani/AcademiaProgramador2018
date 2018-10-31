using FluentAssertions;
using NUnit.Framework;
using Orm.Comum.Testes.Features;
using Orm.Dominio.Features.Alunos;
using System;

namespace Orm.Dominio.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoTestes
    {
        private Aluno _aluno;

        [SetUp]
        public void SetUp()
        {
            _aluno = new Aluno();
        }

        [Test]
        public void Aluno_Dominio_Validar_NaoDeveFalhar()
        {
            _aluno = ObjectMother.AlunoValido();

            Action action = () => _aluno.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Aluno_Dominio_Validar_NomeEmBranco_DeveFalhar()
        {
            _aluno = ObjectMother.AlunoNomeEmBranco();

            Action action = () => _aluno.Validar();

            action.Should().Throw<AlunoNomeEmBrancoException>();
        }

        [Test]
        public void Aluno_Dominio_Validar_DataEmBranco_DeveFalhar()
        {
            _aluno = ObjectMother.AlunoDataDeNascimentoInvalida();

            Action action = () => _aluno.Validar();

            action.Should().Throw<AlunoDataNascimentoInvalidaException>();
        }
    }
}
