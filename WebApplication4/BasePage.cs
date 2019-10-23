using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

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

        static public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

       
    }
}