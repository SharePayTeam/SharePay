namespace SharePay.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 68));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
