namespace SharePay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitilaDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankCard",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100),
                        SecretCode = c.String(nullable: false, maxLength: 4),
                        ExpirationMonth = c.Int(nullable: false),
                        ExpirationYear = c.Int(nullable: false),
                        CardType = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Type = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        UserId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        IsRecurringPayment = c.Boolean(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 10),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentEntry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentRequestId = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentRequest", t => t.PaymentRequestId, cascadeDelete: true)
                .Index(t => t.PaymentRequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentRequest", "UserId", "dbo.User");
            DropForeignKey("dbo.PaymentEntry", "PaymentRequestId", "dbo.PaymentRequest");
            DropForeignKey("dbo.PaymentRequest", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.BankCard", "UserId", "dbo.User");
            DropIndex("dbo.PaymentEntry", new[] { "PaymentRequestId" });
            DropIndex("dbo.PaymentRequest", new[] { "CurrencyId" });
            DropIndex("dbo.PaymentRequest", new[] { "UserId" });
            DropIndex("dbo.BankCard", new[] { "UserId" });
            DropTable("dbo.PaymentEntry");
            DropTable("dbo.Currency");
            DropTable("dbo.PaymentRequest");
            DropTable("dbo.User");
            DropTable("dbo.BankCard");
        }
    }
}
