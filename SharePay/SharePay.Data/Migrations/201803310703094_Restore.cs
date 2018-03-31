namespace SharePay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExternalProviderLogin",
                c => new
                    {
                        ProviderType = c.String(nullable: false, maxLength: 20),
                        ProviderKey = c.String(nullable: false, maxLength: 100),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProviderType, t.ProviderKey })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 68));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExternalProviderLogin", "UserId", "dbo.User");
            DropIndex("dbo.ExternalProviderLogin", new[] { "UserId" });
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 68));
            DropTable("dbo.ExternalProviderLogin");
        }
    }
}
