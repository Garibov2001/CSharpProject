using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaApplication1.Entities
{
    public class CinemaContext : DbContext
    {
        public CinemaContext() 
            : base("name=CinemaDB")
        {

        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public DbSet<Janre> Janres { get; set; }
        public DbSet<FilmCountry> FilmCountries { get; set; }
        public DbSet<FilmJanre> FilmJanres { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Film Country
            modelBuilder.Entity<FilmCountry>().HasKey(c => new { c.FilmId, c.CountryId });

            modelBuilder.Entity<Film>()
                .HasMany(x => x.FilmCountries)
                .WithRequired()
                .HasForeignKey(c => c.FilmId);

            modelBuilder.Entity<Country>()
            .HasMany(x => x.FilmCountries)
            .WithRequired()
            .HasForeignKey(c => c.CountryId);
            #endregion

            #region Film Genre
            modelBuilder.Entity<FilmJanre>().HasKey(c => new { c.FilmId, c.JanreId });

            modelBuilder.Entity<Film>()
                .HasMany(x => x.FilmJanres)
                .WithRequired()
                .HasForeignKey(c => c.FilmId);

            modelBuilder.Entity<Janre>()
            .HasMany(x => x.FilmJanres)
            .WithRequired()
            .HasForeignKey(c => c.JanreId);
            #endregion
        }

    }
}