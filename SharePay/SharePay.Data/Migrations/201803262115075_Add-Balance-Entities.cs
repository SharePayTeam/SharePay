namespace SharePay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBalanceEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BalanceEntry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BalanceId = c.Int(nullable: false),
                        ObjectId = c.Int(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntryType = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Balance", t => t.BalanceId, cascadeDelete: true)
                .Index(t => t.BalanceId);
            
            CreateTable(
                "dbo.Balance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
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
            
            AddColumn("dbo.PaymentEntry", "PaymentStatus", c => c.Int(nullable: false));
            DropColumn("dbo.PaymentEntry", "CreatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaymentEntry", "CreatedBy", c => c.Int(nullable: false));
            DropForeignKey("dbo.Balance", "UserId", "dbo.User");
            DropForeignKey("dbo.Balance", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.BalanceEntry", "BalanceId", "dbo.Balance");
            DropIndex("dbo.Balance", new[] { "CurrencyId" });
            DropIndex("dbo.Balance", new[] { "UserId" });
            DropIndex("dbo.BalanceEntry", new[] { "BalanceId" });
            DropColumn("dbo.PaymentEntry", "PaymentStatus");
            DropTable("dbo.Balance");
            DropTable("dbo.BalanceEntry");
        }
    }
}
