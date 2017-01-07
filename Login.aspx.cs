using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string username = txtUserName.Text;
        string user_password = txtPassword.Text;

        string selectQuery = "SELECT * FROM users WHERE username = '" + username + "'"
                                + " AND password = '" + user_password + "'";

        SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

        try
        {       
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            if (reader.Read())
            {
                lblError.Text = "Successfully loged in ";
                lblError.Text += reader["id"].ToString() + " ";
                lblError.Text += reader["name"].ToString() + " ";
                lblError.Text += reader["surname"].ToString() + " ";
                lblError.Text += reader["email"].ToString() + " ";
                lblError.Text += reader["username"].ToString() + " ";
                lblError.Text += reader["password"].ToString();

                HttpCookie cookie = new HttpCookie("user");
                cookie["username"] = reader["username"].ToString();
                cookie["id"] = reader["id"].ToString();
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);

                if (reader["username"].ToString() == "admin")
                {
                    Response.Redirect("~/AdminDefault.aspx");
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                lblError.Text = "Не постои таков корисник. Внесете валидни податоци или регистрирајте се";
            }
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

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Signup.aspx");
    }
}