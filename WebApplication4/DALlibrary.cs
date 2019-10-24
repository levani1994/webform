using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;


using System.Text.RegularExpressions;
namespace WebApplication4
{
    public class DALlibrary : BasePage
    {
        //get authors from database
        public static List<Authors> GetAuthors()
        {
            List<Authors> listAuthors = new List<Authors>();
            BasePage connection = new BasePage();
            connection.Create_Connection();

            SqlCommand cmd = new SqlCommand("getAuthors", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Authors authors = new Authors();
                authors.ID = Convert.ToInt32(reader["ID"]);
                authors.Name = reader["AuthorName"].ToString();
                authors.Surname = reader["AuthorLastname"].ToString();
                authors.Nationality = reader["AuthorNationality"].ToString();
                authors.Birthdate = Convert.ToDateTime(reader["Birthdate"].ToString());
                authors.Email = reader["Email"].ToString();
                authors.AllowAuthor = Convert.ToBoolean(reader["AllowAuthor"]);
                listAuthors.Add(authors);
            }
            conn.Close();
            return listAuthors;
        }

        //get books from database
        public static List<Books> GetBooks()
        {
            List<Books> listBooks = new List<Books>();
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("GetBooks", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Books books = new Books();
                books.Id = Convert.ToInt32(reader["ID"]);
                books.BookName = reader["BookName"].ToString();
                books.BookDescribtion = reader["BookDescribtion"].ToString();
                books.ReleaseDate = Convert.ToInt32(reader["ReleaseDate"]);
                books.AuthorName = reader["AuthorName"].ToString();
                books.Genre = reader["Genre"].ToString();

                listBooks.Add(books);
            }
            conn.Close();
            return listBooks;
        }

        //get author names from database
        public static List<Authors> GetAuthorNames()
        {
            List<Authors> listAuthors = new List<Authors>();
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("GetAuthorNames", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Authors authors = new Authors();
                authors.ID = Convert.ToInt32(reader["ID"]);
                authors.Name = reader["AuthorName"].ToString();
                listAuthors.Add(authors);
            }
            conn.Close();
            return listAuthors;
        }

        public static List<Genres> GetGenres()
        {
            List<Genres> listGenres = new List<Genres>();
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("GetGenres", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Genres genres = new Genres();
                genres.ID = Convert.ToInt32(reader["ID"]);
                genres.GenreNames = reader["Genre"].ToString();
                listGenres.Add(genres);
            }
            conn.Close();
            return listGenres;
        }

        //delete author from database
        public static void DeleteAuthor(int id)
        {


            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmdDelete = new SqlCommand("DeleteAuthor", conn);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@ID", id);
            cmdDelete.Parameters.AddWithValue("@DateDeleted", DateTime.Now.ToString());
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }

        //check inputs and email with regex
        public static bool IsValidInput(string name, string surname, string nationality, string birthdate, string email)

        {
            bool EmailVal = true;
            EmailVal = Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(nationality) || string.IsNullOrWhiteSpace(birthdate) || EmailVal == false)
            {

                return false;
            }
            else
            {
                return true;

            }

        }

        //update author in database
        public static void UpdateAuthor(string name, string surname, string nationality, string birthdate, int id, string email, bool allowAuthor)
        {
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmdUpdate = new SqlCommand("UpdateAuthors", conn);
            cmdUpdate.CommandType = CommandType.StoredProcedure;

            if (IsValidInput(name, surname, nationality, birthdate, email))
            {
                cmdUpdate.Parameters.AddWithValue("@AuthorName", name);
                cmdUpdate.Parameters.AddWithValue("@AuthorLastname", surname);
                cmdUpdate.Parameters.AddWithValue("@AuthorNationality", nationality);
                cmdUpdate.Parameters.AddWithValue("@Birthdate", Convert.ToDateTime(birthdate));
                cmdUpdate.Parameters.AddWithValue("@ID", id);
                cmdUpdate.Parameters.AddWithValue("@AllowAuthor", allowAuthor);
                cmdUpdate.Parameters.AddWithValue("@Email", email);
                cmdUpdate.Parameters.AddWithValue("@DateUpdated", DateTime.Now.ToString());
                cmdUpdate.ExecuteNonQuery();

            }


            conn.Close();



        }

        //check user info in databse
        public static UserLoginInfo CheckLogin(string Email, string Password)
        {
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmdLogin = new SqlCommand("Login", conn);
            cmdLogin.CommandType = CommandType.StoredProcedure;
            bool canlogin = false;
            string result = null;
            string role = null;
            cmdLogin.Parameters.AddWithValue("@Email", Email);
            cmdLogin.Parameters.AddWithValue("@Password", Password);
            cmdLogin.ExecuteNonQuery();
            SqlDataReader reader = cmdLogin.ExecuteReader();
            UserLoginInfo userLogin = new UserLoginInfo();
            while (reader.Read())
            {
                result = reader["UserEmail"].ToString();
                role = reader["UserRole"].ToString();
            }
            conn.Close();
            if (result == Email)
            {
                canlogin = true;
            }
            else
            {
                canlogin = false;
            }
            result = canlogin.ToString();
            userLogin.UserEmail = result;
            userLogin.UserRole = role;
            return userLogin;
        }
    }
}


