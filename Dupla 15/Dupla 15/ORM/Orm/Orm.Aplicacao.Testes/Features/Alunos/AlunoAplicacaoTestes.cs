using FluentAssertions;
using Moq;
using NUnit.Framework;
using Orm.Aplicacao.Features.Alunos;
using Orm.Comum.Testes.Features;
using Orm.Dominio.Exceptions;
using Orm.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orm.Aplicacao.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoAplicacaoTestes
    {
        private Mock<IAlunoRepositorio> _alunoRepositorio;
        private Aluno _aluno;
        private AlunoServico _alunoService;

        [SetUp]
        public void SetUo()
        {
            _alunoRepositorio = new Mock<IAlunoRepositorio>();
            _aluno = new Aluno();
            _alunoService = new AlunoServico(_alunoRepositorio.Object);
        }

        [Test]
        public void Aluno_Aplicacao_Salvar_DevePassar()
        {
            var idEsperado = 1;
            _aluno = ObjectMother.AlunoValido();
            _alunoRepositorio.Setup(x => x.Salvar(_aluno)).
                Returns(new Aluno { Id = 1 });

            var alunoSalvo = _alunoService.Salvar(_aluno);

            _alunoRepositorio.Verify(x => x.Salvar(_aluno));
            alunoSalvo.Should().NotBeNull();
            alunoSalvo.Id.Should().Be(idEsperado);
            _alunoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Atualizar_DevePassar()
        {
            _aluno = ObjectMother.AlunoValido();
            var novoNome = "Lucas";
            _aluno.Nome = novoNome;
            _alunoRepositorio.Setup(x => x.Atualizar(_aluno))
                .Returns(new Aluno { Id = 2, Nome = "Lucas" });

            var alunoAtualizado = _alunoService.Atualizar(_aluno);

            _alunoRepositorio.Verify(x => x.Atualizar(_aluno));
            alunoAtualizado.Nome.Should().Be(novoNome);
            _alunoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Atualizar_IdInvalido_DeveFalhar()
        {
            var idInvalido = -40;
            _aluno = ObjectMother.AlunoValido();
            _aluno.Id = idInvalido;

            Action action = () => _alunoService.Atualizar(_aluno);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Aluno_Aplicacao_PegarTodos_DevePassar()
        {
            var totalAlunos = 2;
            var idEsperado = 3;
            var aluno = ObjectMother.AlunoValido();
            aluno.Id = idEsperado;
            var alunos = new List<Aluno>();
            alunos.Add(aluno);
            alunos.Add(ObjectMother.AlunoValido());
            _alunoRepositorio.Setup(x => x.PegarTodos())
                .Returns(alunos);

            var listaAlunos = _alunoService.PegarTodos();

            listaAlunos.Count.Should().Be(totalAlunos);
            listaAlunos.First().Id.Should().Be(idEsperado);
            _alunoRepositorio.Verify(er => er.PegarTodos());
            _alunoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_PegarPorId_DevePassar()
        {
            var id = 1;
            _alunoRepositorio.Setup(x => x.PegarPorId(1)).Returns(ObjectMother.AlunoValido());

            var alunoObtido = _alunoService.PegarPorId(id);

            alunoObtido.Id.Should().Be(id);
            _alunoRepositorio.Verify(x => x.PegarPorId(1));
            _alunoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_PegarPorId_DeveFalharIdInvalido()
        {
            Action action = () => _alunoService.PegarPorId(0);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Aluno_Aplicacao_Deletar_DeveDeletar()
        {
            var aluno = ObjectMother.AlunoValido();
            _alunoRepositorio.Setup(x => x.Deletar(aluno));

            _alunoService.Deletar(aluno);

            _alunoRepositorio.Verify(x => x.Deletar(aluno));
            _alunoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Deletar_DeveFalharIdInvalido()
        {
            var aluno = ObjectMother.AlunoValido();
            aluno.Id = 0;

            Action action = () => _alunoService.Deletar(aluno);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
