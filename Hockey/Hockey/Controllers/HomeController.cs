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
            MatchesViewModel viewModel = new MatchesViewModel();

            List<MatchViewModel> modelMatches = GetMatches();

            viewModel.matches = modelMatches;
            viewModel.ArenaList = dbContext.Arenas.ToList();
            viewModel.TeamList = dbContext.Teams.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddMatches( int Arena, int HomeTeam, int GoneTeam, int HomeScore, int GoneScore)
        {
            if(Arena == 0 || HomeTeam == 0 || GoneTeam == 0)
            {
                if(Arena == 0)
                    ModelState.AddModelError("", "Must select a Arena!");
                if(HomeTeam == 0)
                    ModelState.AddModelError("", "Must select a Home Team!");
                if(GoneTeam == 0)
                    ModelState.AddModelError("", "Must select a Gone Team!");

                MatchesViewModel viewModel = new MatchesViewModel();
                viewModel.matches = GetMatches();
                viewModel.ArenaList = dbContext.Arenas.ToList();
                viewModel.TeamList = dbContext.Teams.ToList();

                return View("matches", viewModel);
            }
            try
            {
                List<Match> Matches = dbContext.Matches.ToList();

                Match Form = new Match();
                Form.ArenaID = Arena;
                Form.HomeTeamID = HomeTeam;
                Form.GoneTeamID = GoneTeam;
                Form.HomeTeamScore = HomeScore;
                Form.GoneTeamScore = GoneScore;
                dbContext.Matches.Add(Form);


                dbContext.SaveChanges();

                return RedirectToAction("matches");
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("matches");
            }
        }

        [HttpPost]
        public ActionResult RemoveMatches([Bind(Include = "ID")]Match model)
        {
            try
            {
                Match matchToRemove = dbContext.Matches.Where(x => x.ID == model.ID).FirstOrDefault();
                dbContext.Matches.Remove(matchToRemove);
                dbContext.SaveChanges();

                return RedirectToAction("matches");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MatchViewModel> GetMatches()
        {
            List<MatchViewModel> modelMatches = new List<MatchViewModel>();
            List<Match> dbMatches = dbContext.Matches.ToList();

            foreach (Match dbMatch in dbMatches)
            {
                MatchViewModel viewMatch = new MatchViewModel();

                viewMatch.ID = dbContext.Matches.Find(dbMatch.ID).ID;
                viewMatch.HomeTeam = dbContext.Teams.Find(dbMatch.HomeTeamID).Teamname;
                viewMatch.GoneTeam = dbContext.Teams.Find(dbMatch.GoneTeamID).Teamname;
                viewMatch.HomeScore = dbMatch.HomeTeamScore;
                viewMatch.GoneScore = dbMatch.GoneTeamScore;
                viewMatch.Arena = dbContext.Arenas.Find(dbMatch.ArenaID).Arenaname;

                modelMatches.Add(viewMatch);
            }

            return modelMatches;
        }
    }
}