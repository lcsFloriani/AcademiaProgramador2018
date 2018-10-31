using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FlorianiProva.Dominio.Features.Avaliações;
using FlorianiProva.Infra.Data.Features.Avaliacoes;
using FlorianiProva.Comum.Base;
using FlorianiProva.Comum.ObjetosMae.Avaliacoes;
using FluentAssertions;
using FlorianiProva.Dominio.Exceções;

namespace FlorianiProva.Infra.Data.Testes.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoRepositoryTestes
    {
        private IAvaliacaoRepository _avaliacaoRepository;
        private Avaliacao _avaliacao;

        [SetUp]
        public void SetUp()
        {
            _avaliacaoRepository = new AvaliacaoRepository();
            _avaliacao = new Avaliacao();
        }
        [Test]
        public void Avaliacao_InfraData_Inserir_EsperadoOK()
        {
            BaseSqlTeste.SemearBanco();

            _avaliacao = AvaliacaoObjetoMae.AvaliacaoValida();

            var avaliacaoInserido = _avaliacaoRepository.Inserir(_avaliacao);

            avaliacaoInserido.Should().NotBeNull();
        }
        [Test]
        public void Avaliacao_InfraData_Atualizar_EsperandoOk()
        {
            BaseSqlTeste.SemearBanco();

            _avaliacao = AvaliacaoObjetoMae.AvaliacaoValida();
            _avaliacao.Assunto = "TDD";
            var avaliacaoAtualizado = _avaliacaoRepository.Atualizar(_avaliacao);

            avaliacaoAtualizado.Should().NotBeNull();
            avaliacaoAtualizado.Assunto.Should().Be(_avaliacao.Assunto);
        }
        [Test]
        public void Avaliacao_InfraData_Deletar_EsperadoOK()
        {

            BaseSqlTeste.SemearBanco();

            _avaliacao.Id = 1;

            bool deletado = _avaliacaoRepository.Deletar(_avaliacao.Id);

            deletado.Should().BeTrue();
        }

        [Test]
        public void Avaliacao_InfraData_PegarPorID_EsperadoOK()
        {
            BaseSqlTeste.SemearBanco();
            _avaliacao.Id = 1;

            var avaliacao = _avaliacaoRepository.ObterPorId(_avaliacao.Id);

            avaliacao.Should().NotBeNull();
            avaliacao.Id.Should().Be(_avaliacao.Id);
        }

        [Test]
        public void Avaliacao_InfraData_PegarTodos_EsperadoOK()
        {
            BaseSqlTeste.SemearBanco();

            var listaEnderecos = _avaliacaoRepository.ObterTodos();

            listaEnderecos.Should().NotBeNull();
            listaEnderecos.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void Avaliacao_InfraData_Deletar_IdNegativo_EsperandoFalha()
        {
            var avaliacao = AvaliacaoObjetoMae.AvaliacaoValida();
            avaliacao.Id = -1;
            Action action = () => _avaliacaoRepository.Deletar(avaliacao.Id);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
        [Test]
        public void Avaliacao_InfraData_Deletar_IdInexistente_EsperandoFalha()
        {
            var avaliacao = AvaliacaoObjetoMae.AvaliacaoValida();
            avaliacao.Id = 9998;
            var deletado = _avaliacaoRepository.Deletar(avaliacao.Id);
            deletado.Should().BeFalse();
        }
    }
}
