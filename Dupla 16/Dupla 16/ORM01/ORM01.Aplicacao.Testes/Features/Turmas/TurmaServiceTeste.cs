using FluentAssertions;
using Moq;
using NUnit.Framework;
using ORM01.Aplicacao.Features.Turmas;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Turmas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Aplicacao.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaServiceTeste
    {
        Mock<Turma> _turma;
        Mock<ITurmaRepository> _repository;
        TurmaService _turmaService;

        [SetUp]
        public void SetUpAvaliacaoService()
        {
            _repository = new Mock<ITurmaRepository>();
            _turmaService = new TurmaService(_repository.Object);
            _turma = new Mock<Turma>();
        }

        [Test]
        public void ApplService_Turma_Deve_Incluir_Novo_Turma()
        {

            _repository.Setup(x => x.Add(_turma.Object));
            _turma.Setup(x => x.Validar());

             _turmaService.Add(_turma.Object);
            _repository.Verify(x => x.Add(_turma.Object));
            _turma.Verify(x => x.Validar());
        }


        [Test]
        public void ApplService_Turma_Deve_Deletar_Turma()
        {

            _repository.Setup(x => x.Delete(_turma.Object));

            _turmaService.Delete(_turma.Object);

            _repository.Verify(x => x.Delete(_turma.Object));

        }

        [Test]
        public void ApplService_Turma_DeveAtualizarUmTurma()
        {
            _repository.Setup(x => x.Update(_turma.Object));
            _turma.Setup(x => x.Validar());
            _turmaService.Update(_turma.Object);
                
            _repository.Verify(x => x.Update(_turma.Object));
            _turma.Verify(x => x.Validar());
        }

        [Test]
        public void ApplService_Turma_DeveListarTodosTurmas()
        {
            List<Turma> turmaLista = ObjectMother.turmaList;
            _repository.Setup(x => x.GetAll()).Returns(turmaLista);

            List<Turma> turmaList = _turmaService.GetAll();

            _repository.Verify(x => x.GetAll());
            turmaList.Should().NotBeNull();
            turmaList.Should().HaveCount(3);
        }

        [Test]
        public void ApplService_Turma_RetornarUmaTurma()
        {
            Turma aluno = ObjectMother.Turma;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(aluno);

            Turma avaliacaoResult = _turmaService.GetById(aluno.Id);

            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            avaliacaoResult.Should().NotBeNull();
            avaliacaoResult.Id.Should().Be(aluno.Id);
        }
    }
}
