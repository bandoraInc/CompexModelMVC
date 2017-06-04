using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ComplexModelMVC.Models
{
    public class SportEncyclopediaContext : DbContext
    {
        public SportEncyclopediaContext()
            :base("SportEncyclopedia")
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Federation> Federations { get; set; }
        public DbSet<Transfer> Transfer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
 
    }
}