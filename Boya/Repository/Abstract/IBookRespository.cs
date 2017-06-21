using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository.Abstract
{
    public interface IBookRespository
    {
        IQueryable<book_info> Book { get; }

        bool SaveBook(book_info book);

        bool DeleteBook(string ISBN);
    }
}
