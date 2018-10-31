using FluentAssertions;
using Moq;
using NUnit.Framework;
using ORM01.Aplicacao.Features.Alunos;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Alunos;
using System.Collections.Generic;

namespace ORM01.Aplicacao.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoServiceTeste
    {
        Mock<Aluno> _aluno;
        Mock<IAlunoRepository> _repository;
        AlunoService _alunoService;

        [SetUp]
        public void SetUpAvaliacaoService()
        {
            _repository = new Mock<IAlunoRepository>();
            _alunoService = new AlunoService(_repository.Object);
            _aluno = new Mock<Aluno>();
        }

        [Test]
        public void ApplService_Aluno_Deve_Incluir_Novo_Aluno()
        {
            _repository.Setup(x => x.Add(_aluno.Object));
            _aluno.Setup(x => x.Validar());
             _alunoService.Add(_aluno.Object);

            _repository.Verify(x => x.Add(_aluno.Object));
            _aluno.Verify(x => x.Validar());
        }


        [Test]
        public void ApplService_Aluno_Deve_Deletar_Aluno()
        {
            _repository.Setup(x => x.Delete(_aluno.Object));

            _alunoService.Delete(_aluno.Object);

            _repository.Verify(x => x.Delete(_aluno.Object));
        }

        [Test]
        public void ApplService_Aluno_deve_Atualizar_Um_Aluno()
        {
            _repository.Setup(x => x.Update(_aluno.Object));
            _aluno.Setup(x => x.Validar());

            _alunoService.Update(_aluno.Object);
            
            _repository.Verify(x => x.Update(_aluno.Object));
            _aluno.Verify(x => x.Validar());
        }

        [Test]
        public void ApplService_Aluno_Deve_Listar_Todos_Alunos()
        {
            List<Aluno> alunoList = ObjectMother.alunoList;
            _repository.Setup(x => x.GetAll()).Returns(alunoList);

            List<Aluno> alunoListResult = _alunoService.GetAll();

            _repository.Verify(x => x.GetAll());
            alunoListResult.Should().NotBeNull();
            alunoListResult.Should().HaveCount(3);
        }

        [Test]
        public void ApplService_Aluno_Retornar_Um_Aluno()
        {
            Aluno aluno = ObjectMother.aluno;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(aluno);

            Aluno avaliacaoResult = _alunoService.GetById(aluno.Id);

            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            avaliacaoResult.Should().NotBeNull();
            avaliacaoResult.Id.Should().Be(aluno.Id);
        }
    }
}
