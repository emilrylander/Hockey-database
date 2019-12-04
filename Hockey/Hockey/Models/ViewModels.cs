using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hockey.Models
{
    public class MatchViewModel
    {
        public string Arena { get; set; }
        public string HomeTeam { get; set; }
        public string GoneTeam { get; set; }
        public int HomeScore { get; set; }
        public int GoneScore { get; set; }

        public List<Arena> ArenaList = new List<Arena>();
        public List<Team> TeamList = new List<Team>();
    }
}