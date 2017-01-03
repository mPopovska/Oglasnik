using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string query = "SELECT * FROM adverts";

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int i = 1;
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
                img.Width = 300;
                img.Height = 250;

                HtmlGenericControl newDiv = new HtmlGenericControl("DIV");
                newDiv.ID = " col-lg-3 div" + i;

                newDiv.Controls.Add(lblTitle);
                newDiv.Controls.Add(new LiteralControl("<br />"));
                newDiv.Controls.Add(lblContent);
                newDiv.Controls.Add(new LiteralControl("<br />"));
                newDiv.Controls.Add(img);

                xmlGeneratedContent.Controls.Add(newDiv);
                xmlGeneratedContent.ID = "row";

                i++;
            }

        }
        catch(Exception err)
        {
            lblerror.Text = err.Message;
        }

        //Image1.ImageUrl = "~/ImageHandler.ashx?id=" + 1;
    }
}