using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class Registration : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UserRegistration(object sender, EventArgs e)
        {

            if (FirstName.Value == string.Empty ||   LastName.Value==string.Empty || Email.Value==string.Empty || Password.Value==string.Empty  || Password.Value != RepeatPassword.Value)
            {
                Response.Redirect("registration");

            }
            else
            {
              
                //BasePage connection = new BasePage();
                //connection.Create_Connection();
                Create_Connection();
                SqlCommand cmd = new SqlCommand("AddUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", FirstName.Value);
                cmd.Parameters.AddWithValue("@LastName", LastName.Value);
                cmd.Parameters.AddWithValue("@Email", Email.Value);
                cmd.Parameters.AddWithValue("@Password", ComputeSha256Hash( Password.Value));
                cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Role", "user");
                cmd.ExecuteNonQuery();
                Response.Redirect("WebForm2");
                conn.Close();
            }










        }
    }
}