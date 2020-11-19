using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_Blogs.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string Title { set; get; }
        public string Des { set; get; }
        public string Detail { set; get; }
        public int Category { get; set; }
        public int Public { get; set; }
        public string DataPubblic { get; set; }
        public int Position { get; set; }
        public string Thumbs { get; set; }
    }
}