using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class UserControll : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constants.UserSession] == null)
            {
                Response.Redirect("~/login.aspx?ReturnUrl=" + Server.UrlEncode(Request.AppRelativeCurrentExecutionFilePath + "?" + Request.QueryString));
            }
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}