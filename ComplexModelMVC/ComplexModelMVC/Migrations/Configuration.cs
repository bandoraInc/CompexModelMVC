namespace ComplexModelMVC.Migrations
{
    using ComplexModelMVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportEncyclopediaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportEncyclopediaContext context)
        {
            context.Federations.AddOrUpdate(
              x => x.Id,
              new Federation { Id = 1, Name = "FIFA", Slogan = "FIFA.png", BelongsTo = null }
              );
            context.SaveChanges();
           context.Federations.AddOrUpdate(
               x => x.Id,
               new Federation { Id = 1, Name = "FIFA", Slogan = "FIFA.png", BelongsTo = null },
               new Federation { Id = 2, Name = "AFC", Slogan = "AFC.png", BelongsTo = context.Federations.Single(f => f.Name == "FIFA") },
               new Federation { Id = 3, Name = "CAF ", Slogan = "CAF.png", BelongsTo = context.Federations.Single(f => f.Name == "FIFA") },
               new Federation { Id = 4, Name = "CONCACAF ", Slogan = "CONCACAF.png", BelongsTo = context.Federations.Single(f => f.Name == "FIFA") },
               new Federation { Id = 5, Name = "CONMEBOL", Slogan = "CONMEBOL.png", BelongsTo = context.Federations.Single(f => f.Name == "FIFA") },
               new Federation { Id = 6, Name = "OFC ", Slogan = "OFC.png", BelongsTo = context.Federations.Single(f => f.Name == "FIFA") },
               new Federation { Id = 7, Name = "UEFA ", Slogan = "UEFA.png", BelongsTo = context.Federations.Single(f => f.Name == "FIFA") }
               );
            context.Countries.AddOrUpdate(
                  x => x.Id,
                         new Country { Id = 1, Name = "Argentina", FlagURL = "Argentina.png", Federation =context.Federations.Single(f => f.Name == "CONMEBOL") },
                         new Country { Id = 2, Name = "Spain", FlagURL = "Spain.png", Federation = context.Federations.Single(f => f.Name == "UEFA") },
                         new Country { Id = 3, Name = "England", FlagURL = "England.png", Federation = context.Federations.Single(f => f.Name == "UEFA") },
                         new Country { Id = 4, Name = "Portugal", FlagURL = "Portugal.png", Federation = context.Federations.Single(f => f.Name == "UEFA") },
                         new Country { Id = 5, Name = "Italy", FlagURL = "Italy.png", Federation = context.Federations.Single(f => f.Name == "UEFA") },
                         new Country { Id = 6, Name = "Jordan", FlagURL = "Jordan.png", Federation = context.Federations.Single(f => f.Name == "AFC") },
                         new Country { Id = 7, Name = "Egypt", FlagURL = "Egypt.png", Federation = context.Federations.Single(f => f.Name == "CAF") },
                         new Country { Id = 8, Name = "France", FlagURL = "France.png", Federation = context.Federations.Single(f => f.Name == "UEFA") }
                );
          context.Clubs.AddOrUpdate(
               x => x.Id,
                      new Club { Id = 1, Name = "Real Madrid", Country= context.Countries.Single(c=>c.Name == "Spain"), Slogan = "realmadrid.png" },
                      new Club { Id = 2, Name = "Juventus", Country = context.Countries.Single(c => c.Name == "Italy"), Slogan = "juventus.png" },
                      new Club { Id = 3, Name = "Manchester United", Country = context.Countries.Single(c => c.Name == "England"), Slogan = "manchesterunited.png" },
                      new Club { Id = 4, Name = "Manchester City", Country = context.Countries.Single(c => c.Name == "England"), Slogan = "manchestercity.png" },
                      new Club { Id = 5, Name = "Barcelona", Country = context.Countries.Single(c => c.Name == "Spain"), Slogan = "Barcelona.png" },
                      new Club { Id = 6, Name = "Wehdat", Country = context.Countries.Single(c => c.Name == "Jordan"), Slogan = "wehdat.png" },
                      new Club { Id = 7, Name = "Zamalek", Country = context.Countries.Single(c => c.Name == "Egypt"), Slogan = "zamalek.png" }
               );
        context.Managers.AddOrUpdate(
             x => x.Id,
                    new Manager { Id = 1, FirstName = "Zinedine", LastName = "Zidan", Photo = "zidan.jpg", Certificate = "A+", BirthDate = DateTime.Parse("1972-06-23") },
                   new Manager { Id = 2, FirstName = "Jose", LastName = "Moruhinho", Photo = "josemourinho.jpg", Certificate = "A+", BirthDate = DateTime.Parse("1963-01-26") },
                   new Manager { Id = 3, FirstName = "Massimiliano", LastName = "Allegri", Photo = "massimilianoallegri.jpg", Certificate = "A+", BirthDate = DateTime.Parse("1967-08-11") },
                   new Manager { Id = 4, FirstName = "Pep", LastName = "Guardiola", Photo = "pepguardiola.jpg", Certificate = "A+", BirthDate = DateTime.Parse("1971-01-18") },
                   new Manager { Id = 5, FirstName = "Luis", LastName = "Enrique", Photo = "luisenrique.jpg", Certificate = "A+", BirthDate = DateTime.Parse("1970-05-8")},
                   new Manager { Id = 6, FirstName = "Jamal", LastName = "Mahmoud", Photo = "jamalmahmoud.jpg", Certificate = "A+", BirthDate = DateTime.Parse("1973-05-1") },
                   new Manager { Id = 7, FirstName = "Augusto", LastName = "Inacio", Photo = "augustoinacio.jpg", Certificate = "A+", BirthDate = DateTime.Parse("1955-01-30")}
         );
        context.Players.AddOrUpdate(
               x => x.Id,
               new Player { Id = 1, FirstName = "Cristiano", LastName = "Ronaldo", BirthDate = DateTime.Parse("1985-2-5"), Country = context.Countries.Single (c=>c.Name == "Portugal"), Club = context.Clubs.Single(c => c.Name == "Real Madrid"), Photo = "Cristiano_Ronaldo.jpg", Position = Position.CF },
               new Player { Id = 2, FirstName = "Lionel", LastName = "Messi", BirthDate = DateTime.Parse("1987-6-24"), Country = context.Countries.Single(c => c.Name == "Argentina"), Club = context.Clubs.Single(c => c.Name == "Barcelona"), Photo = "Lionel_Messi.jpg", Position = Position.CF },
               new Player { Id = 3, FirstName = "Paul", LastName = "Pogba", BirthDate = DateTime.Parse("1993-3-5"), Country = context.Countries.Single(c => c.Name == "France"), Club = context.Clubs.Single(c => c.Name == "Manchester United"), Photo = "Paul_Pogba.jpg", Position = Position.CM },
               new Player { Id = 4, FirstName = "Sergio", LastName = "Aguero", BirthDate = DateTime.Parse("1988-6-2"), Country = context.Countries.Single(c => c.Name == "Argentina"), Club = context.Clubs.Single(c => c.Name == "Manchester City"), Photo = "Sergio_Aguero.jpg", Position = Position.CF },
               new Player { Id = 5, FirstName = "Gianluigi", LastName = "Buffon", BirthDate = DateTime.Parse("1978-1-28"), Country = context.Countries.Single(c => c.Name == "Italy"), Club = context.Clubs.Single(c => c.Name == "Juventus"), Photo = "Gianluigi_Buffon.jpg", Position = Position.GK },
               new Player { Id = 6, FirstName = "Mohammad", LastName = "Al-Dmeiri", BirthDate = DateTime.Parse("1987-8-23"), Country = context.Countries.Single(c => c.Name == "Jordan"), Club = context.Clubs.Single(c => c.Name == "Wehdat"), Photo = "Mohammad_AlDmeiri", Position = Position.LB },
               new Player { Id = 7, FirstName = "Mahmoud", LastName = "Shikabala", BirthDate = DateTime.Parse("1986-3-4"), Country = context.Countries.Single(c => c.Name == "Egypt"), Club = context.Clubs.Single(c => c.Name == "Zamalek"), Photo = "Mahmoud_Shikabala.jpg", Position = Position.LM }
        );
        }
    }
}
