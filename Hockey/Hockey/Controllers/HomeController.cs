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
        public ActionResult CreateTeam([Bind(Include = "Teamname")]Team Teamname)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.Teams.Add(Teamname);
                    dbContext.SaveChanges();
                    return RedirectToAction("Teams");
                }
            }
            catch 
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View("Teams");
        }

        public ActionResult Matches()
        {
            return View();
        }


    }
}