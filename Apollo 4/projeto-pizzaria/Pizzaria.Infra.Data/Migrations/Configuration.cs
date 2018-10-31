namespace Pizzaria.Infra.Data.Migrations
{
    using Pizzaria.Domain.Enums;
    using Pizzaria.Domain.Features.Clientes;
    using Pizzaria.Domain.Features.Enderecos;
    using Pizzaria.Domain.Features.Produtos;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pizzaria.Infra.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pizzaria.Infra.Data.DataContext contexto)
        {
            #region Enderecos
            Endereco enderecoPrimeiroCliente = new Endereco
            {
                Logradouro = "Av. Presidente Vargas",
                Bairro = "Coral",
                Cidade = "Lages",
                UF = "SC",
                Cep = "88509501",
                Numero = 1090,
                Complemento = "Casa"
            };
            Endereco enderecoSegundoCliente = new Endereco
            {
                Logradouro = "R. Dr. Valmor Ribeiro",
                Bairro = "Centro",
                Cidade = "Lages",
                UF = "SC",
                Cep = "88523060",
                Numero = 431,
                Complemento = "Empresa"
            };
            Endereco enderecoTerceiroCliente = new Endereco
            {
                Logradouro = "Av. Belisário Ramos",
                Bairro = "Copacabana",
                Cidade = "Lages",
                UF = "SC",
                Cep = "88504040",
                Numero = 400,
                Complemento = "Casa"
            };
            Endereco enderecoQuartoCliente = new Endereco
            {
                Logradouro = "Rua Aristiliano Ramos",
                Bairro = "Centro",
                Cidade = "Lages",
                UF = "SC",
                Cep = "88502903",
                Numero = 33,
                Complemento = "Loja"
            };
            #endregion

            #region Clientes
            Cliente primeiroClienteFisico = new Cliente
            {
                Nome = "José",
                Telefone = "999418993",
                NumeroDocumento = "32999959010",
                Endereco = enderecoPrimeiroCliente,
                TipoCliente = TipoClienteEnum.Fisico
            };
            Cliente segundoClienteJuridico = new Cliente
            {
                Nome = "Teste",
                Telefone = "999988993",
                NumeroDocumento = "91378916000135",
                Endereco = enderecoSegundoCliente,
                TipoCliente = TipoClienteEnum.Juridico
            };
            Cliente terceiroClienteFisico = new Cliente
            {
                Nome = "Isabel",
                Telefone = "991998877",
                NumeroDocumento = "32999959010",
                Endereco = enderecoTerceiroCliente,
                TipoCliente = TipoClienteEnum.Fisico
            };
            Cliente quartoClienteFisico = new Cliente
            {
                Nome = "Enedir",
                Telefone = "988998877",
                NumeroDocumento = "32999959010",
                Endereco = enderecoTerceiroCliente,
                TipoCliente = TipoClienteEnum.Fisico
            };
            Cliente quintoClienteFisico = new Cliente
            {
                Nome = "Rech",
                Telefone = "988998865",
                NumeroDocumento = "32999959010",
                Endereco = enderecoTerceiroCliente,
                TipoCliente = TipoClienteEnum.Fisico
            };
            #endregion

            #region Calzones
            Produto primeiroCalzone = new Produto
            {
                Descricao = "Frango",
                Valor = 15.00,
                Tamanho = TamanhoProdutoEnum.Padrao,
                Tipo = TipoProdutoEnum.Calzone
            };

            Produto segundoCalzone = new Produto
            {
                Descricao = "Carne",
                Valor = 15.00,
                Tamanho = TamanhoProdutoEnum.Padrao,
                Tipo = TipoProdutoEnum.Calzone
            };
            Produto terceiroCalzone = new Produto
            {
                Descricao = "Frango com requeijão",
                Valor = 18.00,
                Tamanho = TamanhoProdutoEnum.Padrao,
                Tipo = TipoProdutoEnum.Calzone
            };
            Produto quartoCalzone = new Produto
            {
                Descricao = "Calabresa",
                Valor = 18.00,
                Tamanho = TamanhoProdutoEnum.Padrao,
                Tipo = TipoProdutoEnum.Calzone
            };
            Produto quintoCalzone = new Produto
            {
                Descricao = "Atum",
                Valor = 15.00,
                Tamanho = TamanhoProdutoEnum.Padrao,
                Tipo = TipoProdutoEnum.Calzone
            };
            #endregion

            #region Pizzas
            //Pequenas
            Produto primeiraPizzaPequena = new Produto
            {
                Descricao = "Calabresa",
                Valor = 60,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };

            Produto segundaPizzaPequena = new Produto
            {
                Descricao = "Lombo com Catupiry",
                Valor = 60.80,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto terceiraPizzaPequena = new Produto
            {
                Descricao = "Palmito",
                Valor = 60.80,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto quartaPizzaPequena = new Produto
            {
                Descricao = "Coração",
                Valor = 60.80,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto quintaPizzaPequena = new Produto
            {
                Descricao = "Filé e Gorgonzola",
                Valor = 60.80,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
            //Médias
            Produto primeiraPizzaMedia = new Produto
            {
                Descricao = "Calabresa",
                Valor = 69.80,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Pizza
            };

            Produto segundaPizzaMedia = new Produto
            {
                Descricao = "4 queijos",
                Valor = 69.80,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto terceiraPizzaMedia = new Produto
            {
                Descricao = "Brócolis com bacon",
                Valor = 69.80,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto quartaPizzaMedia = new Produto
            {
                Descricao = "Calabresa",
                Valor = 69.80,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto quintaPizzaMedia = new Produto
            {
                Descricao = "Portuguesa",
                Valor = 69.80,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Pizza
            };
            //Grandes
            Produto primeiraPizzaGrande = new Produto
            {
                Descricao = "Lombo com Catupiry",
                Valor = 75.80,
                Tamanho = TamanhoProdutoEnum.Grande,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto segundaPizzaGrande = new Produto
            {
                Descricao = "4 queijos",
                Valor = 75.80,
                Tamanho = TamanhoProdutoEnum.Grande,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto terceiraPizzaGrande = new Produto
            {
                Descricao = "Brócolis com bacon",
                Valor = 75.80,
                Tamanho = TamanhoProdutoEnum.Grande,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto quartaPizzaGrande = new Produto
            {
                Descricao = "Coração",
                Valor = 75.80,
                Tamanho = TamanhoProdutoEnum.Grande,
                Tipo = TipoProdutoEnum.Pizza
            };
            Produto quintaPizzaGrande = new Produto
            {
                Descricao = "Filé e Gorgonzola",
                Valor = 75.80,
                Tamanho = TamanhoProdutoEnum.Grande,
                Tipo = TipoProdutoEnum.Pizza
            };
            #endregion

            #region Bebidas
            Produto primeiraBebida = new Produto
            {
                Descricao = "Coca Cola 2L",
                Valor = 8.00,
                Tamanho = TamanhoProdutoEnum.Litro,
                Tipo = TipoProdutoEnum.Bebida
            };

            Produto segundaBebida = new Produto
            {
                Descricao = "Guaraná Antarctica 2L",
                Valor = 7.00,
                Tamanho = TamanhoProdutoEnum.Litro,
                Tipo = TipoProdutoEnum.Bebida
            };
            Produto terceiraBebida = new Produto
            {
                Descricao = "Fanta uva 2L",
                Valor = 7.00,
                Tamanho = TamanhoProdutoEnum.Litro,
                Tipo = TipoProdutoEnum.Bebida
            };
            Produto quartaBebida = new Produto
            {
                Descricao = "Fanta laranja 2L",
                Valor = 7.00,
                Tamanho = TamanhoProdutoEnum.Litro,
                Tipo = TipoProdutoEnum.Bebida
            };
            Produto quintaBebida = new Produto
            {
                Descricao = "Pepsi 2L",
                Valor = 7.00,
                Tamanho = TamanhoProdutoEnum.Litro,
                Tipo = TipoProdutoEnum.Bebida
            };
            #endregion

            #region Adicional - Bordas
            //Catupiry
            Produto bordaCatupiryPequena = new Produto
            {
                Descricao = "Borda de Catupiry",
                Valor = 1.25,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Adicional
            };

            Produto bordaCatupiryMedia = new Produto
            {
                Descricao = "Borda de Catupiry",
                Valor = 1.75,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Adicional
            };
            Produto bordaCatupiryGrande = new Produto
            {
                Descricao = "Borda de Catupiry",
                Valor = 2.50,
                Tamanho = TamanhoProdutoEnum.Grande,
                Tipo = TipoProdutoEnum.Adicional
            };

            //Cheddar
            Produto bordaCheddarPequena = new Produto
            {
                Descricao = "Borda de Cheddar",
                Valor = 1,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Adicional
            };
            Produto bordaCheddarMedia = new Produto
            {
                Descricao = "Borda de Cheddar",
                Valor = 1.50,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Adicional
            };

            Produto bordaCheddarGrande = new Produto
            {
                Descricao = "Borda de Cheddar",
                Valor = 2,
                Tamanho = TamanhoProdutoEnum.Grande,
                Tipo = TipoProdutoEnum.Adicional
            };
            #endregion

            #region Adicionando no banco
            //Adicionando clientes
            contexto.Clientes.AddOrUpdate(primeiroClienteFisico);
            contexto.Clientes.AddOrUpdate(segundoClienteJuridico);
            contexto.Clientes.AddOrUpdate(terceiroClienteFisico);
            contexto.Clientes.AddOrUpdate(quartoClienteFisico);
            contexto.Clientes.AddOrUpdate(quintoClienteFisico);

            //Adicionando Produtos
            //Calzones
            contexto.Produtos.AddOrUpdate(primeiroCalzone);
            contexto.Produtos.AddOrUpdate(segundoCalzone);
            contexto.Produtos.AddOrUpdate(terceiroCalzone);
            contexto.Produtos.AddOrUpdate(quartoCalzone);
            contexto.Produtos.AddOrUpdate(quintoCalzone);
            //Pizzas
            contexto.Produtos.AddOrUpdate(primeiraPizzaPequena);
            contexto.Produtos.AddOrUpdate(segundaPizzaPequena);
            contexto.Produtos.AddOrUpdate(terceiraPizzaPequena);
            contexto.Produtos.AddOrUpdate(quartaPizzaPequena);
            contexto.Produtos.AddOrUpdate(quintaPizzaPequena);
            contexto.Produtos.AddOrUpdate(primeiraPizzaMedia);
            contexto.Produtos.AddOrUpdate(segundaPizzaMedia);
            contexto.Produtos.AddOrUpdate(terceiraPizzaMedia);
            contexto.Produtos.AddOrUpdate(quartaPizzaMedia);
            contexto.Produtos.AddOrUpdate(quintaPizzaMedia);
            contexto.Produtos.AddOrUpdate(primeiraPizzaGrande);
            contexto.Produtos.AddOrUpdate(segundaPizzaGrande);
            contexto.Produtos.AddOrUpdate(terceiraPizzaGrande);
            contexto.Produtos.AddOrUpdate(quartaPizzaGrande);
            contexto.Produtos.AddOrUpdate(quintaPizzaGrande);
            //Bebidas
            contexto.Produtos.AddOrUpdate(primeiraBebida);
            contexto.Produtos.AddOrUpdate(segundaBebida);
            contexto.Produtos.AddOrUpdate(terceiraBebida);
            contexto.Produtos.AddOrUpdate(quartaBebida);
            contexto.Produtos.AddOrUpdate(quintaBebida);
            //Adicionais - Bordas
            contexto.Produtos.AddOrUpdate(bordaCatupiryPequena);
            contexto.Produtos.AddOrUpdate(bordaCatupiryMedia);
            contexto.Produtos.AddOrUpdate(bordaCatupiryGrande);
            contexto.Produtos.AddOrUpdate(bordaCheddarPequena);
            contexto.Produtos.AddOrUpdate(bordaCheddarMedia);
            contexto.Produtos.AddOrUpdate(bordaCheddarGrande);
            #endregion

            contexto.SaveChanges();
        }

    }
}
