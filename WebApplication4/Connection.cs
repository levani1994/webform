using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication4
{
    public  class BasePage : System.Web.UI.Page
    {

        //datanase connection function
        public static SqlConnection conn = null;
        public void Create_Connection()
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

                conn = new SqlConnection(conStr);
                conn.Open();
            }
            catch (System.Exception ex)
            {

                ex.Message.ToString();
            }
            
        }

    }
}