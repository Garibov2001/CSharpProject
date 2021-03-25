namespace CinemaApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FilmCountries",
                c => new
                    {
                        FilmId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilmId, t.CountryId })
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        PublicationDate = c.DateTime(),
                        Duration = c.Int(nullable: false),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FilmJanres",
                c => new
                    {
                        FilmId = c.Int(nullable: false),
                        JanreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilmId, t.JanreId })
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Janres", t => t.JanreId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.JanreId);
            
            CreateTable(
                "dbo.Janres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmJanres", "JanreId", "dbo.Janres");
            DropForeignKey("dbo.FilmJanres", "FilmId", "dbo.Films");
            DropForeignKey("dbo.FilmCountries", "FilmId", "dbo.Films");
            DropForeignKey("dbo.FilmCountries", "CountryId", "dbo.Countries");
            DropIndex("dbo.FilmJanres", new[] { "JanreId" });
            DropIndex("dbo.FilmJanres", new[] { "FilmId" });
            DropIndex("dbo.FilmCountries", new[] { "CountryId" });
            DropIndex("dbo.FilmCountries", new[] { "FilmId" });
            DropTable("dbo.Janres");
            DropTable("dbo.FilmJanres");
            DropTable("dbo.Films");
            DropTable("dbo.FilmCountries");
            DropTable("dbo.Countries");
        }
    }
}
