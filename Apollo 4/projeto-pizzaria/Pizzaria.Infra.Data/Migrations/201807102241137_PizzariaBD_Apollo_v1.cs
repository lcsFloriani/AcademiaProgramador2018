namespace Pizzaria.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PizzariaBD_Apollo_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBCliente",
                c => new
                    {
                        IdCliente = c.Long(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50, unicode: false),
                        Telefone = c.String(maxLength: 50, unicode: false),
                        NumeroDocumento = c.String(maxLength: 50, unicode: false),
                        Endereco_Logradouro = c.String(maxLength: 75, unicode: false),
                        Endereco_Bairro = c.String(maxLength: 50, unicode: false),
                        Endereco_Cidade = c.String(maxLength: 100, unicode: false),
                        Endereco_UF = c.String(maxLength: 2, unicode: false),
                        Endereco_Cep = c.String(maxLength: 8, unicode: false),
                        Endereco_Numero = c.Int(nullable: false),
                        Endereco_Complemento = c.String(maxLength: 50, unicode: false),
                        TipoCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.TBItemPedido",
                c => new
                    {
                        IdItemPedido = c.Long(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        PedidoId = c.Long(nullable: false),
                        PrimeiroProdutoId = c.Long(nullable: false),
                        SegundoProdutoId = c.Long(),
                        AdicionalId = c.Long(),
                    })
                .PrimaryKey(t => t.IdItemPedido)
                .ForeignKey("dbo.TBProduto", t => t.AdicionalId)
                .ForeignKey("dbo.TBPedido", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.TBProduto", t => t.PrimeiroProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.TBProduto", t => t.SegundoProdutoId)
                .Index(t => t.PedidoId)
                .Index(t => t.PrimeiroProdutoId)
                .Index(t => t.SegundoProdutoId)
                .Index(t => t.AdicionalId);
            
            CreateTable(
                "dbo.TBProduto",
                c => new
                    {
                        IdProduto = c.Long(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 50, unicode: false),
                        Tipo = c.Int(nullable: false),
                        Tamanho = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduto);
            
            CreateTable(
                "dbo.TBPedido",
                c => new
                    {
                        IdPedido = c.Long(nullable: false, identity: true),
                        Setor = c.String(maxLength: 50, unicode: false),
                        Responsavel = c.String(maxLength: 50, unicode: false),
                        Documento = c.String(maxLength: 20, unicode: false),
                        FormaPagamento = c.Int(nullable: false),
                        EmitirNFe = c.Boolean(nullable: false),
                        Observacao = c.String(maxLength: 200, unicode: false),
                        Data = c.DateTime(nullable: false),
                        StatusPedido = c.Int(nullable: false),
                        ClienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdPedido)
                .ForeignKey("dbo.TBCliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBItemPedido", "SegundoProdutoId", "dbo.TBProduto");
            DropForeignKey("dbo.TBItemPedido", "PrimeiroProdutoId", "dbo.TBProduto");
            DropForeignKey("dbo.TBItemPedido", "PedidoId", "dbo.TBPedido");
            DropForeignKey("dbo.TBPedido", "ClienteId", "dbo.TBCliente");
            DropForeignKey("dbo.TBItemPedido", "AdicionalId", "dbo.TBProduto");
            DropIndex("dbo.TBPedido", new[] { "ClienteId" });
            DropIndex("dbo.TBItemPedido", new[] { "AdicionalId" });
            DropIndex("dbo.TBItemPedido", new[] { "SegundoProdutoId" });
            DropIndex("dbo.TBItemPedido", new[] { "PrimeiroProdutoId" });
            DropIndex("dbo.TBItemPedido", new[] { "PedidoId" });
            DropTable("dbo.TBPedido");
            DropTable("dbo.TBProduto");
            DropTable("dbo.TBItemPedido");
            DropTable("dbo.TBCliente");
        }

         
    }
}
