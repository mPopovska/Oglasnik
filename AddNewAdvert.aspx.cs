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

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string query = "INSERT INTO adverts (user_id, advert_title, advert_content, advert_photo) VALUES (@user_id, @advert_title, @advert_content, @advert_photo)";

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;

        command.Parameters.AddWithValue("@user_id", 1);
        command.Parameters.AddWithValue("@advert_title", txtTitle.Text);
        command.Parameters.AddWithValue("@advert_content", tbContent.Text);
        command.Parameters.AddWithValue("@advert_photo", fuImage.FileBytes);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
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