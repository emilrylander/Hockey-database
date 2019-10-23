using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hockey.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Arenas()
        {
            return View();
        }
        public ActionResult Teams()
        {
            return View();
        }
        public ActionResult Matches()
        {
            return View();
        }
    }
}