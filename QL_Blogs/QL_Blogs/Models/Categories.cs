using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QL_Blogs.Models
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }

        public string Name { set; get; }

        public List<Categories> ShowallCategory { get; set; }
    }
}