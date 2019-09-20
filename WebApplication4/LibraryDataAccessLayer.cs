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
                authors.Genre = reader["Genre"].ToString();
                authors.Birthdate = Convert.ToDateTime(reader["Birthdate"].ToString());
                authors.DateDeleted = reader["DateDeleted"].ToString();
                authors.DateUpdated = reader["DateUpdated"].ToString();
                authors.DateInserted = reader["DateInserted"].ToString();
                listAuthors.Add(authors);
               
            }
            conn.Close();
            return listAuthors;
           
        }

        
        public static void DeleteAuthor(int id)
        {
      
            Connection connection = new Connection();
            connection.Create_Connection();
            SqlCommand cmdDelete = new SqlCommand("DeleteUser", conn);
            cmdDelete.CommandType = CommandType.StoredProcedure;
        //  SqlParameter param = new SqlParameter("@BookID", id);
        //  cmdDelete.Parameters.Add(param);
        //  cmdDelete.Parameters["@BookID"].Value = (8);
            cmdDelete.Parameters.AddWithValue("@BookID", id);
            cmdDelete.ExecuteNonQuery();
            conn.Close();
            
        }


        public static void UpdateAuthor(string name, string surname, string nationality, string genre, string birthdate, int id)
        {
            Connection connection = new Connection();
            connection.Create_Connection();
            SqlCommand cmdUpdate = new SqlCommand("UpdateAuthors", conn);
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@AuthorName", name);
            cmdUpdate.Parameters.AddWithValue("@AuthotLastname", surname);
            cmdUpdate.Parameters.AddWithValue("@AuthorNationality", nationality);
            cmdUpdate.Parameters.AddWithValue("@Genre", genre);
            cmdUpdate.Parameters.AddWithValue("@Birthdate", birthdate);
            cmdUpdate.Parameters.AddWithValue("@ID", id);
            cmdUpdate.ExecuteNonQuery();
            conn.Close();


        }

    }
}

