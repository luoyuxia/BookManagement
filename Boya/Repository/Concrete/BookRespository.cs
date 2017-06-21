using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class BookRespository : IBookRespository
    {
        BookManagementEntities DBContext = new BookManagementEntities();
        public IQueryable<book_info> Book
        {
            get
            {
                return DBContext.book_info;
            }
        }

        public bool DeleteBook(string ISBN)
        {
            book_info b = DBContext.book_info.Find(ISBN);
            if (b == null)
                return false;
            DBContext.book_info.Remove(b);
            DBContext.SaveChanges();
            return true;
        }

        public bool SaveBook(book_info book)
        {
            book_info b = DBContext.book_info.Find(book.ISBN);
            if(b== null)
            {
                DBContext.book_info.Add(book);
            }
            else
            {
                DBContext.Entry(b).CurrentValues.SetValues(book);
            }
            DBContext.SaveChanges();
            return true;
        }
    }
}
