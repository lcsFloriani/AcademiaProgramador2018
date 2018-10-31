using System;

namespace Projeto_loterica.Domain.Tests.Features.Concursos
{
    public class FakeRandom : Random
    {
        int retornos=0;
        public override int Next(int minValue, int maxValue)
        {
            retornos++;
            return retornos;
        }
    }
}
