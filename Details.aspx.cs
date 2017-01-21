using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Details : System.Web.UI.Page
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
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string query = "SELECT * FROM adverts WHERE advert_id='" + Request.QueryString["id"].ToString() + "'";

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string title = reader["advert_title"].ToString();
                string content = reader["advert_content"].ToString();
                Label lblTitle = new Label();
                lblTitle.Text = title;
                Label lblContent = new Label();
                lblContent.Text = content;
                Image img = new Image();
                img.ImageUrl = "~/ImageHandler.ashx?id=" + reader["advert_id"].ToString();
                img.Attributes["class"] = "img-responsive";

                //HtmlGenericControl newDiv = new HtmlGenericControl("DIV");
                //newDiv.ID = " col-md-12";
                //newDiv.Attributes["class"] = "col-md-3";

                xmlGeneratedContent.Controls.Add(lblTitle);
                xmlGeneratedContent.Controls.Add(new LiteralControl("<br />"));
                xmlGeneratedContent.Controls.Add(lblContent);
                xmlGeneratedContent.Controls.Add(new LiteralControl("<br />"));
                xmlGeneratedContent.Controls.Add(img);

                //xmlGeneratedContent.Controls.Add(newDiv);
            }
        }
        catch (Exception err)
        {
            lblerror.Text = err.Message;
        }
        connection.Close();
    }
}