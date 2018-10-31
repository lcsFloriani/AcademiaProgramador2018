namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Apollo4_NFeDb_v1 : DbMigration
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
                        IssuanceDate = c.DateTime(),
                        Key_NumberAccessKey = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Tax_Id = c.Int(),
                    })
                .PrimaryKey(t => t.idInvoiceProcessing)
                .ForeignKey("dbo.TBConveyor", t => t.ConveyorId, cascadeDelete: true)
                .ForeignKey("dbo.TBEmitter", t => t.EmitterId, cascadeDelete: true)
                .ForeignKey("dbo.TBReceiver", t => t.ReceiverId, cascadeDelete: true)
                .ForeignKey("dbo.Taxes", t => t.Tax_Id)
                .Index(t => t.ConveyorId)
                .Index(t => t.EmitterId)
                .Index(t => t.ReceiverId)
                .Index(t => t.Tax_Id);
            
            CreateTable(
                "dbo.TBItemInvoice",
                c => new
                    {
                        InvoiceInProcessId = c.Long(nullable: false),
                        IdItemInvoice = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Long(nullable: false),
                        InvoiceInProcess_Id = c.Long(),
                    })
                .PrimaryKey(t => t.InvoiceInProcessId)
                .ForeignKey("dbo.TBInvoiceProcessing", t => t.InvoiceInProcessId)
                .ForeignKey("dbo.TBProduct", t => t.InvoiceInProcessId)
                .ForeignKey("dbo.TBInvoiceProcessing", t => t.InvoiceInProcess_Id)
                .Index(t => t.InvoiceInProcessId)
                .Index(t => t.InvoiceInProcess_Id);
            
            CreateTable(
                "dbo.TBProduct",
                c => new
                    {
                        IdProduct = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        UnitaryValue = c.Double(nullable: false),
                        Amount = c.Int(),
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
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValueFreight = c.Double(nullable: false),
                        invoice_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBInvoiceProcessing", t => t.invoice_Id)
                .Index(t => t.invoice_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBInvoiceProcessing", "Tax_Id", "dbo.Taxes");
            DropForeignKey("dbo.Taxes", "invoice_Id", "dbo.TBInvoiceProcessing");
            DropForeignKey("dbo.TBInvoiceProcessing", "ReceiverId", "dbo.TBReceiver");
            DropForeignKey("dbo.TBItemInvoice", "InvoiceInProcess_Id", "dbo.TBInvoiceProcessing");
            DropForeignKey("dbo.TBItemInvoice", "InvoiceInProcessId", "dbo.TBProduct");
            DropForeignKey("dbo.TBItemInvoice", "InvoiceInProcessId", "dbo.TBInvoiceProcessing");
            DropForeignKey("dbo.TBInvoiceProcessing", "EmitterId", "dbo.TBEmitter");
            DropForeignKey("dbo.TBInvoiceProcessing", "ConveyorId", "dbo.TBConveyor");
            DropIndex("dbo.Taxes", new[] { "invoice_Id" });
            DropIndex("dbo.TBItemInvoice", new[] { "InvoiceInProcess_Id" });
            DropIndex("dbo.TBItemInvoice", new[] { "InvoiceInProcessId" });
            DropIndex("dbo.TBInvoiceProcessing", new[] { "Tax_Id" });
            DropIndex("dbo.TBInvoiceProcessing", new[] { "ReceiverId" });
            DropIndex("dbo.TBInvoiceProcessing", new[] { "EmitterId" });
            DropIndex("dbo.TBInvoiceProcessing", new[] { "ConveyorId" });
            DropTable("dbo.Taxes");
            DropTable("dbo.TBReceiver");
            DropTable("dbo.TBProduct");
            DropTable("dbo.TBItemInvoice");
            DropTable("dbo.TBInvoiceProcessing");
            DropTable("dbo.TBEmitter");
            DropTable("dbo.TBConveyor");
        }
    }
}
