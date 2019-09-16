using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddButton(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=levaniDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertIntoDbo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@AuthotLastname", TextBox3.Text);
            cmd.Parameters.AddWithValue("@AuthorNationality", TextBox4.Text);
            cmd.Parameters.AddWithValue("@Genre", TextBox5.Text);
            cmd.Parameters.AddWithValue("@Birthdate", TextBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
