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
            string ReturnUrl = Convert.ToString(Request.QueryString["url"]);
            if (usr.UserEmail == Resources.GlobalResources.IsLogged)
            {
                Session[Constants.UserSession] = usr.RoleName;
                if (ReturnUrl == null)
                {
                    Response.Redirect("Booklibrary.aspx");
                }
                Response.Redirect(ReturnUrl);
            }
            else
             {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('არასწორი მეილი ან პაროლი')</script>");
             }
        }

    }
}
