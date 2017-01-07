using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["user"];
        if (cookie != null)
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void btnSignin_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string selectQuery = "SELECT * FROM users";
        string insertQuery = "INSERT INTO users (name, surname, email, username, password)" 
                                + "VALUES(@name, @surname, @email, @username, @password)";

        SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            bool error = false;

            while(reader.Read())
            {
                if(reader["email"].ToString() == txtEmail.Text)
                {
                    lblError.Text = "Корисникот со овој е-маил е веќе регистриран. Обидете се повторно!";
                    error = true;
                    break;
                }
            }

            

            if(!error)
            {
                insertCommand.Parameters.AddWithValue("@name", txtName.Text);
                insertCommand.Parameters.AddWithValue("@surname", txtSurname.Text);
                insertCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                insertCommand.Parameters.AddWithValue("@username", txtUserName.Text);
                insertCommand.Parameters.AddWithValue("@password", txtPassword.Text);
                insertCommand.ExecuteNonQuery();
                lblError.Text = "";

                HttpCookie cookie = new HttpCookie("user");
                cookie["username"] = reader["username"].ToString();
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);

                Response.Redirect("~/Default.aspx");
            }
            reader.Close();
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