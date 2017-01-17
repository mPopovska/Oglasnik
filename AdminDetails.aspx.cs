using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string query = "DELETE FROM adverts WHERE advert_id='" + Request.QueryString["id"].ToString() + "'";

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;

        try
        {
            connection.Open();
            command.ExecuteNonQuery();

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add("mateapopovska@gmail.com");
            mailMessage.From = new MailAddress("mateapopovska@gmail.com");
            mailMessage.Subject = "Advert response";
            mailMessage.Body = "Hello world,\n\nYour advert has been deleted!";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("mateapopovska@gmail.com", "");
            smtpClient.Send(mailMessage);
            Response.Write("E-mail sent!");
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            Response.Write("Could not send the e-mail - error: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
        Response.Redirect("~/AdminDefault.aspx");
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string query = "UPDATE adverts set approved=1 WHERE advert_id='" + Request.QueryString["id"].ToString() + "'";

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;

        try
        {
            connection.Open();
            command.ExecuteNonQuery();

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add("mateapopovska@gmail.com");
            mailMessage.From = new MailAddress("mateapopovska@gmail.com");
            mailMessage.Subject = "Advert response";
            mailMessage.Body = "Hello world,\n\nYour advert has been approved!";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("mateapopovska@gmail.com", "");
            smtpClient.Send(mailMessage);
            Response.Write("E-mail sent!");
        }
        catch (Exception err)
        {
            lblerror.Text = err.Message;
        }
        finally
        {
            connection.Close();
        }
        Response.Redirect("~/AdminDefault.aspx");
    }
}