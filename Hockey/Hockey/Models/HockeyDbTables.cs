using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column("arena_id")]
        public int ArenaID { get; set; }
        [Column("hometeam_id")]
        public int HomeTeamID { get; set; }
        [Column("homescore")]
        public int HomeTeamScore { get; set; }
        [Column("goneteam_id")]
        public int GoneTeamID { get; set; }
        [Column("gonescore")]
        public int GoneTeamScore { get; set; }

    }
}