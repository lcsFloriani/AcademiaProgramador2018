using FluentAssertions;
using NUnit.Framework;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Exceptions;
using ORM01.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoTeste
    {
        Aluno _aluno;
        [SetUp]
        public void SetUpAlunoDominio()
        {
            _aluno = ObjectMother.aluno;
        }

        [Test]
        public void Dominio_Aluno_DeveSerValido_OK()
        {
            Action validarCampos = () => _aluno.Validar();

            validarCampos.Should().NotThrow<Exception>();
        }

        [Test]
        public void Dominio_Aluno_DeveTerUmNomeValido_DeveRetornarExcessao()
        {
            _aluno.Nome = "";

            Action validarNome = () => _aluno.Validar();

            validarNome.Should().Throw<NomeInvalidoException>();
        }

        [Test]
        public void Dominio_Aluno_DeveTerUmaIdadeValida_DeveRetornarExcessao()
        {
            _aluno.Aniversario = DateTime.Now.AddDays(-1);

            Action validarIdade = () => _aluno.Validar();

            validarIdade.Should().Throw<IdadeInvalidaException>();
        }

        [Test]
        public void Dominio_Aluno_DeveTerUmaTurmaValida_DeveRetornarExcessao()
        {
            _aluno.Turma = null;

            Action validarTurma = () => _aluno.Validar();

            validarTurma.Should().Throw<TurmaInvalidaException>();
        }

        [Test]
        public void Dominio_Aluno_DeveTerUmEnderecoValido_DeveRetornarExcessao()
        {
            _aluno.Endereco = null;

            Action validarEndereco = () => _aluno.Validar();

            validarEndereco.Should().Throw<EnderecoInvalidoException>();
        }
    }
}
