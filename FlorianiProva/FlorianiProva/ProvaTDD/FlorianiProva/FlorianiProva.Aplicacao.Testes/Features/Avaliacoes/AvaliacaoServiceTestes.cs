using FlorianiProva.Aplicacao.Features.Avaliacoes;
using FlorianiProva.Comum.ObjetosMae.Avaliacoes;
using FlorianiProva.Dominio.Features.Avaliações;
using FlorianiProva.Dominio.Features.Avaliações.Excecoes;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Aplicacao.Testes.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoServiceTestes
    {
        private IAvaliacaoService _avaliacaoService;
        private Mock<IAvaliacaoRepository> _avaliacaoRepository;
        private Avaliacao _avaliacao;

        [SetUp]
        public void SetUp()
        {
            _avaliacaoRepository = new Mock<IAvaliacaoRepository>();
            _avaliacaoService = new AvaliacaoService(_avaliacaoRepository.Object);
            _avaliacao = new Avaliacao();
        }
        [Test]
        public void Avaliacao_Aplicacao_Inserir_DeveSerOk()
        {
            _avaliacao = AvaliacaoObjetoMae.AvaliacaoValida();

            _avaliacaoRepository
               .Setup(ar => ar.Inserir(_avaliacao))
               .Returns(new Avaliacao { Id = _avaliacao.Id });

            var avaliacaoInserida = _avaliacaoService.Inserir(_avaliacao);

            _avaliacaoRepository.Verify(ar => ar.Inserir(_avaliacao));
            avaliacaoInserida.Id.Should().Be(_avaliacao.Id);
        }

        [Test]
        public void Avaliacao_Aplicacao_Inserir_Validar_AssuntoEmBranco_DeveFalhar()
        {
            var avaliacao = AvaliacaoObjetoMae.AvaliacaoComAssuntoEmBranco();
            Action action = () => avaliacao.Validar();
            action.Should().Throw<AssuntoEmBrancoException>();
        }
        [Test]
        public void Avaliacao_Aplicacao_Atualizar_DeveSerOk()
        {
            _avaliacao = AvaliacaoObjetoMae.AvaliacaoValida();
            string novoAssunto = "POO";
            _avaliacao.Assunto = novoAssunto;
            _avaliacaoRepository
               .Setup(ar => ar.Atualizar(_avaliacao))
               .Returns(new Avaliacao { Assunto = _avaliacao.Assunto });

            var alunoAtualizado = _avaliacaoService.Atualizar(_avaliacao);

            _avaliacaoRepository.Verify(ar => ar.Atualizar(_avaliacao));
            alunoAtualizado.Assunto.Should().Be(novoAssunto);
        }
        [Test]
        public void Avaliacao_Aplicacao_ObterTodos_DeveSerOk()
        {
            _avaliacaoRepository.Setup(ar => ar.ObterTodos())
               .Returns(new List<Avaliacao> { new Avaliacao { Id = 1 }, new Avaliacao { Id = 2 } });

            var avaliacao = _avaliacaoService.ObterTodos();

            _avaliacaoRepository.Verify(ar => ar.ObterTodos());
            avaliacao.Count.Should().Be(2);
            avaliacao[0].Id.Should().Be(1);
        }
        [Test]
        public void Avaliacao_Aplicacao_ObterPorId_DeveSerOk()
        {
            _avaliacaoRepository.Setup(ar => ar.ObterPorId(1)).
                Returns(new Avaliacao() { Id = 1, Assunto = "POO" });
            var aluno = _avaliacaoService.ObterPorId(1);

            aluno.Id.Should().Be(1);
            aluno.Should().NotBeNull();
        }
        [Test]
        public void Avaliacao_Aplicacao_Deletar_DeveSerOk()
        {
            _avaliacao = AvaliacaoObjetoMae.AvaliacaoValida();
            _avaliacaoRepository
                .Setup(ar => ar.Deletar(_avaliacao.Id))
                .Returns(true);

            var resultado = _avaliacaoService.Deletar(_avaliacao.Id);

            _avaliacaoRepository.Verify(ar => ar.Deletar(_avaliacao.Id));
            resultado.Should().BeTrue();
        }
    }
}
