using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        
        }

        //language change
        protected override void InitializeCulture()
        {
            if (Session["lang"] != null)
            {
                Culture = Session["lang"].ToString();
                UICulture = Session["lang"].ToString();
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["lang"].ToString());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(Session["lang"].ToString());


                base.InitializeCulture();
            }
        }
        
        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["lang"] = DropDownList.SelectedValue;
            Response.Redirect("WebForm2.aspx");
        }



        //get users from sql
        protected void AddButton(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=levaniDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertIntoDbo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", Name.Text);
            cmd.Parameters.AddWithValue("@AuthotLastname", Surname.Text);
            cmd.Parameters.AddWithValue("@AuthorNationality", Nationality.Text);
            cmd.Parameters.AddWithValue("@Genre", Genre.Text);
            cmd.Parameters.AddWithValue("@Birthdate", Convert.ToDateTime(Birthdate.Text));
            cmd.ExecuteNonQuery();
            Response.Redirect("WebForm2");
            con.Close();
           
        }

        
    }
}