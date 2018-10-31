using System;
using NUnit.Framework;
using FlorianiProva.Aplicacao.Features.Alunos;
using Moq;
using FlorianiProva.Comum.ObjetosMae.Alunos;
using FluentAssertions;
using FlorianiProva.Dominio.Features.Alunos;
using FlorianiProva.Dominio.Features.Alunos.Excecoes;
using System.Collections.Generic;

namespace FlorianiProva.Aplicacao.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoServiceTestes
    {
        private Aluno _aluno;
        private IAlunoService _alunoService;
        private Mock<IAlunoRepository> _alunoRepository;
        [SetUp]
        public void SetUp()
        {
            _aluno = new Aluno();
            _alunoRepository = new Mock<IAlunoRepository>();
            _alunoService = new AlunoService(_alunoRepository.Object);
        }
        [Test]
        public void Aluno_Aplicacao_Inserir_DeveSerOk()
        {
            _aluno = AlunoObjetoMae.AlunoValido();

            _alunoRepository
               .Setup(ar => ar.Inserir(_aluno))
               .Returns(new Aluno { Nome = _aluno.Nome });

            var alunoInserido = _alunoService.Inserir(_aluno);

            _alunoRepository.Verify(ar => ar.Inserir(_aluno));
            alunoInserido.Nome.Should().Be(_aluno.Nome);
        }
        [Test]
        public void Aluno_Aplicacao_Inserir_Validar_NomeEmBranco_DeveFalhar()
        {
            var aluno = AlunoObjetoMae.AlunoComNomeEmBranco();
            Action action = () => aluno.Validar();
            action.Should().Throw<NomeEmBrancoException>();
        }
        [Test]
        public void Aluno_Aplicacao_Inserir_Validar_IdadeNegativa_DeveFalhar()
        {
            var aluno = AlunoObjetoMae.AlunoComIdadeNegativa();
            Action action = () => aluno.Validar();
            action.Should().Throw<IdadeNegativaException>();
        }
        [Test]
        public void Aluno_Aplicacao_Inserir_Validar_NomeMaiorQue150Caracteres_DeveFalhar()
        {
            var aluno = AlunoObjetoMae.AlunoComNomeMuitoGrande();
            Action action = () => aluno.Validar();
            action.Should().Throw<NomeMuitoGrandeException>();
        }
        [Test]
        public void Aluno_Aplicacao_Atualizar_DeveSerOk()
        {
            _aluno = AlunoObjetoMae.AlunoValido();
            int novaIdade = 25;
            _aluno.Idade = novaIdade;
            _alunoRepository
               .Setup(ar => ar.Atualizar(_aluno))
               .Returns(new Aluno { Id = 20, Nome = _aluno.Nome, Idade = novaIdade });

            var alunoAtualizado = _alunoService.Atualizar(_aluno);

            _alunoRepository.Verify(ar => ar.Atualizar(_aluno));
            alunoAtualizado.Id.Should().Be(_aluno.Id);
            alunoAtualizado.Idade.Should().Be(novaIdade);
        }
        [Test]
        public void Aluno_Aplicacao_ObterTodos_DeveSerOk()
        {
            _alunoRepository.Setup(ar => ar.ObterTodos())
               .Returns(new List<Aluno> { new Aluno { Id = 1 }, new Aluno { Id = 2 } });

            IList<Aluno> alunos = _alunoService.ObterTodos();

            _alunoRepository.Verify(ar => ar.ObterTodos());
            alunos.Count.Should().Be(2);
            alunos[0].Id.Should().Be(1);
        }
        [Test]
        public void Aluno_Aplicacao_ObterPorId_DeveSerOk()
        {
            _alunoRepository.Setup(ar => ar.ObterPorId(1)).
                Returns(new Aluno() { Id = 1, Nome = "Lucas"});
            var aluno = _alunoService.ObterPorId(1);

            aluno.Id.Should().Be(1);
            aluno.Should().NotBeNull();
        }
        [Test]
        public void Aluno_Aplicacao_Deletar_DeveSerOk()
        {
            _aluno = AlunoObjetoMae.AlunoValido();
            _alunoRepository
                .Setup(er => er.Deletar(_aluno.Id))
                .Returns(true);

            var resultado = _alunoService.Deletar(_aluno.Id);

            _alunoRepository.Verify(ar => ar.Deletar(_aluno.Id));
            resultado.Should().BeTrue();
        }
    }
}
