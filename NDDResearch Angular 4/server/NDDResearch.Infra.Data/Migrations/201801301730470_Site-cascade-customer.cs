namespace NDDResearch.Infra.Data.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sitecascadecustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "Id");
        }
    }
}
