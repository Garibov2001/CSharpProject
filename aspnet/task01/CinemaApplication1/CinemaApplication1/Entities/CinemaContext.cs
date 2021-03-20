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

        public DbSet<Country> Countries { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Janre> Janres { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

        }

    }
}