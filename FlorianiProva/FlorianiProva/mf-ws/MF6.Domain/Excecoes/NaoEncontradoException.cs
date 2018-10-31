using MF6.Domain.Exceptions;

namespace MF6.Domain.Excecoes
{
    public class NaoEncontradoException : ExcecaoDeNegocio
    {
        public NaoEncontradoException() : base(CodigoErros.NotFound, "Registro não encontrado")
        {
        }
    }
}
