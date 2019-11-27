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
            return View();
        }

    }
}