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

        [HttpPost]
        public ActionResult AddArenas([Bind(Include = "Arenaname")]Arena model)
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

        [HttpPost]
        public ActionResult RemoveArena([Bind(Include = "Arenaname")]Arena model)
        {
            try
            {
                Arena ArenaToRemove = dbContext.Arenas.Where(x => x.Arenaname == model.Arenaname).FirstOrDefault();
                dbContext.Arenas.Remove(ArenaToRemove);
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
        public ActionResult AddTeams([Bind(Include = "Teamname")]Team model)
        {
            try
            {
                List<Team> Teams = dbContext.Teams.ToList();

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

        [HttpPost]
        public ActionResult RemoveTeams([Bind(Include = "Teamname")]Team model)
        {
            try
            {
                Team teamToRemove = dbContext.Teams.Where(x => x.Teamname == model.Teamname).FirstOrDefault();
                dbContext.Teams.Remove(teamToRemove);
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
                viewMatch.GoneTeam = dbContext.Teams.Find(match.GoneTeamID).Teamname;
                viewMatch.HomeScore = match.HomeTeamScore;
                viewMatch.GoneScore = match.GoneTeamScore;
                viewMatch.Arena = dbContext.Arenas.Find(match.ArenaID).Arenaname;
            
                modelMatches.Add(viewMatch);
            }

            return View(modelMatches);
        }

        [HttpPost]
        public ActionResult Matches([Bind(Include = "Teamname")]Match model)
        {
            try
            {
                List<Match> Matches = dbContext.Matches.ToList();

                Match Form = new Match();
                Form.ArenaID = model.ArenaID;
                Form.HomeTeamID = model.HomeTeamID;
                Form.GoneTeamID = model.GoneTeamID;
                Form.HomeTeamScore = model.HomeTeamScore;
                Form.GoneTeamScore = model.GoneTeamScore;
                dbContext.Matches.Add(Form);

                dbContext.SaveChanges();

                return RedirectToAction("matches");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}