using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatWebApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ChatWebApp.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {

        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string connetionString;
            connetionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=E:\Ain Shams\WEB\F6\App_Data\aspnet-ChatWebApp-20220103092846.mdf;Initial Catalog=aspnet-ChatWebApp-20220103092846;Integrated Security=True";
            con = new SqlConnection(connetionString);
            con.Open();
        }
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

        public void AddMessage(Message message)
        {
            connection();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = $"Insert into AspNetMassages(sender,time,content) values('{message.Name}', '{message.Time}', '{message.Content}')";

            command = new SqlCommand(sql, con);
            adapter.InsertCommand = new SqlCommand(sql, con);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose(); 
		    con.Close();
        }

        public ActionResult Chat(string msg)
        {
            Message message = new Message()
            {
                Name = Session["user"] as String ,
                Time = DateTime.Now.ToString(),
                Content = msg 
            };

            if (message.Content != "")
            {
                AddMessage(message);
            }

            return PartialView("Message", message);
        }

    }
}