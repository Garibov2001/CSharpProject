namespace CinemaApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Films", "UserID");
            AddForeignKey("dbo.Films", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            DropColumn("dbo.Films", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "User", c => c.Int(nullable: false));
            DropForeignKey("dbo.Films", "UserID", "dbo.Users");
            DropIndex("dbo.Films", new[] { "UserID" });
            DropColumn("dbo.Films", "UserID");
        }
    }
}
