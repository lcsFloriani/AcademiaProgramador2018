namespace Floriani.Orm.Infra.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FuncionarioCPF_V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBCargos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Cargo = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBDepartamentos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Departamento = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBDependentes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 500),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBFuncionarios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 500),
                        Idade = c.Int(nullable: false),
                        CPF = c.String(),
                        Cargo_Id = c.Long(),
                        Departamento_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBCargos", t => t.Cargo_Id)
                .ForeignKey("dbo.TBDepartamentos", t => t.Departamento_Id)
                .Index(t => t.Cargo_Id)
                .Index(t => t.Departamento_Id);
            
            CreateTable(
                "dbo.TBProjetos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 500),
                        DataInicio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBFuncionariosDependentes",
                c => new
                    {
                        DependenteId = c.Long(nullable: false),
                        FuncionarioId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.DependenteId, t.FuncionarioId })
                .ForeignKey("dbo.TBFuncionarios", t => t.DependenteId, cascadeDelete: true)
                .ForeignKey("dbo.TBDependentes", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.DependenteId)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.TBProjetosFuncionarios",
                c => new
                    {
                        FuncionarioId = c.Long(nullable: false),
                        ProjetoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.FuncionarioId, t.ProjetoId })
                .ForeignKey("dbo.TBProjetos", t => t.FuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.TBFuncionarios", t => t.ProjetoId, cascadeDelete: true)
                .Index(t => t.FuncionarioId)
                .Index(t => t.ProjetoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBProjetosFuncionarios", "ProjetoId", "dbo.TBFuncionarios");
            DropForeignKey("dbo.TBProjetosFuncionarios", "FuncionarioId", "dbo.TBProjetos");
            DropForeignKey("dbo.TBFuncionariosDependentes", "FuncionarioId", "dbo.TBDependentes");
            DropForeignKey("dbo.TBFuncionariosDependentes", "DependenteId", "dbo.TBFuncionarios");
            DropForeignKey("dbo.TBFuncionarios", "Departamento_Id", "dbo.TBDepartamentos");
            DropForeignKey("dbo.TBFuncionarios", "Cargo_Id", "dbo.TBCargos");
            DropIndex("dbo.TBProjetosFuncionarios", new[] { "ProjetoId" });
            DropIndex("dbo.TBProjetosFuncionarios", new[] { "FuncionarioId" });
            DropIndex("dbo.TBFuncionariosDependentes", new[] { "FuncionarioId" });
            DropIndex("dbo.TBFuncionariosDependentes", new[] { "DependenteId" });
            DropIndex("dbo.TBFuncionarios", new[] { "Departamento_Id" });
            DropIndex("dbo.TBFuncionarios", new[] { "Cargo_Id" });
            DropTable("dbo.TBProjetosFuncionarios");
            DropTable("dbo.TBFuncionariosDependentes");
            DropTable("dbo.TBProjetos");
            DropTable("dbo.TBFuncionarios");
            DropTable("dbo.TBDependentes");
            DropTable("dbo.TBDepartamentos");
            DropTable("dbo.TBCargos");
        }
    }
}
