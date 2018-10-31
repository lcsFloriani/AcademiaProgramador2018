using FluentAssertions;
using NUnit.Framework;
using Projeto_loterica.Domain.Features.Concursos;
using Projeto_loterica.Domain.Features.Resultados;
using Projeto_loterica.Domain.Tests.Features.Fack;


namespace Projeto_loterica.Domain.Tests.Features.Vencedores
{
    [TestFixture]
    public class VencedoraTest
    {
        [Test]
        public void VencedoraPremioGanho() {
            Vencedor test = new Vencedor();
            test.QuantidadeGanhadores = 2;
            test.MediaDoPremio = 2;
            test.PremioGanho.Should().Be(4);
        }
    }
}
