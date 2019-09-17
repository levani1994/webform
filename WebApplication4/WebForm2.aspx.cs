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

            //{

            //}
            //Thread.Sleep(5000);
            //Response.Write("this page was generated and cached at:" +
            //    DateTime.Now.ToString());
            lbltime.Text = String.Format("Page posted at: {0}", DateTime.Now.ToLongTimeString());
        }
 //viewstate  gridview databinding  using connect c#
//objectdata source
//calke klasi bazastan kavshiristvis da bazidan monacemebis wamosagebad
        //language change
        protected override void InitializeCulture()
        {


            HttpCookie cookie = Request.Cookies["language"];
           
            if (cookie != null)
            {
                Culture = cookie.Value.ToString();
                UICulture = cookie.Value.ToString();
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cookie.Value.ToString());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cookie.Value.ToString());


                base.InitializeCulture();
            }
        }
        
        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("language");
            cookie.Value = DropDownList.SelectedValue;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
            //Session["lang"] = DropDownList.SelectedValue;
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