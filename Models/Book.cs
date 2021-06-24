using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab02.Models
{
    public class Book
    {
        private int id;
        private string tittle;
        private string author;
        private string image_cover;
        public Book()
        {

        }
        public Book(int id, string tittle, string author, string image_cover)
        {
            this.id = id;
            this.tittle = tittle;
            this.author = author;
            this.image_cover = image_cover;
        }
        [Required(ErrorMessage = "Mã sách không được để trống")]
        
        [Display(Name = "Mã sách")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Required(ErrorMessage ="Tiêu đề không được để trống")]
        [StringLength(2,ErrorMessage ="Tiêu đề không được vượt quá 250 kí tự")]
        [Display(Name ="Tiêu đề")]

        public string Tittle
        {
            get { return tittle; }
            set { tittle = value; }
        }
        [Display(Name = "Tác giả")]
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        [Display(Name = "Ảnh bìa")]
        public string Imagecover
        {
            get { return image_cover; }
            set { image_cover = value; }
        }
    }
}