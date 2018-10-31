namespace NDDResearch.Infra.Data.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removeattrcustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "IsRemoved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsRemoved", c => c.Boolean(nullable: false));
        }
    }
}
