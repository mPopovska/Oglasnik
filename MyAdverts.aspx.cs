﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MyAdverts : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

            string query = "SELECT * FROM adverts WHERE user_id='" + cookie["id"] + "'";

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
                    LinkButton aTitle = new LinkButton();
                    aTitle.Text = "<h3>" + title + "</h3>";
                    aTitle.Attributes["href"] = "EditAdvert.aspx?id=" + reader["advert_id"];
                    Label lblContent = new Label();
                    lblContent.Text = content;
                    Image img = new Image();
                    img.ImageUrl = "~/ImageHandler.ashx?id=" + reader["advert_id"].ToString();
                    img.Attributes["class"] = "img-responsive";

                    HtmlGenericControl newDiv = new HtmlGenericControl("DIV");
                    newDiv.ID = " div" + i;
                    newDiv.Attributes["class"] = "col-md-4";

                    HtmlGenericControl jumbotron = new HtmlGenericControl("DIV");
                    jumbotron.Attributes["class"] = "jumbotron";
                    jumbotron.Attributes["margin"] = "2px";
                    jumbotron.Attributes["padding"] = "2px";

                    jumbotron.Controls.Add(aTitle);
                    jumbotron.Controls.Add(new LiteralControl("<br />"));
                    jumbotron.Controls.Add(lblContent);
                    jumbotron.Controls.Add(new LiteralControl("<br />"));
                    jumbotron.Controls.Add(img);

                    newDiv.Controls.Add(jumbotron);

                    xmlGeneratedContent.Controls.Add(newDiv);


                    i++;
                }

            }
            catch (Exception err)
            {
                lblerror.Text = err.Message;
            }
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}