
using System.Collections.Generic;

namespace WebApplication4
{
    public class Users
    {
        public int Id { get; set; }
        public string  UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public bool HasRoles => UserRoles?.Count > 0;
        public List<Role> UserRoles { get; set; }
    }
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public bool  IsSelected { get; set; }
    }


   
}