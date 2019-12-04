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
    }

    public class MatchesViewModel
    {
        public List<MatchViewModel> matches { get; set; }
        public List<Arena> ArenaList { get; set; }
        public List<Team> TeamList { get; set; }
    }
}