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
        public static List<Authors> GetAllAuthors()
        {     
            List<Authors> listAuthors = new List<Authors>();
            Connection connection = new Connection();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("getAllAuthors", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Authors authors = new Authors();
                authors.ID = Convert.ToInt32(reader["ID"]);
                authors.Name = reader["AuthorName"].ToString();
                authors.Surname = reader["AuthotLastname"].ToString();
                authors.Nationality = reader["AuthorNationality"].ToString();
                authors.Birthdate = Convert.ToDateTime(reader["Birthdate"].ToString());
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
                books.Id = Convert.ToInt32(reader["Id"]);
                books.BookName = reader["BookName"].ToString();
                books.BookGenre = reader["BookGenre"].ToString();
                books.BookDescribtion = reader["BookDescribtion"].ToString();
                books.BookAuthor = reader["BookAuthor"].ToString();
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
              authors.Name = reader["AuthorName"].ToString();
              listAuthors.Add(authors);
            }
            conn.Close();
            return listAuthors;
        }


        //delete author from database
        public static void DeleteAuthor(int id)
        {
            Connection connection = new Connection();
            connection.Create_Connection();
            SqlCommand cmdDelete = new SqlCommand("DeleteAuthor", conn);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@BookID", id);
            cmdDelete.Parameters.AddWithValue("@DateDeleted", DateTime.Now.ToString());
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }

        //update author in database
        public static void UpdateAuthor(string name, string surname, string nationality, string birthdate, int id, bool allowAuthor)
        {
            Connection connection = new Connection();
            connection.Create_Connection();
            SqlCommand cmdUpdate = new SqlCommand("UpdateAuthors", conn);
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@AuthorName", name);
            cmdUpdate.Parameters.AddWithValue("@AuthotLastname", surname);
            cmdUpdate.Parameters.AddWithValue("@AuthorNationality", nationality);
            cmdUpdate.Parameters.AddWithValue("@Birthdate", Convert.ToDateTime(birthdate));
            cmdUpdate.Parameters.AddWithValue("@ID", id);
            cmdUpdate.Parameters.AddWithValue("@AllowAuthor", allowAuthor);
            cmdUpdate.Parameters.AddWithValue("@DateUpdated", DateTime.Now.ToString());
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
    }
}

