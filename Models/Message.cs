using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatWebApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ChatWebApp.Models
{
    public class Message
    {
        public string Name{ get; set; } 
        public string Time { get; set; }
        public string Content { get; set; }

        public static SqlConnection connection()
        {
            SqlConnection con;
            string connetionString;
            connetionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\C#\ChatWebApp\App_Data\aspnet-ChatWebApp-20220103092846.mdf;Initial Catalog=aspnet-ChatWebApp-20220103092846;Integrated Security=True";
            con = new SqlConnection(connetionString);
            con.Open();
            return con;
        }
        public static List<Message> ShowMessages()
        {
            List<Message> messages = new List<Message>();

            SqlConnection con = connection();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql = "Select sender,time,content from AspNetMassages";

            command = new SqlCommand(sql, con);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Message message = new Message()
                {
                    Name = dataReader.GetValue(0) as String,
                    Time = dataReader.GetValue(1) as String,
                    Content = dataReader.GetValue(2) as String
                };

                messages.Add(message);
            }

            dataReader.Close();
            command.Dispose();
            con.Close();

            messages.Reverse();

            return messages;
        }


    }
}