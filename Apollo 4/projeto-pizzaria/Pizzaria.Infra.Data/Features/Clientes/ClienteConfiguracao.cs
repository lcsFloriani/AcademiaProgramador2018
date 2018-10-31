using Pizzaria.Domain.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Features.Clientes
{
    public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            ToTable("TBCliente");

            Property(c => c.Id).HasColumnName("IdCliente");
            Property(c => c.Nome).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.Telefone).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.NumeroDocumento).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.Endereco.Logradouro).HasColumnType("VARCHAR").HasMaxLength(75);
            Property(c => c.Endereco.Bairro).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.Endereco.Cidade).HasColumnType("VARCHAR").HasMaxLength(100);
            Property(c => c.Endereco.UF).HasColumnType("VARCHAR").HasMaxLength(2);
            Property(c => c.Endereco.Cep).HasColumnType("VARCHAR").HasMaxLength(8);
            Property(c => c.Endereco.Numero).HasColumnType("INT");
            Property(c => c.Endereco.Complemento).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.TipoCliente).HasColumnType("INT"); 
        }
    }
}
