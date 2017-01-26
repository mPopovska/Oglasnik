using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditAdvert : System.Web.UI.Page
{
    public TextBox tbTitle;
    public TextBox tbContent;
    public Image img;

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
                //Label lblTitle = new Label();
                //lblTitle.Text = title;
                tbTitle = new TextBox();
                tbTitle.Text = title;
                tbTitle.Width = 400;
                tbTitle.Attributes["class"] = "tbTitle_margin";
                tbContent = new TextBox();
                tbContent.TextMode = TextBoxMode.MultiLine;
                tbContent.Width = 400;
                tbContent.Height = 200;
                tbContent.Text = content;
                tbContent.Attributes["class"] = "tbContent_margin";
                img = new Image();
                img.ImageUrl = "~/ImageHandler.ashx?id=" + reader["advert_id"].ToString();
                img.Attributes["class"] = "img-responsive";
                img.Attributes["class"] = "img_maring";

                //HtmlGenericControl newDiv = new HtmlGenericControl("DIV");
                //newDiv.ID = " col-md-12";
                //newDiv.Attributes["class"] = "col-md-3";

                xmlGeneratedContent.Controls.Add(tbTitle);
                xmlGeneratedContent.Controls.Add(new LiteralControl("<br />"));
                xmlGeneratedContent.Controls.Add(tbContent);
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

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        string query;

        if(newImage.Visible)
        {
            query = "UPDATE adverts set advert_title=@advert_title, advert_content=@advert_content, advert_photo=@advert_photo WHERE advert_id='" + Request.QueryString["id"].ToString() + "'";
        }
        else
        {
            query = "UPDATE adverts set advert_title=@advert_title, advert_content=@advert_content WHERE advert_id='" + Request.QueryString["id"].ToString() + "'";

        }

        SqlCommand command = new SqlCommand();
        command.Parameters.AddWithValue("@advert_title", tbTitle.Text);
        command.Parameters.AddWithValue("@advert_content", tbContent.Text);

        if(newImage.Visible)
        {
            command.Parameters.AddWithValue("@advert_photo", newImage.FileBytes);
        }
        
        command.Connection = connection;
        command.CommandText = query;

        try
        {
            connection.Open();
            command.ExecuteNonQuery();

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add("mateapopovska@gmail.com");
            mailMessage.From = new MailAddress("mateapopovska@gmail.com");
            mailMessage.Subject = "ФИНКИ Огласник";
            mailMessage.Body = "Почитуван кориснику,\n\nВашиот оглас е променет!\n\nВаш,\nФИНКИ Огласник";
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

        img.Visible = true;
        newImage.Visible = false;
        Response.Redirect("~/MyAdverts.aspx");
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
            mailMessage.Subject = "ФИНКИ Огласник";
            mailMessage.Body = "Почитуван кориснику,\n\nВашиот оглас е избришан!\n\nВаш,\nФИНКИ Огласник";
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

    protected void btnChangeImage_Click(object sender, EventArgs e)
    {
        img.Visible = false;
        newImage.Visible = true;
    }
}