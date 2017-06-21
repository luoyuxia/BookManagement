using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository.Abstract
{
    public interface IBookCategoryRespository
    {
        IQueryable<category_info> GetBookCategory { get; }

        bool DeleteBookCategory(int id);

        bool SaveBookCategory(category_info category);
    }
}
