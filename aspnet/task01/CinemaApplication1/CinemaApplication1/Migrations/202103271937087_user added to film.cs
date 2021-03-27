namespace CinemaApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useraddedtofilm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "User", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "User");
        }
    }
}
