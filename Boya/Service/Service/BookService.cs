using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Service.IService;
using Repository.Abstract;
using Repository.Concrete;

namespace Service.Service
{
    public class BookService : IBookService
    {
        IBookRespository bookRespository = new BookRespository();
        public bool AddBook(book_info Book)
        {
            book_info book = bookRespository.Book.FirstOrDefault(p => p.ISBN == Book.ISBN);
            if (book != null)
                return false;
            return bookRespository.SaveBook(Book);
        }

        public bool DeleteBook(string BookISBN)
        {
            return bookRespository.DeleteBook(BookISBN);
        }

        public IEnumerable<book_info> GetBookByPageable(int pageIndex, int pageSize, string bookName = "")
        {
            if(bookName == "")
            {
                return bookRespository.Book.OrderBy(b => b.ISBN)
                    .Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return bookRespository.Book.Where(b => b.book_name.Contains(bookName)).OrderBy(b => b.ISBN)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public bool HasBook(string ISBN)
        {
            return bookRespository.Book.FirstOrDefault(b => b.ISBN == ISBN) != null;
        }

        public bool UpdateBook(book_info Book)
        {
            return bookRespository.SaveBook(Book);
        }
    }
}
