using System;

using System.Data;
using System.Data.SqlClient;
using System.Globalization;

using System.Threading;
using System.Web;


using System.Web.UI.WebControls;


namespace WebApplication4
{
    public partial class WebForm2 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login");
            }
            else
            {


                string role = string.Empty;
                role = Convert.ToString(Session["user"]);
                if (role == null)
                {
                    Response.Redirect("Registration");
                }
                else if (role == "user")
                {
                    Authors_div.Visible = false;
                    Author_GridView.Columns[0].Visible = false;
                    Author_GridView.Columns[6].Visible = false;
                    Author_GridView.Columns[7].Visible = false;
                    Book_gridview.Columns[0].Visible = false;
                    Books_div.Visible = false;
                    AddUserToggle.Visible = false;
                    AddBookToggle.Visible = false;
                }

                else if (role == "admin")
                {
                    
                }

            }
        }

        //language coockies
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
        //language change
        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("language");
            cookie.Value = DropDownList.SelectedValue;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
            Response.Redirect("WebForm2.aspx");
        }


        //insert authors in database
        protected void AddAuthor(object sender, EventArgs e)
        {
            Create_Connection();
            SqlCommand cmd = new SqlCommand("InsertAuthors", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrWhiteSpace(Name.Text) || Surname.Text == String.Empty || Nationality.Text == String.Empty || Birthdate.Text == String.Empty)
            {
                Response.Redirect("WebForm2");
            }
            else
            {
                cmd.Parameters.AddWithValue("@AuthorName", Name.Text);
                cmd.Parameters.AddWithValue("@AuthorLastname", Surname.Text);
                cmd.Parameters.AddWithValue("@AuthorNationality", Nationality.Text);
                cmd.Parameters.AddWithValue("@Birthdate", Convert.ToDateTime(Birthdate.Text));
                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@DateInserted", DateTime.Now);
                cmd.Parameters.AddWithValue("@AllowAuthor", true);
                cmd.ExecuteNonQuery();
                conn.Close();
                Author_GridView.DataBind();
                Response.Redirect("WebForm2");



            }

        }


        //insert books in database
        public void AddBook(object sender, EventArgs e)
        {
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("InsertBook", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (BookName.Text == String.Empty || BookDescribtion.Text == string.Empty || AuthorNamesDropdown.SelectedValue == null || GenresDropdown.SelectedValue == null)
            {
                Response.Redirect("WebForm2");
            }
            else
            {
                cmd.Parameters.AddWithValue("@BookName", BookName.Text);
                cmd.Parameters.AddWithValue("@BookDescribtion", BookDescribtion.Text);
                cmd.Parameters.AddWithValue("@ReleaseDate", Convert.ToInt32(BookReleaseDate.Text));
                cmd.Parameters.AddWithValue("@AuthorID", AuthorNamesDropdown.SelectedValue);
                cmd.Parameters.AddWithValue("@GenreID", GenresDropdown.SelectedValue);
                cmd.ExecuteNonQuery();
                conn.Close();
                Author_GridView.DataBind();
                Response.Redirect("WebForm2");
            }
        }



        //alert for delete 
        protected void AuthorGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState != DataControlRowState.Edit) // check for RowState
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //check for RowType
                {
                    string id = e.Row.Cells[0].Text; // Get the id to be deleted
                                                     //cast the ShowDeleteButton link to linkbutton
                    LinkButton lb = (LinkButton)e.Row.Cells[7].Controls[2];
                    if (lb != null)
                    {
                        //attach the JavaScript function with the ID as the paramter
                        lb.Attributes.Add("onclick", "return ConfirmOnDelete(" + id + ");");
                    }
                }
            }
        }


        protected void Loguot(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("login.aspx");
        }
    }
}