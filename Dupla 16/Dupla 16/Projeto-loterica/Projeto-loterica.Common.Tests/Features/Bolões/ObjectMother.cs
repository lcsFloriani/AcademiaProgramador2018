using Projeto_loterica.Domain.Features.Boloes;

namespace Projeto_loterica.Common.Tests.Features.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static Bolao BolãoValido
        {
            get
            {
                var bolao = new Bolao();
                bolao.Id = 1;
                bolao.Apostas.Add(apostaValida);
                return bolao;

            }
        }
        public static Bolao BolãoInvalido
        {
            get
            {
                var bolao = new Bolao();
                bolao.Id = 1;
                return bolao;
            }
        }
    }
}
