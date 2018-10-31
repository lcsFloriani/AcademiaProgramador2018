namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Apollo4_NFeDb_v3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TBInvoiceProcessing", "Key_NumberAccessKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBInvoiceProcessing", "Key_NumberAccessKey", c => c.String());
        }
    }
}
