namespace Enedir.MF7.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mf_ws_enedir_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBFunctionary",
                c => new
                    {
                        IdFunctionary = c.Long(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 30, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        User = c.String(maxLength: 15, unicode: false),
                        Password = c.String(maxLength: 25, unicode: false),
                        Status = c.Boolean(nullable: false),
                        Office = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFunctionary);
            
            CreateTable(
                "dbo.TBOutgo",
                c => new
                    {
                        IdOutgo = c.Long(nullable: false, identity: true),
                        Description = c.String(maxLength: 150, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        OutgoType = c.Int(nullable: false),
                        FunctionaryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdOutgo)
                .ForeignKey("dbo.TBFunctionary", t => t.FunctionaryId, cascadeDelete: true)
                .Index(t => t.FunctionaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBOutgo", "FunctionaryId", "dbo.TBFunctionary");
            DropIndex("dbo.TBOutgo", new[] { "FunctionaryId" });
            DropTable("dbo.TBOutgo");
            DropTable("dbo.TBFunctionary");
        }
    }
}
