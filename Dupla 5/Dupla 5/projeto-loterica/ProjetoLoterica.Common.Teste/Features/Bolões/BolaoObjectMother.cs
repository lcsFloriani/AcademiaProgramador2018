using ProjetoLoterica.Dominio.Features.Boloes;

namespace ProjetoLoterica.Common.Teste.Features.Bolões
{
    public static class BolaoObjectMother
    {
        public static Bolao CriaBolaoValido()
        {
            return new Bolao
            {
                Id = 2,
                Numero = 123
            };
        }

        public static Bolao CriaBolaoInvalidoNumeroInvalido()
        {
            return new Bolao
            {
                Id = 2,
                Numero = -123
            };
        }

        public static Bolao CriaBolaoInvalidoIdInvalido()
        {
            return new Bolao
            {
                Id = -2,
                Numero = -123
            };
        }
    }
}
