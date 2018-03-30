namespace SharePay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ExternalProviderLogin_Table : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExternalProviderLogin", "UserId", "dbo.User");
            DropIndex("dbo.ExternalProviderLogin", new[] { "UserId" });
            DropTable("dbo.ExternalProviderLogin");
        }
    }
}
