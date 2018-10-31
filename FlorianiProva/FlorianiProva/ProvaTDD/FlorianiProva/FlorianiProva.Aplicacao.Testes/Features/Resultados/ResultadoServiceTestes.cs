using FlorianiProva.Aplicacao.Features.Resultados;
using FlorianiProva.Comum.ObjetosMae.Resultados;
using FlorianiProva.Dominio.Features.Alunos;
using FlorianiProva.Dominio.Features.Avaliações;
using FlorianiProva.Dominio.Features.Resultados;
using FlorianiProva.Dominio.Features.Resultados.Excecoes;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Aplicacao.Testes.Features.Resultados
{
    [TestFixture]
    public class ResultadoServiceTestes
    {
        private Mock<Aluno> _aluno;
        private Mock<Avaliacao> _avaliacao;
        private Mock<IResultadoRepository> _resultadoRepository;
        private Resultado _resultado;
        private ResultadoService _resultadoService;
        [SetUp]
        public void SetUp()
        {
            double nota = 10;
            _aluno = new Mock<Aluno>();
            _avaliacao = new Mock<Avaliacao>();
            _resultado = new Resultado(_avaliacao.Object, _aluno.Object, nota);
            _resultadoRepository = new Mock<IResultadoRepository>();
            _resultadoService = new ResultadoService(_resultadoRepository.Object);
        }
        [Test]
        public void Resultado_Aplicacao_Inserir_Validar_NotaInvalida_DeveFalhar()
        {
            var resultado = ResultadoObjetoMae.ResultadoComNotaNegativa();
            resultado.Aluno = _aluno.Object;
            resultado.Avaliacao = _avaliacao.Object;

            Action action = () => resultado.Validar();
            action.Should().Throw<NotaMenorQueZeroException>();
        }
        [Test]
        public void Resultado_Aplicacao_Inserir_DeveSerOk()
        {
            double nota = 10;
            var resultado = ResultadoObjetoMae.ResultadoValido();
            resultado.Aluno = _aluno.Object;
            resultado.Avaliacao = _avaliacao.Object;

            _resultadoRepository
                .Setup(ar => ar.Inserir(resultado))
                .Returns(new Resultado(_avaliacao.Object, _aluno.Object, nota) { Id = resultado.Id });


            var resultadoInserido = _resultadoService.Inserir(resultado);

            _resultadoRepository.Verify(ar => ar.Inserir(resultado));
            resultadoInserido.Id.Should().Be(resultado.Id);
        }
        [Test]
        public void Resultado_Aplicacao_Atualizar_DeveSerOk()
        {
            _resultado = ResultadoObjetoMae.ResultadoValido();

            _resultado.Aluno = _aluno.Object;
            _resultado.Avaliacao = _avaliacao.Object;
            
            double novaNota = 2;
            _resultado.Nota = novaNota;

            _resultadoRepository
                .Setup(ar => ar.Atualizar(_resultado))
                .Returns(new Resultado(_avaliacao.Object, _aluno.Object, novaNota) { Id = 1 });

            var resultadoAtualizado = _resultadoService.Atualizar(_resultado);

            _resultadoRepository.Verify(ar => ar.Atualizar(_resultado));
            resultadoAtualizado.Nota.Should().Be(novaNota);
        }
        [Test]
        public void Resultado_Aplicacao_ObterTodos_DeveSerOk()
        {
            double nota = 7;
            _resultadoRepository.Setup(ar => ar.ObterTodos())
               .Returns(new List<Resultado> { new Resultado(_avaliacao.Object, _aluno.Object, nota) { Id = 1 }, new Resultado(_avaliacao.Object, _aluno.Object, nota) { Id = 2 } });

            var avaliacao = _resultadoService.ObterTodos();

            _resultadoRepository.Verify(ar => ar.ObterTodos());
            avaliacao.Count.Should().Be(2);
            avaliacao[0].Id.Should().Be(1);
        }
        [Test]
        public void Resultado_Aplicacao_ObterPorId_DeveSerOk()
        {
            double nota = 8;
            _resultadoRepository.Setup(ar => ar.ObterPorId(1)).
                Returns(new Resultado(_avaliacao.Object, _aluno.Object, nota) { Id = 1 });
            var aluno = _resultadoService.ObterPorId(1);

            aluno.Id.Should().Be(1);
            aluno.Should().NotBeNull();
        }
        [Test]
        public void Resultado_Aplicacao_Deletar_DeveSerOk()
        {
            _resultado = ResultadoObjetoMae.ResultadoValido();

            _resultadoRepository.Setup(ar => ar.Deletar(_resultado.Id))
                .Returns(true);

            var resultado = _resultadoService.Deletar(_resultado.Id);

            _resultadoRepository.Verify(ar => ar.Deletar(_resultado.Id));
            resultado.Should().BeTrue();
        }
    }
}
