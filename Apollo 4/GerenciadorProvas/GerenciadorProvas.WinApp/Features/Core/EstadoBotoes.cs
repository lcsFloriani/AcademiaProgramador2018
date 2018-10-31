namespace GerenciadorProvas.WinApp.Features
{
    public class EstadoBotoes
    {
        public bool Gravar { get; internal set; }
        public bool Editar { get; internal set; }
        public bool Excluir { get; internal set;  }
        public bool PDF { get; internal set; }
        public bool CSV { get; internal set; }
        public bool XML { get; internal set; }
    }
}