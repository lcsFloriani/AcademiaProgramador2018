using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Infra.Data.Features.Clientes;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Data.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzaria.Infra.Data.Features.Pedidos;
using Pizzaria.Infra.Data.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.ItensPedido;
using System.Configuration;

namespace Pizzaria.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base(ConfigurationManager.AppSettings.Get("ConnectionStringName"))
        {
       
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Configurations.Add(new ProdutoConfiguracao());
            modelBuilder.Configurations.Add(new PedidoConfiguracao());
            modelBuilder.Configurations.Add(new ItemPedidoConfiguracao());
        }

    }
}
