using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNewAdvert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["user"];
        if(cookie == null)
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string query = "INSERT INTO adverts (user_id, advert_title, advert_content, advert_photo, advert_category) VALUES (@user_id, @advert_title, @advert_content, @advert_photo, @advert_category)";

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;

        HttpCookie cookie = Request.Cookies["user"];

        command.Parameters.AddWithValue("@user_id", cookie["id"]);
        command.Parameters.AddWithValue("@advert_title", txtTitle.Text);
        command.Parameters.AddWithValue("@advert_content", tbContent.Text);
        command.Parameters.AddWithValue("@advert_photo", fuImage.FileBytes);
        command.Parameters.AddWithValue("@advert_category", ddlCategory.SelectedValue);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Your advert is added successfully. Our team will contact you within 24 hours via email')", true);
        }
        catch (Exception err)
        {
            lblError.Text = err.Message;
        }
        finally
        {
            connection.Close();
        }
    }
}