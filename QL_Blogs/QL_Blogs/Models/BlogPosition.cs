using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QL_Blogs.Models
{
    public class BlogPosition
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tên tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Mô tả")]
        public string Descriptions { get; set; }

        [Display(Name = "Nội dung")]
        public string Detail { get; set; }

        [Display(Name = "Loại")]
        public string Category { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày Public")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPublic { get; set; }

        [Display(Name = "Vị trí")]
        public List<int> Position { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Thumbs { get; set; }
        public List<Blog> ShowallBlog { get; set; }
    }
}