using FlorianiProva.Comum.ObjetosMae.Avaliacoes;
using FlorianiProva.Dominio.Features.Avaliações.Excecoes;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Testes.Features
{
    [TestFixture]
    public class AvaliacaoTestes
    {
        [Test]
        public void Avaliacao_Dominio_Validar_AssuntoEmBranco_DeveFalhar()
        {
            var avaliacao = AvaliacaoObjetoMae.AvaliacaoComAssuntoEmBranco();
            Action action = () => avaliacao.Validar();
            action.Should().Throw<AssuntoEmBrancoException>();
        }
    }
}
