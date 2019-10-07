using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication4
{    public class LibraryDataAccessLayer : Connection
    {
        //get authors from database
        public static List<Authors> GetAuthors()
        {     
            List<Authors> listAuthors = new List<Authors>();
            Connection connection = new Connection();
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
            Connection connection = new Connection();
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
            Connection connection = new Connection();
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
            Connection connection = new Connection();
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
            Connection connection = new Connection();
            connection.Create_Connection();
            SqlCommand cmdDelete = new SqlCommand("DeleteAuthor", conn);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@ID", id);
            cmdDelete.Parameters.AddWithValue("@DateDeleted", DateTime.Now.ToString());
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }

        //update author in database
        public static void UpdateAuthor(string name, string surname, string nationality, string birthdate, int id, bool allowAuthor, string email)
        {
            Connection connection = new Connection();
            connection.Create_Connection();
            SqlCommand cmdUpdate = new SqlCommand("UpdateAuthors", conn);
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@AuthorName", name);
            cmdUpdate.Parameters.AddWithValue("@AuthorLastname", surname);
            cmdUpdate.Parameters.AddWithValue("@AuthorNationality", nationality);
            cmdUpdate.Parameters.AddWithValue("@Birthdate", Convert.ToDateTime(birthdate));
            cmdUpdate.Parameters.AddWithValue("@ID", id);
            cmdUpdate.Parameters.AddWithValue("@AllowAuthor", allowAuthor);
            cmdUpdate.Parameters.AddWithValue("@Email", email);
            cmdUpdate.Parameters.AddWithValue("@DateUpdated", DateTime.Now.ToString());
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
     
    }
}

