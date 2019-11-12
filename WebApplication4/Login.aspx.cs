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

            if (usr.UserEmail == Resources.GlobalResources.IsLogged)
            {
                Session[Constants.UserSession] = usr.UserRole;
                Response.Redirect("Booklibrary.aspx");
            }
            else
             {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('არასწორი მეილი ან პაროლი')</script>");
             }
        }

    }
}
