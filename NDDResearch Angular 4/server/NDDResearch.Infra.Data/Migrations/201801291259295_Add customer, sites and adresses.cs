namespace NDDResearch.Infra.Data.Initializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcustomersitesandadresses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Street = c.String(),
                        AdditionalInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DisplayName = c.String(),
                        NationalIdNumber = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        WebSite = c.String(maxLength: 100),
                        AddressId = c.Int(nullable: false),
                        Key = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.Key);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        IsDefault = c.Boolean(nullable: false),
                        NationalIdNumber = c.String(maxLength: 50),
                        AddressId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.AddressId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sites", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sites", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Sites", new[] { "CustomerId" });
            DropIndex("dbo.Sites", new[] { "AddressId" });
            DropIndex("dbo.Customers", new[] { "Key" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropTable("dbo.Sites");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
