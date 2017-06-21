using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Service.IService
{
    public interface IBookService
    {
        bool AddBook(book_info Book);

        bool DeleteBook(string BookISBN);

        bool UpdateBook(book_info Book);

        IEnumerable<book_info> GetBookByPageable(int pageIndex, int pageSize, string bookName = "");

        bool HasBook(string ISBN);
    }
}
