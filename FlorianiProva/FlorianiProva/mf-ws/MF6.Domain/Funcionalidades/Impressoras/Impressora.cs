using MF6.Domain.Base;
using MF6.Domain.Excecoes;
using MF6.Domain.Funcionalidades.Toners;

namespace MF6.Domain.Funcionalidades.Impressoras
{
    public class Impressora : Entidade
    {
        public string Marca { get; set; }
        public string Ip { get; set; }
        public bool EmUso { get; set; }
        public virtual Toner TonerColorido { get; set; }
        public virtual Toner TonerPretoBranco { get; set; }
        
        public void AdicionarToner(Toner toner)
        {
            if (toner is null)
                throw new NaoEncontradoException();
            if (toner.Tipo is TipoTonerEnum.Colorido)
                TonerColorido = toner;
            else if (toner.Tipo is TipoTonerEnum.PretoBranco)
                TonerPretoBranco = toner;
        }
        public void Validar() { }

    }
}
