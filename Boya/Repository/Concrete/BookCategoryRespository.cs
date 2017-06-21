using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class BookCategoryRespository : IBookCategoryRespository
    {
        BookManagementEntities context = new BookManagementEntities();
        public IQueryable<category_info> GetBookCategory
        {
            get
            {
                return context.category_info;
            }
        }

        public bool DeleteBookCategory(int id)
        {
            category_info Category = context.category_info.Find(id);
            if (Category == null && Category.book_info.Count > 0)
                return false;
            context.category_info.Remove(Category);
            context.SaveChanges();
            return true;
        }

        public bool SaveBookCategory(category_info category)
        {
            category_info dbEntry = context.category_info.Find(category.category_id);
            if(dbEntry == null)
            {
                context.category_info.Add(category);
            }
            else
            {
                context.Entry(dbEntry).CurrentValues.SetValues(category);
            }
            context.SaveChanges();
            return true;
        }
    }
}
