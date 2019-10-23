using System;

namespace WebApplication4
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

        protected void UserLogin(object sender, EventArgs e)
        {
            UserLoginInfo usr = DALlibrary.CheckLogin(Email.Value,ComputeSha256Hash(Password.Value));

            if (usr.UserEmail == "True")
            {
                
                if (usr.UserRole=="user")
                {
                    Session["user"] = Email.Value;

                    Response.Redirect("Error.html");
                }
                else if (usr.UserRole=="admin")
                    
                {
                    Session["user"] = Email.Value;
                    Response.Redirect("Webform2");
                }
                
            }
            else
            {
                Response.Redirect("Login");
            }

        }

     
    }
}