using System;

namespace WebApplication4
{
    public partial class UserControll : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constants.UserSession] == null)
            {
              Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}