using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hockey.Models
{

    public class Team
    {
        public int ID { get; set; }
        public string Teamname { get; set; }
    }
    public class TeamDBContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
    }

    public class Arena
    {
        public int ID { get; set; }
        public string Arenaname { get; set; }
    }
    public class Match
    {
        public int ID { get; set; }
        public int ArenaID { get; set; }
        public int HomeTeamID { get; set; }
        public int HomeTeamScore { get; set; }
        public int GoneTeamID { get; set; }
        public int GoneTeamScore { get; set; }

    }
}