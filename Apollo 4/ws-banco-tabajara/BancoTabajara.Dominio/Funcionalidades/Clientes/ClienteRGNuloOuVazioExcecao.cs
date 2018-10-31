using BancoTabajara.Dominio.Excecoes;

namespace BancoTabajara.Dominio.Funcionalidades.Clientes
{
    public class ClienteRGNuloOuVazioExcecao : NegocioExcecao
    {
        public ClienteRGNuloOuVazioExcecao() : base(CodigoErro.Unhandled, "O RG do cliente não pode ser nulo ou vazio!")
        {
        }
    }
}