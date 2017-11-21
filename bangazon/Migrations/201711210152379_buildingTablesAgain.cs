namespace bangazon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buildingTablesAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        State = c.String(),
                        StreetName = c.String(),
                        Zip = c.String(),
                        isActive = c.Boolean(nullable: false),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Variety = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        LocalDelivery = c.Boolean(nullable: false),
                        Rating = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CartId_Id = c.Int(),
                        CreatedById_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById_Id)
                .Index(t => t.CartId_Id)
                .Index(t => t.CreatedById_Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOpened = c.DateTime(nullable: false),
                        ActiveStatus = c.Boolean(nullable: false),
                        Address_Id = c.Int(),
                        PaymentTypeId_Id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.PaymentTypeId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.LineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductId_Id = c.Int(),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId_Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.ProductId_Id)
                .Index(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        isActive = c.Boolean(nullable: false),
                        Exp = c.DateTime(nullable: false),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invoices", "PaymentTypeId_Id", "dbo.PaymentTypes");
            DropForeignKey("dbo.PaymentTypes", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LineItems", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.LineItems", "ProductId_Id", "dbo.Products");
            DropForeignKey("dbo.Invoices", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Products", "CreatedById_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CartId_Id", "dbo.Carts");
            DropForeignKey("dbo.Addresses", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PaymentTypes", new[] { "UserId_Id" });
            DropIndex("dbo.LineItems", new[] { "Invoice_Id" });
            DropIndex("dbo.LineItems", new[] { "ProductId_Id" });
            DropIndex("dbo.Invoices", new[] { "UserId_Id" });
            DropIndex("dbo.Invoices", new[] { "PaymentTypeId_Id" });
            DropIndex("dbo.Invoices", new[] { "Address_Id" });
            DropIndex("dbo.Products", new[] { "CreatedById_Id" });
            DropIndex("dbo.Products", new[] { "CartId_Id" });
            DropIndex("dbo.Addresses", new[] { "UserId_Id" });
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.LineItems");
            DropTable("dbo.Invoices");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
            DropTable("dbo.Addresses");
        }
    }
}
