using Lab02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloTeacher(string university)
        {
            return "Xin chào Trương Tín - University: " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML_5 & CSS3 The complete MAnual - Author Name Book 1");
            books.Add("HTML_5 & CSS Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC5- Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML_5 & CSS3 The complete MAnual","Author Name Book 1","/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML_5 & CSS Responsive web Design cookbook"," Author Name Book 2","/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5"," Author Name Book 2","/Content/Images/book3cover.jpg"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML_5 & CSS3 The complete MAnual", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML_5 & CSS Responsive web Design cookbook", " Author Name Book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", " Author Name Book 2", "/Content/Images/book3cover.jpg"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.Id==id)
                {
                    book = b;
                    break;
                }    
            }
            if(book == null)
            {
                return HttpNotFound();
            }    
            return View(book);
        }
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Tittle,string Author,string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML_5 & CSS3 The complete MAnual", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML_5 & CSS Responsive web Design cookbook", " Author Name Book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", " Author Name Book 2", "/Content/Images/book3cover.jpg"));
            if(id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Tittle = Tittle;
                    b.Author = Author;
                    b.Imagecover = ImageCover;
                    break;
                }
            }
            return View("ListbookModel",books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id,Tittle,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML_5 & CSS3 The complete MAnual", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML_5 & CSS Responsive web Design cookbook", " Author Name Book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", " Author Name Book 2", "/Content/Images/book3cover.jpg"));
            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(book);
                }    
            }catch(RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error save data");
            }
            return View("ListBookModel",books);
        }

    }
}