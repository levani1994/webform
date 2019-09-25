using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public  class Connection : System.Web.UI.Page
    {

        //datanase connection function
        public static SqlConnection conn = null;
        public void Create_Connection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["levaniDBConnectionString"].ConnectionString;

            conn = new SqlConnection(conStr);
            conn.Open();
        }

    }
}