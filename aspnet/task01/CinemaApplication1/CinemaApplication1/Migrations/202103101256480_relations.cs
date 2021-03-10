namespace CinemaApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilmCountries",
                c => new
                    {
                        Film_FilmID = c.Int(nullable: false),
                        Country_CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_FilmID, t.Country_CountryID })
                .ForeignKey("dbo.Films", t => t.Film_FilmID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_CountryID, cascadeDelete: true)
                .Index(t => t.Film_FilmID)
                .Index(t => t.Country_CountryID);
            
            CreateTable(
                "dbo.JanreFilms",
                c => new
                    {
                        Janre_JanreID = c.Int(nullable: false),
                        Film_FilmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Janre_JanreID, t.Film_FilmID })
                .ForeignKey("dbo.Janres", t => t.Janre_JanreID, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_FilmID, cascadeDelete: true)
                .Index(t => t.Janre_JanreID)
                .Index(t => t.Film_FilmID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JanreFilms", "Film_FilmID", "dbo.Films");
            DropForeignKey("dbo.JanreFilms", "Janre_JanreID", "dbo.Janres");
            DropForeignKey("dbo.FilmCountries", "Country_CountryID", "dbo.Countries");
            DropForeignKey("dbo.FilmCountries", "Film_FilmID", "dbo.Films");
            DropIndex("dbo.JanreFilms", new[] { "Film_FilmID" });
            DropIndex("dbo.JanreFilms", new[] { "Janre_JanreID" });
            DropIndex("dbo.FilmCountries", new[] { "Country_CountryID" });
            DropIndex("dbo.FilmCountries", new[] { "Film_FilmID" });
            DropTable("dbo.JanreFilms");
            DropTable("dbo.FilmCountries");
        }
    }
}
