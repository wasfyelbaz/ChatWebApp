using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatWebApp.Models;
namespace ChatWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Help()
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
            
            return View();
        }
        public ActionResult StartChat(string name)
        {
            Session["user"] = name;
            return View("Chat");
        }
        public ActionResult Chat(string msg)
        {
            Message message = new Message()
            {
                Name =Session["user"] as String ,
                Time = DateTime.Now ,
                Content  = msg 
            };
            return PartialView("Message" , message);
        }

    }
}