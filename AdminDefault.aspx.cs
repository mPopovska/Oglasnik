﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["user"];
        if (cookie == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (Request.QueryString["logout"] == "1")
        {
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("~/Login.aspx");
        }
        if (cookie["username"] != "admin")
        {
            Response.Redirect("~/Default.aspx");
        }
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string query = "SELECT * FROM adverts WHERE approved=0";

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int i = 1;
            xmlGeneratedContent.Attributes["class"] = "row";
            while (reader.Read())
            {
                string title = reader["advert_title"].ToString();
                string content = reader["advert_content"].ToString();
                //Label lblTitle = new Label();
                //lblTitle.Text = title;
                LinkButton aTitle = new LinkButton();
                aTitle.Text = title;
                aTitle.Attributes["href"] = "AdminDetails.aspx?id=" + reader["advert_id"];
                //lblTitle.Attributes["href"] = "~/AdminDetails.aspx?id='" + reader["advert_id"] + "'"; 
                Label lblContent = new Label();
                lblContent.Text = content;
                Image img = new Image();
                img.ImageUrl = "~/ImageHandler.ashx?id=" + reader["advert_id"].ToString();
                img.Attributes["class"] = "img-responsive";

                HtmlGenericControl newDiv = new HtmlGenericControl("DIV");
                newDiv.ID = " col-md-3 div" + i;
                newDiv.Attributes["class"] = "col-md-3";

                newDiv.Controls.Add(aTitle);
                newDiv.Controls.Add(new LiteralControl("<br />"));
                newDiv.Controls.Add(lblContent);
                newDiv.Controls.Add(new LiteralControl("<br />"));
                newDiv.Controls.Add(img);

                xmlGeneratedContent.Controls.Add(newDiv);


                i++;
            }

        }
        catch (Exception err)
        {
            lblerror.Text = err.Message;
        }

        //Image1.ImageUrl = "~/ImageHandler.ashx?id=" + 1;
    }
}