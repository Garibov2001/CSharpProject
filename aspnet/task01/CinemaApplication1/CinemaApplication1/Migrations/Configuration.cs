namespace CinemaApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaApplication1.Entities.CinemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaApplication1.Entities.CinemaContext context)
        {
            context.Countries.AddOrUpdate(x => x.Name, //Duplicate datalarin qarsisini almaqdan oteri
                new Entities.Country
                {
                    Name = "Turkey"
                },
                new Entities.Country
                {
                    Name = "USA"
                },
                new Entities.Country
                {
                    Name = "Germany"
                },
                new Entities.Country
                {
                    Name = "Chine"
                },
                new Entities.Country
                {
                    Name = "Pakistan"
                }
            );

            context.Users.AddOrUpdate(x => x.Email,
                new Entities.Account.User
                {
                    Name = "Eldar",
                    LastName = "Zeynalli",
                    Email = "maho@gmail.com",
                    Password = "AO4Q7Spu4Uik5Q31j+mSbjxZh1FxQXouqW+uOHmx1on0gkfBvg/qiR0bbFSducv5tw==",
                }  
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Janres.AddOrUpdate(x => x.Name, //Duplicate datalarin qarsisini almaqdan oteri
                new Entities.Janre
                {
                    Name = "Dram"
                },
                new Entities.Janre
                {
                    Name = "Qorxu"
                },
                new Entities.Janre
                {
                    Name = "Romantika"
                },
                new Entities.Janre
                {
                    Name = "Detektiv"
                }
            );
        }
    }
}
