using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using System.Net.Http;
using System.Net;

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


        [WebMethod]
        public static void Update(int id, string name, string surname, string email)
        {
               DALlibrary.UpdateUser(id, name, surname, email);
            

         
        }

        public static List<Users> GetUsers()
        {
            var Model = DALlibrary.GetUsers();
            return Model;
        }

        public static List<Role> GetRoles()
        {
            return DALlibrary.GetRoles();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static Users GetUserDetails(int id)
        {
            return DALlibrary.GetUserDetailsByUserId(id);
        }
    }
}