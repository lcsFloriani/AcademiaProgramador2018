using MF6.Domain.Base;

namespace MF6.Domain.Funcionalidades.Toners
{
    public class Toner : Entidade
    {
        public TipoTonerEnum Tipo { get; set; }
        public decimal Nivel { get; set; }

        public Toner(TipoTonerEnum tipo, decimal nivel)
        {
            Tipo = tipo;
            Nivel = nivel;
        }
        private Toner()
        {

        }
    }
}
