﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace FinalProject
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void CheepButton_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
            c.Open();
            string insert = "insert into Cheeps (Uname, Cheep, Date, CheepID) values (@uname, @cheep, @date, @id)";
            SqlCommand com = new SqlCommand(insert, c);

            com.Parameters.AddWithValue("uname", Session["Username"].ToString());
            com.Parameters.AddWithValue("cheep", CheepBox.Text);
            com.Parameters.AddWithValue("date", DateTime.Now);
            com.Parameters.AddWithValue("id", Guid.NewGuid());

            com.ExecuteNonQuery();

            Response.Write("Cheep Successful!");
            c.Close();

        }

        protected void CheepButton_Click1(object sender, EventArgs e)
        {

        }
    }
}