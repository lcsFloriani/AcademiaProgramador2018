namespace NDDResearch.Infra.Data.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sites", "CustomerId", "dbo.Customers");
            AddForeignKey("dbo.Sites", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sites", "CustomerId", "dbo.Customers");
            AddForeignKey("dbo.Sites", "CustomerId", "dbo.Customers", "Id");
        }
    }
}
