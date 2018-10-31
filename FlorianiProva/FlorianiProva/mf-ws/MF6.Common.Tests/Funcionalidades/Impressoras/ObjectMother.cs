using MF6.Domain.Funcionalidades.Impressoras;

namespace MF6.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Impressora ImpressoraValida()
        {
            var impressora = new Impressora()
            {
                Id = 1,
                Ip = "192.168.179.214",
                EmUso = true,
                Marca = "Brother"

            };
            impressora.AdicionarToner(TonerColoridoValido());
            impressora.AdicionarToner(TonerPretoBrancoValido());
            return impressora;
        }
        public static Impressora ImpressoraValidaSemId()
        {
            var impressora = new Impressora()
            {
                Ip = "192.168.179.214",
                EmUso = true,
                Marca = "X"

            };
            impressora.AdicionarToner(TonerColoridoValido());
            impressora.AdicionarToner(TonerPretoBrancoValido());
            return impressora;
        }
        public static Impressora ImpressoraSemTonerValida() => new Impressora
        {
            Id = 2,
            Ip = "192.168.1.1",
            Marca = "Hp",
            EmUso = false
        };
    }
}
