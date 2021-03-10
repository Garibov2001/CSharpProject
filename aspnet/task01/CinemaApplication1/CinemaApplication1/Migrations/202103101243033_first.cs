namespace CinemaApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        PublicationDate = c.DateTime(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.FilmID);
            
            CreateTable(
                "dbo.Janres",
                c => new
                    {
                        JanreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.JanreID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Janres");
            DropTable("dbo.Films");
            DropTable("dbo.Countries");
        }
    }
}
