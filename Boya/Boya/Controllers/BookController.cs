using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Service.IService;
using Service.Service;

namespace Boya.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService = new BookService();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBook(int pageIndex = 1,int pageSize=10,string name = "")
        {
            IEnumerable<book_info> books = bookService.GetBookByPageable(pageIndex, pageSize, name);
            var result = from book in books
                         select new
                         {
                             ISBN = book.ISBN,
                             book_name = book.book_name,
                             author = book.author,
                             press = book.press,
                             edition = book.edition,
                             publish_time = book.publish_time,
                             price = book.price,
                             category_id = book.category_id
                         };
            int total = result.Count();
            return Json(new { rows = result, total = total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddBooks(List<book_info> books)
        {
            bool addSuccess = true;
            foreach(book_info b in books)
            {
                bool isSuccess = bookService.AddBook(b) || bookService.UpdateBook(b);
                addSuccess = addSuccess && isSuccess;
            }
            return Json(new { result = addSuccess });
        }


        [HttpPost]
        public JsonResult UpdateBook(book_info book)
        {
            return Json(new { result = bookService.UpdateBook(book) });
        }

        [HttpPost]
        public JsonResult DeleteBooks(List<string> BooksISBN)
        {
            bool deleteSuccess = true;
            bool hasDeleteItem = false;
            foreach(string ISBN in BooksISBN)
            {
                if(bookService.HasBook(ISBN))
                {
                    hasDeleteItem = true;
                    deleteSuccess = deleteSuccess && bookService.DeleteBook(ISBN);
                }
            }
            string result = "none";
            if(hasDeleteItem)
            {
                result = deleteSuccess ? "success" : "fail";
            }
            return Json(new { result = result });
        }
    }
}