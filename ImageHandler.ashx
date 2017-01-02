<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public class ImageHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        Int32 empno;
        if (context.Request.QueryString["id"] != null)
            empno = Convert.ToInt32(context.Request.QueryString["id"]);
        else
            throw new ArgumentException("No parameter specified");

        context.Response.ContentType = "image/jpg";
        
        Stream strm = ShowEmpImage(empno);
        byte[] buffer = new byte[4096];
        int byteSeq = strm.Read(buffer, 0, 4096);

        while (byteSeq > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, byteSeq);
            byteSeq = strm.Read(buffer, 0, 4096);
        }  

        context.Response.Write("Hello World");
    }

    public Stream ShowEmpImage(int empno)
    {
        string conn = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        string sql = "SELECT advert_photo FROM adverts WHERE advert_id=@ID";
        SqlCommand cmd = new SqlCommand(sql,connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID", empno);
        connection.Open();
        object img = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])img);
        }
        catch
        {
            return null;
        }
        finally
        {
            connection.Close();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}