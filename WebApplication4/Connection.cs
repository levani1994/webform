using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public  class Connection : System.Web.UI.Page
    { 

        public static SqlConnection conn = null;
        public void Create_Connection()
        {
            conn = new SqlConnection("Data Source=localhost;Initial Catalog=levaniDB;Integrated Security=True");
            conn.Open();
        }

    }
}