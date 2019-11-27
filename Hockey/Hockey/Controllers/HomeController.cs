using Hockey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hockey.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext dbContext = new DatabaseContext();


        public ActionResult Arenas()
        {

            List<Arena> Arenas = dbContext.Arenas.ToList();
            return View(Arenas);
        }

        /*
         * POST: sends Arenas
         * */
        [HttpPost]
        public ActionResult Arenas([Bind(Include = "Arenaname")]Arena model)
        {
            try
            {

                List<Arena> Arenas = dbContext.Arenas.ToList();

                Arena a = new Arena();
                a.Arenaname = model.Arenaname;

                dbContext.Arenas.Add(a);
                dbContext.SaveChanges();

                return RedirectToAction("Arenas");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult Teams()
        {
            List<Team> teams = dbContext.Teams.ToList();
            return View(teams);
        }

        [HttpPost]
        public ActionResult Teams([Bind(Include = "Teamname")]Team model)
        {
            try
            {
                List<Team> Teamns = dbContext.Teams.ToList();

                Team a = new Team();
                a.Teamname = model.Teamname;

                dbContext.Teams.Add(a);
                dbContext.SaveChanges();

                return RedirectToAction("Teams");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult matches()
        {
            List<MatchViewModel> modelMatches = new List<MatchViewModel>();
            List<Match> matches = dbContext.Matches.ToList();

            foreach(Match match in matches)
            {
                MatchViewModel viewMatch = new MatchViewModel();
                viewMatch.HomeTeam = dbContext.Teams.Find(match.HomeTeamID).Teamname;
                viewMatch.AwayTeam = dbContext.Teams.Find(match.GoneTeamID).Teamname;
                viewMatch.HomeScore = match.HomeTeamScore;
                viewMatch.GoneScore = match.GoneTeamScore;
                viewMatch.Arena = dbContext.Arenas.Find(match.ArenaID).Arenaname;
            
                modelMatches.Add(viewMatch);
            }

            return View(modelMatches);
        }

    }
}