using BancoTabajara.Dominio.Excecoes;

namespace BancoTabajara.Dominio.Funcionalidades.Clientes
{
    public class ClienteNomeNuloOuVazioExcecao : NegocioExcecao
    {
        public ClienteNomeNuloOuVazioExcecao() : base(CodigoErro.Unhandled, "O nome do cliente não pode ser nulo ou vazio!")
        {
        }
    }
}