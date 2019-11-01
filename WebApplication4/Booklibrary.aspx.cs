using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;


namespace WebApplication4
{
    public partial class Booklibrary : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/login.aspx?ReturnUrl=" + Server.UrlEncode(Request.AppRelativeCurrentExecutionFilePath + "?" + Request.QueryString));
            }
            else
            {

                string role = Convert.ToString(Session["user"]);
                if (role == "SuperAdmin")
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
            }

            //Panel1.Visible = true;
            //Panel2.Visible = false;
           
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
            Response.Redirect("Booklibrary.aspx");
        }

        //insert authors in database
        protected void AddAuthor(object sender, EventArgs e)
        {
            Create_Connection();
            SqlCommand cmd = new SqlCommand("InsertAuthors", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrWhiteSpace(Name.Text) || Surname.Text == String.Empty || Nationality.Text == String.Empty || Birthdate.Text == String.Empty)
            {
                Response.Redirect("Booklibrary");
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
                Response.Redirect("Booklibrary");



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
                Response.Redirect("Booklibrary");
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
                Response.Redirect("Booklibrary");
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

        //loguot
        protected void Loguot(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("login.aspx");
        }

        protected void AuthorNamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void SearchAuthorInfoByBookCategory_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}