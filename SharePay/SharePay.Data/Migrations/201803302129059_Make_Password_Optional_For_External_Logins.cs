namespace SharePay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Make_Password_Optional_For_External_Logins : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 68));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 68));
        }
    }
}
