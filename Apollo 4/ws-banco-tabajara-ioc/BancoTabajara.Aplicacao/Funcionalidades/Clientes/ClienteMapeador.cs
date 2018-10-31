using BancoTabajara.Dominio.Funcionalidades.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes
{
    public static class ClienteMapeador
    {
        public static ClienteDTO ConverterParaDTO(this Cliente cliente)
        {
            return new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                CPF = cliente.CPF,
                RG = cliente.RG
            };
        }

        public static IQueryable<ClienteDTO> ConverterParaListaDTO(this IQueryable<Cliente> clientes)
        {
            List<ClienteDTO> lista = new List<ClienteDTO>();

            foreach (Cliente c in clientes)
                lista.Add(c.ConverterParaDTO());

            return lista.AsQueryable();
        } 
    }
}
