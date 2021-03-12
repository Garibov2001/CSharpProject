namespace CinemaApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class film : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Name", c => c.String());
            AlterColumn("dbo.Films", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Duration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Films", "Name", c => c.Int(nullable: false));
        }
    }
}
