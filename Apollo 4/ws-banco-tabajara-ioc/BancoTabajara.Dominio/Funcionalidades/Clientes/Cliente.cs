using BancoTabajara.Dominio.Funcionalidades.Contas;
using System;

namespace BancoTabajara.Dominio.Funcionalidades.Clientes
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new ClienteNomeNuloOuVazioExcecao();

            if (string.IsNullOrEmpty(CPF))
                throw new ClienteCPFNuloOuVazioExcecao();

            if (string.IsNullOrEmpty(RG))
                throw new ClienteRGNuloOuVazioExcecao();
        }
    }
}