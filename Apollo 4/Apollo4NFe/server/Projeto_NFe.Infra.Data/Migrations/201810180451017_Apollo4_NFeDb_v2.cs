namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Apollo4_NFeDb_v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Taxes", "invoice_Id", "dbo.TBInvoiceProcessing");
            DropForeignKey("dbo.TBInvoiceProcessing", "Tax_Id", "dbo.Taxes");
            DropIndex("dbo.TBInvoiceProcessing", new[] { "Tax_Id" });
            DropIndex("dbo.Taxes", new[] { "invoice_Id" });
            DropColumn("dbo.TBInvoiceProcessing", "Tax_Id");
            DropTable("dbo.Taxes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValueFreight = c.Double(nullable: false),
                        invoice_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TBInvoiceProcessing", "Tax_Id", c => c.Int());
            CreateIndex("dbo.Taxes", "invoice_Id");
            CreateIndex("dbo.TBInvoiceProcessing", "Tax_Id");
            AddForeignKey("dbo.TBInvoiceProcessing", "Tax_Id", "dbo.Taxes", "Id");
            AddForeignKey("dbo.Taxes", "invoice_Id", "dbo.TBInvoiceProcessing", "idInvoiceProcessing");
        }
    }
}
