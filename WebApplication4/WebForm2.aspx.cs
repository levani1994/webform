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
    public partial class WebForm2 : Connection
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
            Response.Redirect("WebForm2.aspx");
        }



        //get users from sql
        protected void AddButton(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("InsertIntoDbo", conn );
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", Name.Text);
            cmd.Parameters.AddWithValue("@AuthotLastname", Surname.Text);
            cmd.Parameters.AddWithValue("@AuthorNationality", Nationality.Text);
            cmd.Parameters.AddWithValue("@Genre", Genre.Text);
            cmd.Parameters.AddWithValue("@Birthdate", Convert.ToDateTime(Birthdate.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            AuthorGrid.DataBind();
            GridView1.DataBind();
          //  Response.Redirect("WebForm2");
        }


        protected void AuthorGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState != DataControlRowState.Edit) // check for RowState
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //check for RowType
                {
                    string id = e.Row.Cells[0].Text; // Get the id to be deleted
                                                     //cast the ShowDeleteButton link to linkbutton
                    LinkButton lb = (LinkButton)e.Row.Cells[6].Controls[2];
                    if (lb != null)
                    {
                        //attach the JavaScript function with the ID as the paramter
                        lb.Attributes.Add("onclick", "return ConfirmOnDelete(" + id + ");");
                    }
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}