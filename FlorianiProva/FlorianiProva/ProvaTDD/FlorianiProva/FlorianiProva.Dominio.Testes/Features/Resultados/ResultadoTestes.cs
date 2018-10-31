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

namespace FlorianiProva.Dominio.Testes.Features.Resultados
{
    [TestFixture]
    public class ResultadoTestes
    {
        private Resultado _resultado;
        private Mock<Aluno> _aluno;
        private Mock<Avaliacao> _avaliacao;
        [SetUp]
        public void SetUp()
        {
            double nota = 10;
            _aluno = new Mock<Aluno>();
            _avaliacao = new Mock<Avaliacao>();
            _resultado = new Resultado(_avaliacao.Object, _aluno.Object, nota);
        }

        [Test]
        public void Resultado_Dominio_Validar_NotaNegativa_DeveFalhar()
        {
            _resultado.Nota = -5;
            Action action = () => _resultado.Validar();
            action.Should().Throw<NotaMenorQueZeroException>();
        }
    }
}
