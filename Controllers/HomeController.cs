using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Help()
        {
            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Welcom To our chatting application";
            return View();
        }
    }
}