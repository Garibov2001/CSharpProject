namespace CinemaApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class duration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "Duration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "Duration");
        }
    }
}
