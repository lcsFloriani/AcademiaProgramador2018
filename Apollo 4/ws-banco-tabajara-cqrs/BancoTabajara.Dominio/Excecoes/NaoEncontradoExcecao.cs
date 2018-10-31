namespace BancoTabajara.Dominio.Excecoes
{
    public class NaoEncontradoExcecao : NegocioExcecao
    {
        public NaoEncontradoExcecao() : base(CodigoErro.NotFound, "Registro não encontrado") { }
    }
}
