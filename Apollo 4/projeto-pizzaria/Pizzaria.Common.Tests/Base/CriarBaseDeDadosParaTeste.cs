using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.CNPJs;
using Pizzaria.Infra.CPFs;
using Pizzaria.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Common.Tests.Base
{
    public class CriarBaseDeDadosParaTeste : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext contexto)
        {
            Cpf cpf = ObjectMother.ObterCpf();
            Cnpj cnpj = ObjectMother.ObterCnpj();
            Endereco endereco = ObjectMother.ObterEndereco();
            Cliente clienteFisico = ObjectMother.ObterClienteTipoPessoaFisica(endereco);
            Cliente clienteJuridico = ObjectMother.ObterClienteTipoPessoaJuridica(endereco);

            Cliente clienteComPedido =  new Cliente
            {
                Nome = "Paulo da silva",
                Telefone = "32251709",
                NumeroDocumento = "74010630000",
                Endereco = new Endereco
                {
                    Logradouro = "Av. Presidente Castelo Branco",
                    Bairro = "Coral",
                    Cidade = "Lages",
                    UF = "SC",
                    Cep = "88236589",
                    Numero = 109,
                    Complemento = "Apartamento"
                },
                TipoCliente = TipoClienteEnum.Fisico
            };

            Produto calzone = ObjectMother.ObterCalzone();
            Produto pizzaMediaDeCalabresa = ObjectMother.ObterPizzaMediaDeCalabresa();

            Pedido pedido = ObjectMother.ObterPedidoSemUmaListaDeItens(clienteComPedido);
            ItemPedido itemPedido = new ItemPedido(pizzaMediaDeCalabresa, 1);
            pedido.AdicionarItem(itemPedido);

            contexto.Clientes.Add(clienteFisico);
            contexto.Clientes.Add(clienteJuridico);
            contexto.Clientes.Add(clienteComPedido);
            contexto.Produtos.Add(calzone);
            contexto.Produtos.Add(pizzaMediaDeCalabresa);
            contexto.Pedidos.Add(pedido);

            contexto.SaveChanges();

            base.Seed(contexto);
        }
    }
}
