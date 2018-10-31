namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBConveyor",
                c => new
                    {
                        IdConveyor = c.Long(nullable: false, identity: true),
                        PersonType = c.Int(nullable: false),
                        NameCompanyName = c.String(nullable: false),
                        FreightResponsibility = c.Int(nullable: false),
                        CpfCnpj = c.String(nullable: false),
                        Address_Street = c.String(nullable: false),
                        Address_Number = c.Int(nullable: false),
                        Address_Neighbourhood = c.String(nullable: false),
                        Address_City = c.String(nullable: false),
                        Address_State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdConveyor);
            
            CreateTable(
                "dbo.TBEmitter",
                c => new
                    {
                        IdEmitter = c.Long(nullable: false, identity: true),
                        FantasyName = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Cnpj = c.String(nullable: false),
                        StateRegistration = c.String(nullable: false),
                        MunicipalRegistration = c.String(nullable: false),
                        Address_Street = c.String(nullable: false),
                        Address_Number = c.Int(nullable: false),
                        Address_Neighbourhood = c.String(nullable: false),
                        Address_City = c.String(nullable: false),
                        Address_State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmitter);
            
            CreateTable(
                "dbo.TBInvoiceProcessing",
                c => new
                    {
                        idInvoiceProcessing = c.Long(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        NatureOperation = c.String(nullable: false),
                        ValueFreight = c.Double(nullable: false),
                        ConveyorId = c.Long(nullable: false),
                        EmitterId = c.Long(nullable: false),
                        ReceiverId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.idInvoiceProcessing)
                .ForeignKey("dbo.TBConveyor", t => t.ConveyorId, cascadeDelete: true)
                .ForeignKey("dbo.TBEmitter", t => t.EmitterId, cascadeDelete: true)
                .ForeignKey("dbo.TBReceiver", t => t.ReceiverId, cascadeDelete: true)
                .Index(t => t.ConveyorId)
                .Index(t => t.EmitterId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.TBItemInvoice",
                c => new
                    {
                        IdItem = c.Long(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        InvoiceInProcessId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdItem)
                .ForeignKey("dbo.TBInvoiceProcessing", t => t.InvoiceInProcessId, cascadeDelete: true)
                .ForeignKey("dbo.TBProduct", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InvoiceInProcessId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.TBProduct",
                c => new
                    {
                        IdProduct = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        UnitaryValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduct);
            
            CreateTable(
                "dbo.TBReceiver",
                c => new
                    {
                        IdReceiver = c.Long(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        NameCompanyName = c.String(nullable: false),
                        CpfCnpj = c.String(),
                        StateRegistration = c.String(),
                        Address_Street = c.String(nullable: false),
                        Address_Number = c.Int(nullable: false),
                        Address_Neighbourhood = c.String(nullable: false),
                        Address_City = c.String(nullable: false),
                        Address_State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdReceiver);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBInvoiceProcessing", "ReceiverId", "dbo.TBReceiver");
            DropForeignKey("dbo.TBItemInvoice", "ProductId", "dbo.TBProduct");
            DropForeignKey("dbo.TBItemInvoice", "InvoiceInProcessId", "dbo.TBInvoiceProcessing");
            DropForeignKey("dbo.TBInvoiceProcessing", "EmitterId", "dbo.TBEmitter");
            DropForeignKey("dbo.TBInvoiceProcessing", "ConveyorId", "dbo.TBConveyor");
            DropIndex("dbo.TBItemInvoice", new[] { "ProductId" });
            DropIndex("dbo.TBItemInvoice", new[] { "InvoiceInProcessId" });
            DropIndex("dbo.TBInvoiceProcessing", new[] { "ReceiverId" });
            DropIndex("dbo.TBInvoiceProcessing", new[] { "EmitterId" });
            DropIndex("dbo.TBInvoiceProcessing", new[] { "ConveyorId" });
            DropTable("dbo.TBReceiver");
            DropTable("dbo.TBProduct");
            DropTable("dbo.TBItemInvoice");
            DropTable("dbo.TBInvoiceProcessing");
            DropTable("dbo.TBEmitter");
            DropTable("dbo.TBConveyor");
        }
    }
}
