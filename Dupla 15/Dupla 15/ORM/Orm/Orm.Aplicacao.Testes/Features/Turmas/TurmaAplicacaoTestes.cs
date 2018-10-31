using FluentAssertions;
using Moq;
using NUnit.Framework;
using Orm.Aplicacao.Features.Turmas;
using Orm.Comum.Testes.Features;
using Orm.Dominio.Exceptions;
using Orm.Dominio.Features.Turmas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orm.Aplicacao.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaAplicacaoTestes
    {
        private Turma _turma;
        private Mock<ITurmaRepositorio> _turmaRepositorio;
        private TurmaServico _servico;

        [SetUp]
        public void SetUp()
        {
            _turma = new Turma();
            _turmaRepositorio = new Mock<ITurmaRepositorio>();
            _servico = new TurmaServico(_turmaRepositorio.Object);
        }

        [Test]
        public void Turma_Aplicacao_Salvar_DevePassar()
        {
            var idEsperado = 1;
            _turma = ObjectMother.TurmaValida();
            _turmaRepositorio.Setup(x => x.Salvar(_turma)).Returns(new Turma() { Id = 1 });

            var turmaInserida = _servico.Salvar(_turma);

            turmaInserida.Id.Should().Be(idEsperado);
            _turmaRepositorio.Verify(x => x.Salvar(_turma));
            _turmaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_Atualizar_DevePassar()
        {
            _turma = ObjectMother.TurmaValida();
            var valorEsperado = "Turma da Academia";
            _turma.Descricao = valorEsperado;
            _turmaRepositorio.Setup(x => x.Atualizar(_turma)).Returns(new Turma() { Id = 2, Descricao = "Turma da Academia" });

            var turmaAtualizada = _servico.Atualizar(_turma);

            turmaAtualizada.Descricao.Should().Be(valorEsperado);
            _turmaRepositorio.Verify(x => x.Atualizar(_turma));
            _turmaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_Atualizar_DeveFalharIdInvalido()
        {
            _turma = ObjectMother.TurmaValida();
            _turma.Id = 0;

            Action action = () => _servico.Atualizar(_turma);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Turma_Aplicacao_PegarTodos_DevePassar()
        {
            var totalTurma = 2;
            var idEsperado = 3;
            var turma = ObjectMother.TurmaValida();
            turma.Id = idEsperado;
            var turmas = new List<Turma>();
            turmas.Add(turma);
            turmas.Add(ObjectMother.TurmaValida());
            _turmaRepositorio.Setup(x => x.PegarTodos())
                .Returns(turmas);

            var listaTurma = _servico.PegarTodos();

            listaTurma.Count.Should().Be(totalTurma);
            listaTurma.First().Id.Should().Be(idEsperado);
            _turmaRepositorio.Verify(x => x.PegarTodos());
            _turmaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_PegarPorId_DevePassar()
        {
            var id = 1;
            _turmaRepositorio.Setup(x => x.PegarPorId(id))
                .Returns(ObjectMother.TurmaValida());

            var turmaObtida = _servico.PegarPorId(id);

            turmaObtida.Id.Should().Be(id);
            _turmaRepositorio.Verify(x => x.PegarPorId(id));
            _turmaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_PegarPorId_DeveFalharIdInvalido()
        {
            Action action = () => _servico.PegarPorId(0);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Turma_Aplicacao_Deletar_DeveDeletar()
        {
            var turma = ObjectMother.TurmaValida();
            _turmaRepositorio.Setup(x => x.Deletar(turma));

            _servico.Deletar(turma);

            _turmaRepositorio.Verify(x => x.Deletar(turma));
            _turmaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_Deletar_DeveFalharIdInvalido()
        {
            var turma = ObjectMother.TurmaValida();
            turma.Id = 0;

            Action action = () => _servico.Deletar(turma);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
