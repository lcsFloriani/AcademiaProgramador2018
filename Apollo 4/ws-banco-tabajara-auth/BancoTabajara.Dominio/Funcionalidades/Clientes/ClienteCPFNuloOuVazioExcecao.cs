using BancoTabajara.Dominio.Excecoes;
using System;

namespace BancoTabajara.Dominio.Funcionalidades.Clientes
{
    public class ClienteCPFNuloOuVazioExcecao : NegocioExcecao
    {
        public ClienteCPFNuloOuVazioExcecao() : base(CodigoErro.Unhandled, "O CPF do cliente não pode ser nulo ou vazio!")
        {
        }
    }
}