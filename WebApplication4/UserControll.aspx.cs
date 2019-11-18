using System;
using System.Web.Script.Services;
using System.Web.Services;

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
         [WebMethod]
        
         [ScriptMethod(UseHttpGet = true)]
        public static void Update(int id)
        {
            DALlibrary.DeleteAuthor(id);
        }

    }
}