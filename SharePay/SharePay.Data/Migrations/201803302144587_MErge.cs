namespace SharePay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MErge : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExternalProviderLogin", "UserId", "dbo.User");
            DropIndex("dbo.ExternalProviderLogin", new[] { "UserId" });
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 68));
            DropTable("dbo.ExternalProviderLogin");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExternalProviderLogin",
                c => new
                    {
                        ProviderType = c.String(nullable: false, maxLength: 20),
                        ProviderKey = c.String(nullable: false, maxLength: 100),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProviderType, t.ProviderKey });
            
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 68));
            CreateIndex("dbo.ExternalProviderLogin", "UserId");
            AddForeignKey("dbo.ExternalProviderLogin", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
