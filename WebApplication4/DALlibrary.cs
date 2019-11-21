using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;


using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.Web.Services;
using System.Linq;
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
                books.ID = Convert.ToInt32(reader[nameof(books.ID)]);
                books.BookName = reader[nameof(books.BookName)].ToString();
                books.AuthorName = reader[nameof(books.AuthorName)].ToString();
                books.Genre = reader[nameof(books.Genre)].ToString();
                books.BookDescribtion = reader[nameof(books.BookDescribtion)].ToString();
                books.ReleaseDate = Convert.ToInt32(reader[nameof(books.ReleaseDate)]);
                listBooks.Add(books);
            }
            conn.Close();
            return listBooks;
        }

        public static List<Users> GetUsers()
        {
            List<Users> listUsers = new List<Users>();
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("GetUsers", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Users users = new Users();
                users.Id = Convert.ToInt32(reader[nameof(users.Id)]);
                users.UserName = reader[nameof(users.UserName)].ToString();
                users.UserSurname = reader[nameof(users.UserSurname)].ToString();
                users.UserEmail = reader[nameof(users.UserEmail)].ToString();
                listUsers.Add(users);
            }
            conn.Close();
            return listUsers;

        }

        public static List<Role> GetRoles()
        {
            List<Role> listRole = new List<Role>();
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("GetRoles", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Role role = new Role();
                role.ID = Convert.ToInt32(reader[nameof(role.ID)]);
                role.RoleName = reader[nameof(role.RoleName)].ToString();
                listRole.Add(role);
            }
            conn.Close();
            return listRole;
        }

        public static Users GetUserDetailsByUserId(int id)
        {
            var User = new Users();
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("GetUserInfoByUserId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", id);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User.Id = Convert.ToInt32(reader[nameof(User.Id)]);
                User.UserName = reader[nameof(User.UserName)].ToString();
                User.UserSurname = reader[nameof(User.UserSurname)].ToString();
                User.UserEmail = reader[nameof(User.UserEmail)].ToString();
            }
            conn.Close();
            User.UserRoles = GetUserRolesByUserId(User.Id);
            if (User.HasRoles)
            {
                var result = User.UserRoles;
                foreach (var RoleItem in result)
                {
                    RoleItem.IsSelected = User.UserRoles.Any(Item => Item.ID == RoleItem.ID);
                }
            }
            return User;
        }

        public static List<Role> GetUserRolesByUserId(int id)
        {
            List<Role> listRoles = new List<Role>();
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmd = new SqlCommand("GetUserRolesByUserId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", id);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Role role = new Role();
                role.ID = Convert.ToInt32(reader[nameof(role.ID)]);
                role.RoleName = reader[nameof(role.RoleName)].ToString();
                listRoles.Add(role);
            }
            conn.Close();
            return listRoles;
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
                genres.ID = Convert.ToInt32(reader[nameof(genres.ID)]);
                genres.Genre = reader[nameof(genres.Genre)].ToString();
                listGenres.Add(genres);
            }
            conn.Close();
            return listGenres;
        }

        //delete author from database
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
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

        [WebMethod]
     
        //check inputs and email with regex
        public static bool IsValidInput(bool IsFullValidation, string name, string surname, string email, string nationality = "", string birthdate = "")

        {
            bool EmailVal = true;
            bool IsValid = false;
            EmailVal = Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (EmailVal && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(surname) && (!string.IsNullOrWhiteSpace(nationality) || !IsFullValidation) && (!string.IsNullOrWhiteSpace(birthdate) || !IsFullValidation))
            {

                IsValid = true;
            }
            return IsValid;
        }

        //update author in database
        [WebMethod]
        public static void UpdateAuthor(string name, string surname, string nationality, string birthdate, int id, string email, bool allowAuthor)
        {
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmdUpdate = new SqlCommand("UpdateAuthors", conn);
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            if (IsValidInput(true, name, surname, nationality, birthdate, email))
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

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static void UpdateUser(int id, string name, string surname, string email)
        {
            BasePage connection = new BasePage();
            connection.Create_Connection();
            SqlCommand cmdUpdate = new SqlCommand("UpdateUser", conn);
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            if (IsValidInput(IsFullValidation: false, name: name, surname: surname, email: email))
            {
                cmdUpdate.Parameters.AddWithValue("ID", id);
                cmdUpdate.Parameters.AddWithValue("@UserName", name);
                cmdUpdate.Parameters.AddWithValue("@UserLastname", surname);
                cmdUpdate.Parameters.AddWithValue("@Email", email);
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
            List<string> role = new List<string>();
            cmdLogin.Parameters.AddWithValue("@Email", Email);
            cmdLogin.Parameters.AddWithValue("@Password", Password);
            cmdLogin.ExecuteNonQuery();
            SqlDataReader reader = cmdLogin.ExecuteReader();
            UserLoginInfo userLogin = new UserLoginInfo();
            while (reader.Read())
            {
                result = reader[nameof(userLogin.UserEmail)].ToString();
                role.Add(reader[nameof(userLogin.RoleName)].ToString());
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
            userLogin.RoleName = role;
            return userLogin;
        }

    }
}


