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
            return View();
        }
        public ActionResult Teams()
        {
            List<Team> teams = dbContext.Teams.ToList();
            return View(teams);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamName")]Team team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.Teams.Add(team);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch 
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(team);
        }

        public ActionResult Matches()
        {
            return View();
        }

        public class TeamController : Controller
        {
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "TeamName")]Team team)
            {
                return View();
            }
        }
    }
}