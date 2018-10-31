namespace BancoTabajara.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class BancoTabajaraBD_Apollo4_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBCliente",
                c => new
                    {
                        IdCliente = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        RG = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.TBConta",
                c => new
                    {
                        IdConta = c.Long(nullable: false, identity: true),
                        NumeroConta = c.Int(nullable: false),
                        Saldo = c.Double(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        Limite = c.Double(nullable: false),
                        ClienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdConta)
                .ForeignKey("dbo.TBCliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.TBMovimentacao",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        TipoOperacao = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        ContaId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBConta", t => t.ContaId, cascadeDelete: true)
                .Index(t => t.ContaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBMovimentacao", "ContaId", "dbo.TBConta");
            DropForeignKey("dbo.TBConta", "ClienteId", "dbo.TBCliente");
            DropIndex("dbo.TBMovimentacao", new[] { "ContaId" });
            DropIndex("dbo.TBConta", new[] { "ClienteId" });
            DropTable("dbo.TBMovimentacao");
            DropTable("dbo.TBConta");
            DropTable("dbo.TBCliente");
        }
    }
}
