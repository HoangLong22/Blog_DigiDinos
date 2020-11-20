using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QL_Blogs.Models
{
    public class Position
    {
        [Key]
        public int ID { get; set; }

        public int PosCateID { set; get; }
        public int BlogID { set; get; }
        public List<Position> ShowallPosition { get; set; }
    }
}