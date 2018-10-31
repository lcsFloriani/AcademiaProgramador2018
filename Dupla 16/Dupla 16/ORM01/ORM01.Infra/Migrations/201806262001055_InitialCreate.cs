namespace ORM01.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBAluno",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Aniversario = c.DateTime(nullable: false),
                        Endereco_Id = c.Int(nullable: false),
                        Turma_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBEndereco", t => t.Endereco_Id, cascadeDelete: true)
                .ForeignKey("dbo.TBTurma", t => t.Turma_Id, cascadeDelete: true)
                .Index(t => t.Endereco_Id)
                .Index(t => t.Turma_Id);
            
            CreateTable(
                "dbo.TBEndereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TBTurma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBAluno", "Turma_Id", "dbo.TBTurma");
            DropForeignKey("dbo.TBAluno", "Endereco_Id", "dbo.TBEndereco");
            DropIndex("dbo.TBAluno", new[] { "Turma_Id" });
            DropIndex("dbo.TBAluno", new[] { "Endereco_Id" });
            DropTable("dbo.TBTurma");
            DropTable("dbo.TBEndereco");
            DropTable("dbo.TBAluno");
        }
    }
}
