using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MySql.Data.Entity;

namespace Hockey.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {

        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Arena> Arenas { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}