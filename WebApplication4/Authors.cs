using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class Authors
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public string Genre { get; set; }
        public DateTime Birthdate { get; set; }
        public string DateDeleted { get; set; }
        public string DateUpdated { get; set; }
        public string DateInserted { get; set; }
        public Boolean AllowAuthor { get; set; }


    }
}
