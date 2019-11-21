using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class Books
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public string BookDescribtion { get; set; }
        public int ReleaseDate { get; set; }
    }
}