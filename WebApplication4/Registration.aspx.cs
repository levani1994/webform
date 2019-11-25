using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace WebApplication4
{
    public partial class Registration : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

        //registration
        protected void UserRegistration(object sender, EventArgs e)
        {
            if (FirstName.Value == string.Empty || LastName.Value == string.Empty || Email.Value == string.Empty || Password.Value == string.Empty || RepeatPassword.Value == string.Empty)
            {
                Response.Redirect("registration");
            }
            else if (Password.Value != RepeatPassword.Value)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('passwords don't match')</script>");
            }
            else if (Password.Value.Length < 8 || Password.Value.Length > 16)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('password must be 8-16 characters')</script>");
            }
            else
            {



                HttpPostedFile postedFile = inputGroupFile01.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int filesize = postedFile.ContentLength;
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    Create_Connection();
                    SqlCommand cmd = new SqlCommand("AddUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", FirstName.Value);
                    cmd.Parameters.AddWithValue("@LastName", LastName.Value);
                    cmd.Parameters.AddWithValue("@Email", Email.Value);
                    cmd.Parameters.AddWithValue("@Password", ComputeSha256Hash(Password.Value));
                    cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ImageName", filename);
                    cmd.Parameters.AddWithValue("@ImageSize", filesize);
                    cmd.Parameters.AddWithValue("@ImageData", bytes);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Success.html");
                    conn.Close();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
                }

            }





        }

    }
}
