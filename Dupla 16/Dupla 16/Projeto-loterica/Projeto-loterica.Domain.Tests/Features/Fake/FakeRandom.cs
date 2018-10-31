using System;

namespace Projeto_loterica.Domain.Tests.Features.Fack
{
    public class FakeRandom : Random
    {
        public int chamadas = 0;
        public override int Next(int minValue, int maxValue)
        {
            if (chamadas < 2)
            {
                chamadas++;
                return 10;
            }
            return base.Next(minValue, maxValue);
        }
    }
}
