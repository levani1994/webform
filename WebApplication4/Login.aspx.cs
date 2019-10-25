using System;

namespace WebApplication4
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
        
        protected void UserLogin(object sender, EventArgs e)
        {
            UserLoginInfo usr = DALlibrary.CheckLogin(Email.Value, ComputeSha256Hash(Password.Value));

            if (usr.UserEmail == "True")
             {
                if (usr.UserRole == "user")
                {
                    Session["user"] = usr.UserRole;
                    Response.Redirect("Booklibrary");
                }
                else if (usr.UserRole == "admin")
                {
                    Session["user"] = usr.UserRole;
                    Response.Redirect("Booklibrary");
                }
             }
            else
             {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('არასწორი მეილი ან პაროლი')</script>");
             }
        }

    }
}
